import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { ToastrService } from 'ngx-toastr';

import { LoginService } from './services';
import {AuthService} from './auth'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
	title = 'BookMyShowApp';
	constructor(public authService:AuthService,public loginService:LoginService,  private toastr:ToastrService, private router:Router){}

	ngOnInit(): void {
	}

	logOut(){
		this.authService.logoutUser();
		this.authService.isAdmin=false;
		this.toastr.success('Loggedout', 'succesfully!');
		this.router.navigate(['city']);
	}
}
