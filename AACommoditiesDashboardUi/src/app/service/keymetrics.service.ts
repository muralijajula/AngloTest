import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { CommodityPriceMetric } from '../types/commodity-price-metric';
import { ModelPnlMetric } from '../types/model-pnl-metric';
import { CommodityPriceMetricDto } from '../types/Dtos/CommodityPriceMetricDto';
import { ModelPnlMetricDto } from '../types/Dtos/ModelPnlMetricDto';

@Injectable({
  providedIn: 'root'
})
export class KeymetricsService {

  constructor(protected http: HttpClient) {}

  public getCommodityPriceByRange(): Observable<CommodityPriceMetric> {
    const url = `${environment.commoditiesApi}/KeyMetrics/commodity-price`;
    return this.http
               .get<CommodityPriceMetricDto[]>(url)
               .pipe(map((x) => {
                   return <CommodityPriceMetric>{
                     dates: this.mapuniqueDates(x),
                     commodityPriceSeries:this.buildCommodityPriceSeries(x,this.mapuniqueCommodities(x))
                   }
               }));
  }

  public getModelPnlByRange(): Observable<ModelPnlMetric> {
    const url = `${environment.commoditiesApi}/KeyMetrics/model-pnl`;
    return this.http
               .get<ModelPnlMetricDto[]>(url)
               .pipe(map((x) => {
                   return <ModelPnlMetric>{
                     dates: this.mapuniqueDates(x),
                     modelPnlSeries:this.buildModelPnlSeries(x,this.mapuniqueModels(x))
                   }
               }));
  }

  private mapuniqueDates(data: any[]): string[] {
    return data.map(o => o.date)
           .filter((value, index, self) => self.indexOf(value) === index)
  }
  private mapuniqueModels(data: any[]): string[] {
    return data.map(o => o.model)
           .filter((value, index, self) => self.indexOf(value) === index)
  }

  private mapuniqueCommodities(data: any[]): string[] {
    return data.map(o => o.commodity)
           .filter((value, index, self) => self.indexOf(value) === index)
  }

  private buildCommodityPriceSeries(data:CommodityPriceMetricDto[],commodities:string[]):any[]{
    let series:any[]=[];
   commodities.forEach(x=>{
    let points:number[] = data.filter(y=>y.commodity == x).map((o=>o.price));
    series.push({name:x,data:points})
   });

   return series;
   
  }

  private buildModelPnlSeries(data:ModelPnlMetricDto[],commodities:string[]):any[]{
    let series:any[]=[];
   commodities.forEach(x=>{
    let points:number[] = data.filter(y=>y.model == x).map((o=>o.pnl));
    series.push({name:x,data:points})
   });

   return series;
   
  }


}
