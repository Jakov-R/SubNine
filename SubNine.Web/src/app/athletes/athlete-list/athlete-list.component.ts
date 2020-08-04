import { Component, OnInit } from '@angular/core';
import { AthleteService } from '../athlete.service';
import { Athlete } from '../athlete';


@Component({
  selector: 'app-athlete-list',
  templateUrl: './athlete-list.component.html',
  styleUrls: ['./athlete-list.component.scss']
})
export class AthleteListComponent implements OnInit {

  athletes: Athlete[] = [];

  searchText: string;

  constructor(
    private athleteService: AthleteService
  ) { }

  ngOnInit(): void {
    this.loadAthletes();
  }

  search(text): void {
    this.loadAthletes({ search: text });
  }

  loadAthletes(params = {}): void {
    this.athleteService
      .getAthletes(params)
      .subscribe((p: any) => {
        this.athletes = p;
      });
      //callback
  }

}
