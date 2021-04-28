import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { ToastrService } from 'ngx-toastr';

import { Booking, Seat, Theatre, User } from '../models';
import { PaymentService } from '../services';

@Component({
	selector: 'app-payment',
	templateUrl: './payment.component.html',
	styles: [
	]
})
export class PaymentComponent implements OnInit {

	holdSeats: Seat[] = [];
	user: User = new User({});
	selectedTheatre: Theatre = new Theatre({});
	booking: Booking = new Booking({});

	constructor(public paymentService: PaymentService, private router: Router, private toastr: ToastrService) { }

	ngOnInit(): void {
		this.paymentService.getTheatre().subscribe(
			res => {
				this.selectedTheatre = res;
				this.paymentService.selectedTheatre = res;
			}
		);
	}


	confirmBooking() {
		this.paymentService.confirmSeatBooking(this.paymentService.getNoOfSeats(), this.paymentService.getHallId()).subscribe();
		this.booking.noOfSeats = this.paymentService.getNoOfSeats();
		this.booking.date = new Date();
		this.booking.timeSlot = this.paymentService.getShowTime();
		this.booking.status = "booked";
		this.booking.showId = this.paymentService.getShowId();
		this.booking.userId = localStorage.getItem('userId')!;
		this.paymentService.confirmBooking(this.booking).subscribe();
		this.toastr.success('Successfully', 'TicketsBooked!');
		this.router.navigate(['showTicket']);
	}

	cancelPayment() {

		this.paymentService.cancelBooking(this.paymentService.getNoOfSeats(), this.paymentService.getHallId()).subscribe();
		this.toastr.success('Successfully', 'Tickets Cancelled!');
		this.router.navigate(['movies']);
	}
}
