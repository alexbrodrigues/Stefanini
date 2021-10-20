/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { PersonphoneComponent } from './personphone.component';

describe('PersonphoneComponent', () => {
  let component: PersonphoneComponent;
  let fixture: ComponentFixture<PersonphoneComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PersonphoneComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PersonphoneComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
