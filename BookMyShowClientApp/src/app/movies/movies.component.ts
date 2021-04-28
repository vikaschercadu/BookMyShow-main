import { Component, OnInit } from '@angular/core';

import { Movie } from '../models';
import { MovieService } from '../services';

@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styles: [
  ]
})
export class MoviesComponent implements OnInit {

  	movies:Movie[]=[];
  	constructor(public movieService:MovieService) { }

  	ngOnInit(): void {
    		this.movieService.getAll().subscribe((data: Movie[])=>{
      		this.movies = data;
    		}) 
  	}	

}
