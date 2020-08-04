import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AthleteService } from '../athlete.service';
import { Athlete } from '../athlete';

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

  id: number;
  athlete: Athlete;

  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe(params => {
        this.id = +params.get('id');
        this.loadAthlete(this.id);
    });
  }

  loadAthlete(id): void {
    this.athleteService
      .getAthlete(id)
      .subscribe(a => this.athlete = a);
  }

  onDelete(id) {
    this.athleteService.deleteAthlete(id).subscribe(_ => null);
  }

  onEnter(id) {
    alert("Brisem s idem " + id);
  }
}
