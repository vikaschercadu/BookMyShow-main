export class TheatreWithShows {
	theatreId: number;
	theatreName: string;
	noOfHalls: number;
	showId: number;
	showDate: Date;
	startTime: string;
	endTime: string;
	hallId: number;
	totalSeats: number;

	constructor(args: any) {
		this.theatreId = args.theatreId;
		this.theatreName = args.theatreName;
		this.noOfHalls = args.noOfHalls;
		this.showId = args.showId;
		this.showDate = args.showDate;
		this.startTime = args.startTime;
		this.endTime = args.endTime;
		this.hallId = args.hallId;
		this.totalSeats = args.totalSeats
	}
}