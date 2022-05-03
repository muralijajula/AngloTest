import { Component, OnInit } from '@angular/core';
import * as Highcharts from 'highcharts';
import { KeymetricsService } from '../service/keymetrics.service';
import { CommodityPriceMetric } from '../types/commodity-price-metric';
import { ModelPnlMetric } from '../types/model-pnl-metric';

@Component({
  selector: 'app-key-metrics',
  templateUrl: './key-metrics.component.html',
  styleUrls: ['./key-metrics.component.scss']
})
export class KeyMetricsComponent implements OnInit {

  highcharts = Highcharts;
  constructor(private keymetricsService: KeymetricsService) { }

  ngOnInit() {
    this.keymetricsService
        .getCommodityPriceByRange()
        .subscribe(x =>  this.buildCommodityPriceMetricChart(x));

    this.keymetricsService
        .getModelPnlByRange()
        .subscribe(x => this.buildModelPnlMetricChart(x));
    
  }
 
   private buildCommodityPriceMetricChart(metric: CommodityPriceMetric):void {
    chartOptions: Highcharts.chart('chart-line', {
      title: {
        text: "Average Monthly Price Per Commodity"
      },
      xAxis: {
        title: {
          text: 'Commodity'
        },
        categories:metric.dates
      },
      yAxis: {
        title: {
          text: "Price"
        }
      },
      series: metric.commodityPriceSeries
    });
    
  }

  private buildModelPnlMetricChart(metric: ModelPnlMetric):void {
    chartOptions: Highcharts.chart('chart-line1', {
      title: {
        text: "Average Monthly Pnl Per Model"
      },
      xAxis: {
        title: {
          text: 'Model'
        },
        categories:metric.dates
      },
      yAxis: {
        title: {
          text: "Pnl"
        }
      },
      series: metric.modelPnlSeries
    });
    
  }


    

  
}
