export class Seat {
	seatId: number;
	status: string;
	hallId: number;

	constructor(args: any) {
		this.seatId = args.seatId;
		this.status = args.status;
		this.hallId = args.hallId;
	}
}