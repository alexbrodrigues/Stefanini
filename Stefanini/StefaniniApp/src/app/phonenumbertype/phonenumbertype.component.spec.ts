/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { PhonenumbertypeComponent } from './phonenumbertype.component';

describe('PhonenumbertypeComponent', () => {
  let component: PhonenumbertypeComponent;
  let fixture: ComponentFixture<PhonenumbertypeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PhonenumbertypeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PhonenumbertypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
