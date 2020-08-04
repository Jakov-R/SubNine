import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Club } from '../club';
import { ClubService } from '../club.service';

@Component({
  selector: 'app-club-detail',
  templateUrl: './club-detail.component.html',
  styleUrls: ['./club-detail.component.scss']
})
export class ClubDetailComponent implements OnInit {

  constructor(
    private activatedRoute: ActivatedRoute,
    private clubService: ClubService
  ) { }

  id: number;
  club: Club;

  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe(params => {
        this.id = +params.get('id');
        this.loadClub(this.id);
    });
  }

  loadClub(id): void {
    this.clubService
      .getClub(id)
      .subscribe(p => {
        this.club = p;
      });
  }
}
