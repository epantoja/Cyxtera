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
    LoginService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
