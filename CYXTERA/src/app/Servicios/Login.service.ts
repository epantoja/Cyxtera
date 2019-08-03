import { Http, Headers, RequestOptions } from '@angular/http';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Injectable } from '@angular/core';
import { Observable } from "rxjs/Rx";
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  baseUrl = environment.apiUrl;
  userToken: any;
  decodedToken: any;
  jwtHelper: JwtHelperService = new JwtHelperService();

  constructor(private http: Http, private iniciadoSecion: JwtHelperService) { }

  login() {
    return this.http
      .get(this.baseUrl + "Usuario/Registrar",  this.requestOptions())
      .map(response => {
        const user = response.json();
        if (user) {
          localStorage.setItem(environment.token, user.tokenString);
          this.decodedToken = this.jwtHelper.decodeToken(user.tokenString);
          this.userToken = user.tokenString;
        }
      })
      .catch(this.handleError);
  }

  sesionIniciada() {
    return this.iniciadoSecion.isTokenExpired();
  }

  private requestOptions() {
    const headers = new Headers({ "Content-type": "application/json" });
    return new RequestOptions({ headers: headers });
  }

  private handleError (error: Response | any) {
    const applicationError = error.headers.get("Application-Error");
    if (applicationError) {
      return Observable.throw(applicationError);
    }
    
    if (error._body != undefined) {
      return Observable.throw(error._body);
    }

    const serverError = error.json();
    let modelStateError = "";
    if (serverError) {
      for (const key in serverError) {
        if (serverError[key]) {
          modelStateError += serverError[key] + "\n";
        }
      }
    }

    return Observable.throw(modelStateError || "Error del servidor");
  }

}
