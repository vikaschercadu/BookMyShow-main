import { Component, OnInit } from '@angular/core';

import { Hall, Show, ShowsInTheatre, TheatreWithShows } from '../models';
import { TheatreService } from '../services';

@Component({
	selector: 'app-theatre',
	templateUrl: './theatre.component.html',
	styles: [
	]
})
export class TheatreComponent implements OnInit {

	movieId: number = 0;
	cityChosenId!: number;
	shows: Show[] = [];
	currentShow: Show = new Show({});
	theatreWithShows: TheatreWithShows[] = [];
	showsInTheatre: ShowsInTheatre[] = []
	currentShowInTheatre: ShowsInTheatre = new ShowsInTheatre({});
	currentHall: Hall = new Hall({});

	constructor(public theatreService: TheatreService) {
	}

	ngOnInit(): void {
		this.cityChosenId = this.theatreService.getCityId();
		this.movieId = this.theatreService.getMovieId();

		this.theatreService.getTheatresWithShows().subscribe((data: TheatreWithShows[]) => {
			this.theatreWithShows = data;
			this.getshows();
		})
	}

	getshows() {
		var prevTheatreId = this.theatreWithShows[0].theatreId;
		var index = 0;

		while (index < this.theatreWithShows.length) {
			this.currentShowInTheatre.id = this.theatreWithShows[index].theatreId;
			this.currentShowInTheatre.name = this.theatreWithShows[index].theatreName;

			if (index < this.theatreWithShows.length) {
				while (prevTheatreId == this.theatreWithShows[index].theatreId) {
					this.currentHall.id = this.theatreWithShows[index].hallId;
					this.currentHall.totalSeats = this.theatreWithShows[index].totalSeats;
					this.currentHall.theatreId = this.theatreWithShows[index].theatreId;
					if(this.currentShowInTheatre.halls==undefined){
						this.currentShowInTheatre.halls=[];
					}
					if (!this.currentShowInTheatre.halls.includes(this.currentHall)) {
						this.currentShowInTheatre.halls.push(this.currentHall);
					}

					this.currentShow.id = this.theatreWithShows[index].showId;
					this.currentShow.date = this.theatreWithShows[index].showDate;
					this.currentShow.startTime = this.theatreWithShows[index].startTime;
					this.currentShow.endTime = this.theatreWithShows[index].endTime;
					this.currentShow.hallId = this.theatreWithShows[index].hallId;
					this.currentShow.movieId = this.theatreService.getMovieId();
					if(this.currentShowInTheatre.shows==undefined){
						this.currentShowInTheatre.shows=[];
					}
					this.currentShowInTheatre.shows.push(this.currentShow);
					this.currentShow = new Show({});
					this.currentHall = new Hall({});
					index++;

					if (index >= this.theatreWithShows.length) {
						break;
					}
				}

				this.showsInTheatre.push(this.currentShowInTheatre);
				this.currentShowInTheatre = new ShowsInTheatre({});
				if (index < this.theatreWithShows.length)
					prevTheatreId = this.theatreWithShows[index].theatreId;
			}
		}
	}
}
