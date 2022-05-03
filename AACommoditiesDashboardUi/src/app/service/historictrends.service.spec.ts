import { TestBed } from '@angular/core/testing';

import { HistorictrendsService } from './historictrends.service';

describe('HistorictrendsService', () => {
  let service: HistorictrendsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HistorictrendsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
