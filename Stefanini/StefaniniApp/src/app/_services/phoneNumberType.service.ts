import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PhoneNumberType } from '../_models/PhoneNumberType';

@Injectable({
  providedIn: 'root'
})
export class PhoneNumberTypeService {
  baseURL = 'http://localhost:5000/api/phonenumbertype';

  constructor(private http: HttpClient) { }

  getAllPhoneNumberType(): Observable<PhoneNumberType[]> {
    return this.http.get<PhoneNumberType[]>(this.baseURL);
  }
}
