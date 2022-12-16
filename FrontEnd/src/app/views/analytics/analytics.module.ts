import { NgModule } from '@angular/core';

import { AnalyticsComponent } from './analytics.component';
import { AnalyticsRoutingModule } from './analytics-routing.module';
import { TranslateModule } from '@ngx-translate/core'

@NgModule({
  imports: [
    AnalyticsRoutingModule,
    TranslateModule
  ],
  declarations: [ AnalyticsComponent ]
})
export class AnalyticsModule { }
