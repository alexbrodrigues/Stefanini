import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ModalModule,  } from 'ngx-bootstrap/modal';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { ToastrModule } from 'ngx-toastr';

import { PersonService } from './_services/Person.service';

import { AppComponent } from './app.component';
import { PersonComponent } from './person/person.component';
import { PersonphoneComponent } from './personphone/personphone.component';
import { PhonenumbertypeComponent } from './phonenumbertype/phonenumbertype.component';
import { NavComponent } from './nav/nav.component';

import { AuthInterceptor } from './auth/auth.interceptor';
import { AppRoutingModule } from './/app-routing.module';
import { RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';




@NgModule({
  declarations: [AppComponent, PersonComponent, PhonenumbertypeComponent, PersonphoneComponent, NavComponent, DashboardComponent],
  imports: [AppRoutingModule, BrowserModule, HttpClientModule, FormsModule, BrowserAnimationsModule, ReactiveFormsModule,
    ToastrModule.forRoot({timeOut: 10000, positionClass: 'toast-bottom-right', preventDuplicates: true}),
     BsDropdownModule.forRoot(), TooltipModule.forRoot(), ModalModule.forRoot(), TabsModule.forRoot()],
  providers: [PersonService, {provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true}],
  bootstrap: [AppComponent],
})
export class AppModule { }
