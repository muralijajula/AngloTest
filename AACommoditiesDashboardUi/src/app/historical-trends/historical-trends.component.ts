import { Component, OnInit } from '@angular/core';
import * as Highcharts from 'highcharts';
import { HistorictrendsService } from '../service/historictrends.service';
import { HistoricPnldailey } from '../types/historic-pnldailey';

@Component({
  selector: 'app-historical-trends',
  templateUrl: './historical-trends.component.html',
  styleUrls: ['./historical-trends.component.scss']
})
export class HistoricalTrendsComponent implements OnInit {

  highcharts = Highcharts;

  constructor(private historictrendsService: HistorictrendsService) { }

  ngOnInit() {
    this.historictrendsService
      .getHistoricPnlYearly()
      .subscribe(x => this.populateTableData(x));

  }
  private populateTableData(metric: HistoricPnldailey): void {
    this.buildChart(metric);
  }
  private buildChart(metric: HistoricPnldailey): void {
    chartOptions: Highcharts.chart('historic-trend', {
      title: {
        text: "Yearly Pnl Per Commodity"
      },
      chart: {
        type: 'column',
        
      },
      xAxis: {
        title: {
          text: 'Commodity'
        },
        categories: metric.dates
      },
      yAxis: {
        title: {
          text: "Pnl"
        }
      },
      plotOptions: {
        series: {
          cursor: 'pointer',
          events: {
            click:  (e)=> {
              this.buildAreaChart(e.point.series.name,e.point.category);

            }
          }
        }
      },
      series: metric.historicPnl,
      drilldown: {
        series: []
    }
    });

  }


  private buildAreaChart( commodity:string, date:string): void {
    this.historictrendsService
      .getHistoricPnlDaily(commodity, date)
      .subscribe(x => {
        chartOptions: Highcharts.chart('historic-trend-one', {
          title: {
            text: "Historical Pnl for Selected Commidity of the year"
          },
          chart: {
            type: 'area'
          },
          xAxis: {
            title: {
              text: 'Commodity'
            },
            categories: x.dates
          },
          yAxis: {
            title: {
              text: "Pnl"
            }
          },
          plotOptions: {
            series: {
              cursor: 'pointer',
              events: {
                click: function (event) {
                  alert(
                    this.name + ' clicked\n'

                  );
                }
              }
            }
          },
          series: x.historicPnl
        });
      }
      );

  }

}
