/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { PhoneNumberTypeService } from './phoneNumberType.service';

describe('Service: PhoneNumberType', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PhoneNumberTypeService]
    });
  });

  it('should ...', inject([PhoneNumberTypeService], (service: PhoneNumberTypeService) => {
    expect(service).toBeTruthy();
  }));
});
