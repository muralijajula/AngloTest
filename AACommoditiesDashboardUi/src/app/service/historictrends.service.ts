import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { HistoricPnldailey } from '../types/historic-pnldailey';
import { HistoricPnlDailyDto } from '../types/Dtos/HistoricPnlDailyDto';

@Injectable({
  providedIn: 'root'
})
export class HistorictrendsService {

  constructor(protected http: HttpClient) {}

  public getHistoricPnlYearly(): Observable<HistoricPnldailey> {
    const url = `${environment.commoditiesApi}/HistoricalTrends/historical-pnl`;
    return this.getHistoricalPnlData(url);
  }
  public getHistoricPnlDaily(commodity:string, date:string): Observable<HistoricPnldailey> {
    const url = `${environment.commoditiesApi}/HistoricalTrends/historical-pnl/`+commodity+'/'+date;
    return this.getHistoricalPnlData(url);
  }
 
  private getHistoricalPnlData(url: string): Observable<HistoricPnldailey> {
    return this.http
      .get<HistoricPnlDailyDto[]>(url)
      .pipe(map((x) => {
        return <HistoricPnldailey>{
          dates: x.map(o => o.date)
            .filter((value, index, self) => self.indexOf(value) === index),
          historicPnl: this.buildhistoricSeries(x, this.mapuniqueCommodities(x))
        };
      }));
  }

  
  private mapuniqueCommodities(data: any[]): string[] {
    return data.map(o => o.commodity)
           .filter((value, index, self) => self.indexOf(value) === index)
  }
  
  private buildhistoricSeries(data:HistoricPnlDailyDto[],commodities:string[]):any[]{
    let series:any[]=[];
   commodities.forEach(x=>{
    let points:any[][] = data.filter(y=>y.commodity == x).map((o=>[o.pnlSum]));
    series.push({name:x,data:points})
   });

   return series;
   
  }

}
