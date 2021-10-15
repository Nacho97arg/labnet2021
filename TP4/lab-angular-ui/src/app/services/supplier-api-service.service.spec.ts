import { TestBed } from '@angular/core/testing';

import { SupplierApiService } from './supplier-api-service.service';

describe('SupplierApiServiceService', () => {
  let service: SupplierApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SupplierApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
