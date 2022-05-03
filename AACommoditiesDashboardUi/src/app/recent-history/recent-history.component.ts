import { AfterViewInit, Component, OnInit,ViewChild } from '@angular/core';
import {CommoditiesService} from '../service/commodities.service'
import { CommodityRecentHistory } from '../types/commodity-recent-history';
import {MatSort, Sort} from '@angular/material/sort';
import {MatTableDataSource} from '@angular/material/table';

@Component({
  selector: 'app-recent-history',
  templateUrl: './recent-history.component.html',
  styleUrls: ['./recent-history.component.scss']
})
export class RecentHistoryComponent implements OnInit {

  elements:any = [];
  dataSource:MatTableDataSource<any>= new MatTableDataSource<any>([]);
  displayedColumns: string[] = ['model', 'commodity', 'date', 'newTradeAction', 'price', 'position', 'pnlDaily'];
  

  constructor(private commoditiesService: CommoditiesService) { }

  ngOnInit() {
    this.commoditiesService
        .getRecentHistory()
        .subscribe(x => this.populateTableData(x));
    
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
  

  private populateTableData(history: CommodityRecentHistory[]): void {
    this.elements = [];
    history.forEach(x => x.dataPoints.forEach(o => this.elements.push({
      model: x.model,
      commodity: x.commodity,
      date: o.date,
      newTradeAction: o.newTradeAction,
      price: o.price,
      position: o.position,
      pnlDaily: o.pnlDaily
    })));
    this.dataSource = new MatTableDataSource(this.elements);
    this.dataSource.filterPredicate = function(data, filter: string): boolean {
      return data.model.toLowerCase().includes(filter) || data.commodity.toLowerCase().includes(filter) || data.newTradeAction.toString() === filter;
 };
    
  }

  
}
