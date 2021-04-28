import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { City } from '../models';
import { CityService } from '../services';
import { AuthService } from '../auth'

@Component({
	selector: 'app-city',
	templateUrl: './city.component.html',
	styles: [
	]
})
export class CityComponent implements OnInit {

	cities!: City[];
	city: City = new City({});
	cityId!: number;

	constructor(public cityService: CityService, public router: Router, public authService: AuthService) { }

	ngOnInit(): void {
		this.cityService.getCities().subscribe(res => {
			this.cities = res;
		})
	}

	selected() {
		this.cityService.setCityId(this.cityId);
		this.router.navigate(['movies']);
	}
}
