import { TestBed, inject } from '@angular/core/testing';

import { FurntureService } from './furnture.service';

describe('FurntureService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [FurntureService]
    });
  });

  it('should be created', inject([FurntureService], (service: FurntureService) => {
    expect(service).toBeTruthy();
  }));
});
