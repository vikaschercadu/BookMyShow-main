import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { City } from '../models';

@Injectable({
	providedIn: 'root'
})
export class CityService {

	cities:City[]=[];
	cityChosenId!:number;
	private apiUrl="https://localhost:44319/api/city";
	constructor(private httpClient:HttpClient) { }

	httpOptions = {
		headers: new HttpHeaders({
			'Content-Type': 'application/json'
		})
	}

	getCities():Observable<City[]>{
		return this.httpClient.get<City[]>(this.apiUrl+'/all');
	}

	setCityId(city:number){
		this.cityChosenId=city;
	}

	getCityId(){
		return this.cityChosenId;
	}
}
