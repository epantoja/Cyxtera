import { BsModalService } from 'ngx-bootstrap/modal';
import { LoginService } from './Servicios/Login.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { AgregarValorComponent } from './agregar-valor/agregar-valor.component';
import { HistorialComponent } from './historial/historial.component';
import { ResultadosComponent } from './resultados/resultados.component';
import { TableroComponent } from './tablero/tablero.component';
import { AlertifyService } from './Servicios/Alertify.service';
import { HttpModule } from '@angular/http';
import { JwtModule } from '@auth0/angular-jwt';
import { environment } from 'src/environments/environment';
import { OperacionesService } from './Servicios/Operaciones.service';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ErrorInterceptor } from './helpers/error.interceptor';
import { JwtInterceptor } from './helpers/jtw.JwtInterceptor';
import { ModalModule } from 'ngx-bootstrap';

export function tokenGetter() {
  return localStorage.getItem(environment.token);
}

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    AgregarValorComponent,
    HistorialComponent,
    ResultadosComponent,
    TableroComponent
  ],
  imports: [
    HttpModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ModalModule.forRoot(),
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        whitelistedDomains: [environment.apiUrl],
        blacklistedRoutes: [],
        headerName: environment.token,
        authScheme: '',
        skipWhenExpired : true
      }
    }),
  ],
  providers: [
    AlertifyService,
    LoginService,
    OperacionesService,
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
