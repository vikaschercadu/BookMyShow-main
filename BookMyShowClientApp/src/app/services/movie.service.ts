import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from 'rxjs';

import { Movie } from '../models';


@Injectable({
	providedIn: 'root'
})
export class MovieService {

	movies: Movie[] = [];
	private apiUrl = "https://localhost:44319/api/movie";

	constructor(private httpClient: HttpClient) { }

	httpOptions = {
		headers: new HttpHeaders({
			'Content-Type': 'application/json'
		})
	}

	getAll(): Observable<Movie[]> {

		return this.httpClient.get<Movie[]>(this.apiUrl + '/all')

	}
}
