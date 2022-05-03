import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HistoricalTrendsComponent } from './historical-trends/historical-trends.component';
import { KeyMetricsComponent } from './key-metrics/key-metrics.component';
import { RecentHistoryComponent } from './recent-history/recent-history.component';

const routes: Routes = [
  {
    path: 'recent-history',
    component: RecentHistoryComponent
  },{
    path: 'key-metrics',
    component: KeyMetricsComponent
  }
  ,{
    path: 'historical-trends',
    component: HistoricalTrendsComponent
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
