import { Hall } from "./hall.model";
import { Show } from "./show.model";

export class ShowsInTheatre {
	id: number;
	name: string;
	halls: Hall[];
	shows: Show[];

	constructor(args: any) {
		this.id = args.id;
		this.name = args.name;
		this.halls = args.hall;
		this.shows = args.shows;
	}
}