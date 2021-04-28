export class Booking {
	noOfSeats: number;
	date: Date;
	timeSlot: string;
	status: string;
	showId: number;
	userId: string;

	constructor(args: any) {
		this.noOfSeats = args.noOfSeats;
		this.date = args.date;
		this.timeSlot = args.timeSlot;
		this.status = args.status;
		this.showId = args.showId;
		this.userId = args.userId;
	}
}