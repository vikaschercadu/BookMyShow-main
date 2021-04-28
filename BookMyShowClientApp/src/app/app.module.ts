import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ModalModule } from 'ngx-bootstrap/modal';
import { ToastrModule } from 'ngx-toastr';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MoviesComponent, MovieDetailsComponent } from './movies';
import { TheatreComponent } from './theatre';
import { CityComponent } from './city';
import { CityService, LoginService,TheatreService,MovieService,SeatService } from './services';
import { AuthService, AuthGuardGuard, AuthInterceptor} from './auth'
import { SeatComponent } from './seat';
import { PaymentComponent } from './payment';
import { TicketComponent } from './ticket';
import { UserComponent, LoginComponent, RegistrationComponent } from './user';

@NgModule({
  declarations: [
    AppComponent,
    MoviesComponent,
    MovieDetailsComponent,
    TheatreComponent,
    CityComponent,
    SeatComponent,
    LoginComponent,
    PaymentComponent,
    TicketComponent,
    UserComponent,
    RegistrationComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    BsDropdownModule.forRoot(),
    ToastrModule.forRoot({
      timeOut: 3000,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
      progressBar:true
    }),
    ModalModule.forRoot()
  ],
  providers: [CityService,AuthService,AuthGuardGuard,LoginService,TheatreService,MovieService,SeatService,{
    provide:HTTP_INTERCEPTORS,
    useClass:AuthInterceptor,
    multi:true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
