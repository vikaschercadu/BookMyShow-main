export class City {
	id: number;
	name: string;
	pincode: string;

	constructor(args: any) {
		this.id = args.id;
		this.name = args.name;
		this.pincode = args.pincode;
	}
}