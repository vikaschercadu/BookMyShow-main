import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';

import { Movie } from '../../models';
import { MovieDetailsService } from '../../services';

@Component({
  selector: 'app-movie-details',
  templateUrl: './movie-details.component.html',
  styles: [
  ]
})
export class MovieDetailsComponent implements OnInit {

	movie:Movie=new Movie({});
	movieId: number=0;
	
  	constructor(private route:ActivatedRoute, public movieDetailsService:MovieDetailsService) { }

	ngOnInit(): void {
		this.route.params.subscribe(
			(param: Params) =>{
			this.movieId=+param['id'];
			}
		);
		
		this.movieDetailsService.getMovie(this.movieId).subscribe((data: Movie)=>{
			this.movie = data;
		})
		
		this.movieDetailsService.setMovieId(this.movieId);    
	}
}
