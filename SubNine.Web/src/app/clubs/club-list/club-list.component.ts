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

  searchText: string;

  constructor(
    private clubService: ClubService
  ) { }

  ngOnInit(): void {
    this.loadClubs();
  }

  search(text): void {
    // this.loadClubs({ search: text });
  }

  loadClubs(params = {}): void {
    this.clubService
      .getClubs(params)
      .subscribe(c => {
        this.clubs = c;
      });
      //callback
  }

}
