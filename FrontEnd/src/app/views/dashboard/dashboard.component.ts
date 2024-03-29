import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  templateUrl: 'dashboard.component.html'
})
export class DashboardComponent {
  constructor(private router: Router)
  {

  }
  goToPatients()
  {
    this.router.navigate(['/patients']);
  }

  goToAnalytics()
  {
    this.router.navigate(['/analytics']);
  }
}
