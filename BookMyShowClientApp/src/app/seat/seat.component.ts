import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';

import { Hall } from '../models';
import { SeatService } from '../services';

@Component({
  selector: 'app-seat',
  templateUrl: './seat.component.html',
  styles: [
  ]
})
export class SeatComponent implements OnInit {

	hallId:number=0;
	hall:Hall=new Hall({});
	showId:number=0;
	selectedHall:Hall=new Hall({});
	bookedSeats:number=0;
	noOfSeats!:number;

  	constructor(public route:ActivatedRoute, public seatService:SeatService,public router:Router) { }

  	ngOnInit(): void {
		this.route.params.subscribe(
			(param: Params) =>{
				this.hallId=+param['id']; 
				this.showId=+param['id2'];
			}
		);

		this.seatService.getShow(this.showId).subscribe(res=>{
			this.seatService.selectedShow=res;
		})
		this.seatService.getHallById(this.hallId).subscribe(res=>{
			this.seatService.selectedHall=res;
			this.selectedHall=res;
		});

		this.seatService.getBookedSeats(this.hallId).subscribe(res=>{
			this.bookedSeats=res;
		});
	}

     validateSeats(){
    		var availableSeats=this.selectedHall.totalSeats-this.bookedSeats-this.noOfSeats;
    			if(availableSeats>=0){
	 			return true;
    			}
    		return false;
  	}

  	onSubmit(){
    		this.seatService.setNoOfSeats(this.noOfSeats);
    		this.seatService.holdSeats(this.noOfSeats, this.hallId).subscribe();
		this.router.navigate(['payment']);
  	}

}
