import { Component, OnInit } from '@angular/core';
import { ClubService } from '../club.service';

import { Club } from '../club';

@Component({
  selector: 'app-club-list',
  templateUrl: './club-list.component.html',
  styleUrls: ['./club-list.component.scss']
})
export class ClubListComponent implements OnInit {

  clubs: Club[] = [];

  constructor(
    private clubService: ClubService
  ) { }

  ngOnInit(): void {
    this.clubService.getClubs({}).subscribe(result => {
      this.clubs = result;
    });
  }

}
