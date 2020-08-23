import { Component, OnInit } from '@angular/core';
import { Athlete } from '../athlete';
import { AthleteService } from '../athlete.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-athlete-detail',
  templateUrl: './athlete-detail.component.html',
  styleUrls: ['./athlete-detail.component.scss']
})
export class AthleteDetailComponent implements OnInit {

  constructor(
    private activatedRoute: ActivatedRoute,
    private athleteService: AthleteService
  ) { }

  id!: number;
  athlete!: Athlete;



  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe(params => {
        this.id = Number(params.get('id'));
        this.loadAthlete();
    });
  }

  loadAthlete() {
    this.athleteService
    .getAthlete(this.id)
    .subscribe(result => {
      this.athlete = result;
    });
  }

}


//TODO POPRAVI ID NULL