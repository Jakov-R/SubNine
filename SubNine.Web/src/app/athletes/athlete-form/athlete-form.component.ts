import { Component, OnInit } from '@angular/core';
import { Athlete } from '../athlete';
import { AthleteService } from '../athlete.service';

import { ClubService } from '../../clubs/club.service';

import { Club } from '../../clubs/club';
import { Router } from '@angular/router';
import { LoadingService } from '../../shared/loading/loading.service';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-athlete-form',
  templateUrl: './athlete-form.component.html',
  styleUrls: ['./athlete-form.component.scss']
})
export class AthleteFormComponent implements OnInit {

  athlete: Athlete = {} as Athlete;
  clubs?: Club[];

  constructor(
    private athleteService: AthleteService,
    private clubService: ClubService,
    private loadingService: LoadingService,
    private router: Router,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
    this.loadCities();
  }

  onSubmit() {
    this.loadingService.show();
    this.athleteService
      .postAthlete(this.athlete)
      .subscribe(result => {
        this.loadingService.hide();
        this.toastr.success('Success');
        let athleteId = result.id;
        this.router.navigate(['athletes/' + athleteId]);
      });
  }

  loadCities() {
    this.clubService
      .getClubs()
      .subscribe(result => this.clubs = result)
  }

}
