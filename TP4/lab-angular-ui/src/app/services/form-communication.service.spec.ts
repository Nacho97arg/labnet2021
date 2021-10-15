import { TestBed } from '@angular/core/testing';

import { FormCommunicationService } from './form-communication.service';

describe('FormCommunicationService', () => {
  let service: FormCommunicationService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FormCommunicationService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
