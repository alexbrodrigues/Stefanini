/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { PersonPhoneService } from './personPhone.service';

describe('Service: PersonPhone', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PersonPhoneService]
    });
  });

  it('should ...', inject([PersonPhoneService], (service: PersonPhoneService) => {
    expect(service).toBeTruthy();
  }));
});
