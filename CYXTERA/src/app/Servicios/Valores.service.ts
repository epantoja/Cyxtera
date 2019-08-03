import { Valor } from './../Model/Valor';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ValoresService {

  baseUrl = environment.apiUrl + "Valor/";

  constructor(private http: HttpClient) { }

  registrarValor(valor: Valor): Observable<boolean> {
    return this.http
      .post(this.baseUrl + "RegistrarValor", valor)
      .map(response => <boolean>response);
  }

  listarValores(): Observable<Valor[]> {
    return this.http
      .get(this.baseUrl + "ListarValores")
      .map(response => <Valor[]>response);
  }


}
