export class User {
	id: string;
	name: string;
	emailId: string;
	password: string;
	mobileNo: string;

	constructor(args: any) {
		this.id = args.id;
		this.name = args.name;
		this.emailId = args.emailId;
		this.password = args.password;
		this.mobileNo = args.mobileNo;
	}
}