export class Theatre {
	id: number;
	name: string;
	noOfHalls: number;
	cityId: number;
	ticketPrice: number;

	constructor(args: any) {
		this.id = args.id;
		this.name = args.name;
		this.noOfHalls = args.noOfHalls;
		this.cityId = args.cityId;
		this.ticketPrice = args.ticketPrice;
	}
}