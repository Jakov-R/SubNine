import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ClubService } from '../club.service';
import { Club } from '../club';
import { Athlete } from 'src/app/athletes/athlete';

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

  id!: number;
  club!: Club;

  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe(params => {
      this.id = Number(params.get('id'));
      this.loadClub();
    });
  }

  loadClub() {
    this.clubService.getClub(this.id).subscribe(result => {
      this.club = result;
    });
  }

}
