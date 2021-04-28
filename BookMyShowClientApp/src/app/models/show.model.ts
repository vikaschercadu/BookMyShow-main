export class Show {
    id: number;
    date: Date;
    startTime: string;
    endTime: string;
    hallId: number;
    movieId: number;

    constructor(args: any) {
        this.id = args.id;
        this.date = args.date;
        this.startTime = args.startTime;
        this.endTime = args.endTime;
        this.hallId = args.hallId;
        this.movieId = args.movieId;
    }
}