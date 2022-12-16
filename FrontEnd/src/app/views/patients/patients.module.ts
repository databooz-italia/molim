import { NgModule } from '@angular/core';

import { PatientsMasterComponent } from './patients.component';
import { PatientsRoutingModule } from './patients-routing.module';
import { TranslateModule } from '@ngx-translate/core';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { CommonModule, DatePipe } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { NgbNavModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxSpinnerModule } from 'ngx-spinner'

@NgModule({
  imports: [
    PatientsRoutingModule,
    TranslateModule,
    NgxDatatableModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NgbNavModule,
    NgxSpinnerModule
  ],
  providers: [DatePipe],
  declarations: [ PatientsMasterComponent ]
})
export class PatientsModule { }
