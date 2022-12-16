import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  templateUrl: 'analytics.component.html'
})
export class AnalyticsComponent {
  constructor(private router: Router)
  {

  }  

  goToPatients()
  {
    this.router.navigate(['/patients']);
  }
}
