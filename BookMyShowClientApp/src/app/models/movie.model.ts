export class Movie {
	id: number;
	title: string;
	language: string;
	genre: string;
	runningTime: string;
	releaseDate: Date;
	imageUrl: string;

	constructor(args: any) {
		this.id = args.id;
		this.title = args.title;
		this.language = args.language;
		this.genre = args.genre;
		this.runningTime = args.runningTime;
		this.releaseDate = args.releaseDate;
		this.imageUrl = args.imageUrl;
	}
}