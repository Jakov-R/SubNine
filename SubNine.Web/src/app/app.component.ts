import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'web';

  constructor(
    private router: Router
  ) {}

  onLogout() {
    localStorage.clear();
    this.router.navigate(['auth/login']);
    setTimeout(() => { window.location.reload(); }, 100);
  }
}
