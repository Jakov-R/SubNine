import { Component, OnInit } from '@angular/core';
import { Athlete } from '../athlete';
import { AthleteService } from '../athlete.service';

import { ClubService } from '../../clubs/club.service';
import { Club } from '../../clubs/club';

import { CountryService } from '../../countries/country.service';
import { Country } from '../../countries/country';

import { Router, ActivatedRoute } from '@angular/router';
import { LoadingService } from '../../shared/loading/loading.service';
import { ToastrService } from 'ngx-toastr';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import * as jsonPatch from 'fast-json-patch';



@Component({
  selector: 'app-athlete-form',
  templateUrl: './athlete-form.component.html',
  styleUrls: ['./athlete-form.component.scss']
})
export class AthleteFormComponent implements OnInit {

  id: number = 0;

  athleteForm = this.fb.group({
    id: [''],
    fullName: [''],
    yearsOld: ['', Validators.required],
    clubId: ['', Validators.required],
    countryId: ['', Validators.required]
  });

  errors: any = {};

  clubs?: Club[];
  countries?: Country[];

  constructor(
    private athleteService: AthleteService,
    private clubService: ClubService,
    private countryService: CountryService,
    private loadingService: LoadingService,
    private router: Router,
    private toastr: ToastrService,
    private activatedRoute: ActivatedRoute,
    private fb: FormBuilder
  ) { }

  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe(params => {
      this.id = Number(params.get('id'));
      this.loadAthlete();
    });

    this.loadCities();
    this.loadCountries();
  }

  onSubmit() {
    this.loadingService.show();
    let newAthlete = this.athleteForm.value;

    return this.athleteService.saveAthlete(newAthlete)
      .subscribe(
        result => this.onAthleteSave(result),
        result => this.onError(result.error)
      );
  }

  onError(response: any) {
    this.errors = response.errors;
  }

  onAthleteSave(result: Athlete) {
    /* hide loading gif */
    this.loadingService.hide();
    this.toastr.success('Success');

    /* redirect */
    let athleteId = result.id;
    this.router.navigate(['athletes/' + athleteId]);
  }

  loadCities() {
    this.clubService
      .getClubs()
      .subscribe(result => this.clubs = result)
  }

  loadCountries() {
    this.countryService
      .getCountries()
      .subscribe((result: any) => this.countries = result)
  }

  loadAthlete() {
    if(!this.id) { return; }
    this.athleteService.getAthlete(this.id)
        .subscribe(athlete => {
          this.athleteForm.patchValue(athlete);
        });
  }

}