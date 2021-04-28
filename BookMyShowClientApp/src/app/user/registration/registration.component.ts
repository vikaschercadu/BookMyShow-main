import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { User } from '../../models';
import { LoginService } from '../../services';
import { AuthService } from '../../auth'

@Component({
	selector: 'app-registration',
	templateUrl: './registration.component.html',
	styles: [
	]
})
export class RegistrationComponent implements OnInit {

	user: User=new User({});
	form!: FormGroup;
	retUrl: string = "";
	userId: number = 0;
	mobileNumberPattern = "^((\\+91-?)|0)?[0-9]{10}$";
	emailPattern = "^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$"

	constructor(private authService: AuthService,
		private router: Router,
		public loginService: LoginService, private toastr: ToastrService
	) { }

	ngOnInit(): void {

		this.form = new FormGroup({
			'name': new FormControl(null, Validators.required)!,
			'email': new FormControl(null, [Validators.required, Validators.email])!,
			'password': new FormControl(null, Validators.required),
			'mobile': new FormControl(null, [Validators.required, Validators.pattern(this.mobileNumberPattern)])!
		})!;
	}

	onSubmit() {
		this.user.name = this.form.value.name;
		this.user.emailId = this.form.value.email;
		this.user.password = this.form.value.password;
		this.user.mobileNo = this.form.value.mobile;

		this.loginService.registerUser(this.user).subscribe(
			(res: any) => {
				if (res.succeeded) {
					this.toastr.success('LoggedIn', 'succesfully!');
					this.loginService.loginUser(this.user).subscribe(
						(res: any) => {
							localStorage.setItem('accessToken', res.token.accessToken);
							localStorage.setItem('userId', res.token.userId)
							this.user.name = res.token.name;
							this.user.id = res.token.userId;
							this.toastr.success('LoggedIn', 'succesfully!');

							this.authService.login().subscribe(data => {
								if (this.authService.retUrl != null) {
									this.router.navigate([this.authService.retUrl]);
								} else {
									this.router.navigate(['city']);
								}
							});
						},
						err => {
							this.toastr.error("Incorrect email or Password", "Try Again")
						}
					)
				}
				else {
					res.forEach((element: { code: any; }) => {
						switch (element.code) {
							case 'DuplicateUserName':
								this.toastr.error('Email is already registered', 'Please log In')
								this.form.reset();
								break;
							default:
								this.toastr.error('Registration failed');
						}
					});
				}
			},
			err => {
				this.toastr.error('Registration failed');
			}
		);
		this.loginService.user = this.user;
	}
}
