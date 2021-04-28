import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { AuthService } from '../auth';
import { Seat, Theatre, Booking } from '../models';
import { LoginService } from './login.service';
import { SeatService } from './seat.service';
import { TheatreService } from './theatre.service';

@Injectable({
	providedIn: 'root'
})
export class PaymentService {

	private apiUrl = "https://localhost:44319/api/theatre";
	selectedTheatre: Theatre = new Theatre({});
	userId: number = 0;
	holdSeats: Seat[] = [];
	private seatApiURL = "https://localhost:44319/api/seat";
	private bookingApiUrl = "https://localhost:44319/api/booking";

	constructor(public theatreService: TheatreService, public seatService: SeatService, private httpClient: HttpClient, public loginService: LoginService, public authService: AuthService) { }

	ngOnInit(): void {

	}

	httpOptions = {
		headers: new HttpHeaders({
			'Content-Type': 'application/json'
		})
	}

	getTheatre(): Observable<Theatre> {
		return this.httpClient.get<Theatre>(this.apiUrl + "/" + this.seatService.selectedHall.theatreId);
	}

	getNoOfSeats() {
		return this.seatService.noOfSeats;
	}

	getHallId() {
		return this.seatService.selectedHall.id;
	}

	confirmSeatBooking(noOfSeats: number, hallId: number): Observable<void> {
		return this.httpClient.get<void>(this.seatApiURL + '/confirm/' + noOfSeats + '/' + hallId);
	}

	cancelBooking(noOfSeats: number, hallId: number): Observable<void> {
		return this.httpClient.get<void>(this.seatApiURL + '/cancel/' + noOfSeats + '/' + hallId);
	}

	confirmBooking(booking: Booking) {
		return this.httpClient.post<Booking>(this.bookingApiUrl + '/add', JSON.stringify(booking), this.httpOptions)
	}

	getShowTime() {
		return this.seatService.selectedShow.startTime;
	}

	getShowId() {
		return this.seatService.selectedShow.id;
	}

}
