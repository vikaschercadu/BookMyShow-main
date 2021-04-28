export class Hall {
	id: number;
	totalSeats: number;
	theatreId: number;

	constructor(args: any) {
		this.id = args.id;
		this.totalSeats = args.totalSeats;
		this.theatreId = args.theatreId;
	}
}