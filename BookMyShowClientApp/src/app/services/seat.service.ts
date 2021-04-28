import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Hall, Seat, Show } from '../models';

@Injectable({
  providedIn: 'root'
})
export class SeatService {

	private apiURL="https://localhost:44319/api/hall";
	private showApiUrl="https://localhost:44319/api/show"; 
	private seatApiURL="https://localhost:44319/api/seat";
	
	selectedHall:Hall=new Hall({});
	selectedShow:Show=new Show({});
	availableSeats:Seat[]=[];
	bookedSeats:number=0;
	noOfSeats:number=0;

	constructor(private httpClient:HttpClient) { }

	httpOptions = {
		headers: new HttpHeaders({
			'Content-Type': 'application/json'
		})
	}

  	getHallById(id:number):Observable<Hall>{
    		return this.httpClient.get<Hall>(this.apiURL+"/"+id);
 	}

	getShow(id:number):Observable<Show>{
		return this.httpClient.get<Show>(this.showApiUrl+"/"+id);
	}

  	getBookedSeats(id:number):Observable<number>{
		return this.httpClient.get<number>(this.seatApiURL+"/booked/"+id);
	}

  	setNoOfSeats(noOfSeats:number){
    		this.noOfSeats=noOfSeats;
  	}

  	holdSeats(noOfSeats:number, hallId:number): Observable<void>{
    		return this.httpClient.get<void>(this.seatApiURL+'/hold/'+noOfSeats+'/'+hallId);
	}
	  
}
