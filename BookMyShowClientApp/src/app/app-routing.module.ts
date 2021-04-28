import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CityComponent } from './city';
import { LoginComponent,UserComponent,RegistrationComponent } from './user';
import { MovieDetailsComponent,MoviesComponent } from './movies';
import { PaymentComponent } from './payment';
import { SeatComponent } from './seat';
import { AuthGuardGuard } from './auth';
import { TheatreComponent } from './theatre';
import { TicketComponent } from './ticket';

const routes: Routes = [
	{ path: '', redirectTo: '/city', pathMatch: 'full' },
	{path:'city', component:CityComponent},
	{path:'movies', component:MoviesComponent},
	{path:'movie-details/:id', component:MovieDetailsComponent},
	{path:'theatre',component:TheatreComponent},
	{path:'seat/:id/:id2',component:SeatComponent},
	{path:'user',component:UserComponent,
		children:[
		{path:'', pathMatch: 'full', redirectTo: 'login'},
		{path:'login', component:LoginComponent},
		{path:'register',component:RegistrationComponent}
		]
	},
	{ path: 'payment', component: PaymentComponent, canActivate : [AuthGuardGuard] },
	{path:'showTicket',component:TicketComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
