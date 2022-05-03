import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HighchartsChartModule } from 'highcharts-angular';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatTableModule } from "@angular/material/table";
import {MatSortModule } from "@angular/material/sort";
import { MatPaginatorModule } from "@angular/material/paginator";
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { RecentHistoryComponent } from './recent-history/recent-history.component';
import { CommoditiesService } from '../app/service/commodities.service';
import { KeyMetricsComponent } from './key-metrics/key-metrics.component';
import { MomentDateModule } from '@angular/material-moment-adapter';
import { HistoricalTrendsComponent } from './historical-trends/historical-trends.component';
import { KeymetricsService } from './service/keymetrics.service';
import { HistorictrendsService } from './service/historictrends.service';

@NgModule({
  declarations: [
    AppComponent,
    RecentHistoryComponent,
    KeyMetricsComponent,
    HistoricalTrendsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HighchartsChartModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatFormFieldModule,
    MatInputModule,
    MomentDateModule
  ],
  providers: [CommoditiesService,KeymetricsService, HistorictrendsService],
  bootstrap: [AppComponent]
})
export class AppModule { }
