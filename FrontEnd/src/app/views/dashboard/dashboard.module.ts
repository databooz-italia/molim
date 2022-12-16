import { NgModule } from '@angular/core';

import { DashboardComponent } from './dashboard.component';
import { DashboardRoutingModule } from './dashboard-routing.module';
import { TranslateModule } from '@ngx-translate/core'

@NgModule({
  imports: [
    DashboardRoutingModule,
    TranslateModule
  ],
  declarations: [ DashboardComponent ]
})
export class DashboardModule { }
