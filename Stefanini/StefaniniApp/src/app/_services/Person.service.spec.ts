/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { PersonService } from './Person.service';

describe('Service: Person', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PersonService]
    });
  });

  it('should ...', inject([PersonService], (service: PersonService) => {
    expect(service).toBeTruthy();
  }));
});
