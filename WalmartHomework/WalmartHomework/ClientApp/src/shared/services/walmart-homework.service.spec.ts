import { TestBed, inject } from '@angular/core/testing';

import { WalmartHomeworkService } from './walmart-homework.service';

describe('WalmartHomeworkService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [WalmartHomeworkService]
    });
  });

  it('should be created', inject([WalmartHomeworkService], (service: WalmartHomeworkService) => {
    expect(service).toBeTruthy();
  }));
});
