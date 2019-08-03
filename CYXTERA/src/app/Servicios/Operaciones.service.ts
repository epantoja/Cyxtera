import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Valor } from '../Model/Valor';

@Injectable({
  providedIn: 'root'
})
export class OperacionesService {

  baseUrl = environment.apiUrl + "Operacion/";

  constructor(private http: HttpClient) { }


  sumarValores(): Observable<boolean> {
    return this.http
      .get(this.baseUrl + "Sumar")
      .map(response => <boolean>response);
  }

  restarValores(): Observable<boolean> {
    return this.http
      .get(this.baseUrl + "Restar")
      .map(response => <boolean>response);
  }

  MultiplicarValores(): Observable<boolean> {
    return this.http
      .get(this.baseUrl + "Multiplicar")
      .map(response => <boolean>response);
  }

  DividirValores(): Observable<boolean> {
    return this.http
      .get(this.baseUrl + "Dividir")
      .map(response => <boolean>response);
  }

  PotenciaValores(): Observable<boolean> {
    return this.http
      .get(this.baseUrl + "Potencia")
      .map(response => <boolean>response);
  }

}
