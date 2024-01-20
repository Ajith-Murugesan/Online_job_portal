import { TestBed } from '@angular/core/testing';

import { EducationaldetailsService } from './educationaldetails.service';

describe('EducationaldetailsService', () => {
  let service: EducationaldetailsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EducationaldetailsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
