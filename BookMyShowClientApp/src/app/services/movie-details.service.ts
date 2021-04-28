import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { Movie } from '../models';

@Injectable({
	providedIn: 'root'
})
export class MovieDetailsService {

	movie: Movie = new Movie({});
	movieId!: number;
	private apiUrl = "https://localhost:44319/api/movie";

	constructor(private httpClient: HttpClient) { }

	httpOptions = {
		headers: new HttpHeaders({
			'Content-Type': 'application/json'
		})
	}

	getMovie(id: number): Observable<Movie> {
		return this.httpClient.get<Movie>(this.apiUrl + "/" + id);
	}

	setMovieId(movieId: number) {
		this.movieId = movieId;
	}

	getMovieId() {
		return this.movieId;
	}

}
