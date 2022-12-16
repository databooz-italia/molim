import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { PatientsMasterComponent } from './patients.component';

const routes: Routes = [
  {
    path: '',
    component: PatientsMasterComponent,
    data: {
      title: 'Pazienti'
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PatientsRoutingModule {}
