import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { TheatreWithShows } from '../models';
import { CityService } from './city.service';
import{MovieDetailsService} from './movie-details.service'

@Injectable({
	providedIn: 'root'
})
export class TheatreService {
	cityChosen!: number;
	private apiURL = "https://localhost:44319/api/theatre"

	constructor(public cityService: CityService, public movieDetailsService: MovieDetailsService, private httpClient: HttpClient) { }

	ngOnInit(): void {
		this.cityChosen = this.cityService.getCityId();
	}

	httpOptions = {
		headers: new HttpHeaders({
			'Content-Type': 'application/json'
		})
	}

	getTheatresWithShows(): Observable<TheatreWithShows[]> {
		return this.httpClient.get<TheatreWithShows[]>(this.apiURL + '/theatreShowsDetails/' + this.cityService.getCityId() + '/' + this.movieDetailsService.getMovieId())
	}

	getCityId() {
		return this.cityService.getCityId();
	}

	getMovieId() {
		return this.movieDetailsService.getMovieId();
	}

}
