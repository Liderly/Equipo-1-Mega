import { TestBed } from '@angular/core/testing';

import { DataServiceService } from './data-service.service';

describe('SendDataService', () => {
  let service: DataServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DataServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
