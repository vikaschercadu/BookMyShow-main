import { Component, OnInit } from '@angular/core';
import { PaymentService,SeatService } from '../services';

@Component({
  selector: 'app-ticket',
  templateUrl: './ticket.component.html',
  styleUrls: []
})
export class TicketComponent implements OnInit {

  constructor(public paymentService:PaymentService, public seatService:SeatService) { }

  ngOnInit(): void {
  }

}
