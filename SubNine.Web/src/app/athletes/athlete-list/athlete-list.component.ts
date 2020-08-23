import { Component, OnInit } from '@angular/core';
import { AthleteListResponse } from './athlete-list.response';
import { AthleteService } from '../athlete.service';

@Component({
  selector: 'app-athlete-list',
  templateUrl: './athlete-list.component.html',
  styleUrls: ['./athlete-list.component.scss']
})
export class AthleteListComponent implements OnInit {
  vm: AthleteListResponse = { page: 1 } as AthleteListResponse;
  searchText?: string;

  constructor(
    private athleteService: AthleteService
  ) { }

  ngOnInit(): void {
    this.loadAthletes();
  }

  loadAthletes() {
    let params: any = { page: this.vm?.page || 1};
    if(this.searchText){ params.search = this.searchText; }
    
    this.athleteService
      .getAthletes(params)
      .subscribe(response => {
        this.vm = response;
      });
  }

}