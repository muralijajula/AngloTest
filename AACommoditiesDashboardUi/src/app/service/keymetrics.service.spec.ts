import { TestBed } from '@angular/core/testing';

import { KeymetricsService } from './keymetrics.service';

describe('KeymetricsService', () => {
  let service: KeymetricsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(KeymetricsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
