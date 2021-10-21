import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Person } from '../_models/Person';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PersonService {

  baseURL = 'http://localhost:5000/api/person';

  constructor(private http: HttpClient) { }

  getAllPerson(): Observable<Person[]> {
    return this.http.get<Person[]>(this.baseURL);
  }

  getPersonByTema(tema: string): Observable<Person[]> {
    return this.http.get<Person[]>(`${this.baseURL}/getByTema/${tema}`);
  }

  getPersonById(id: number): Observable<Person> {
    return this.http.get<Person>(`${this.baseURL}/${id}`);
  }

  postEvento(person: Person): Observable<Person> {
    return this.http.post<Person>(this.baseURL, person);
  }

  putPerson(person: Person): Observable<Person> {
    return this.http.put<Person>(`${this.baseURL}/${person.businessEntityID}`, person);
  }

  deletePerson(id: number) {
    return this.http.delete(`${this.baseURL}/${id}`);
  }

}
