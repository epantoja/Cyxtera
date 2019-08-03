import { AlertifyService } from './../Servicios/Alertify.service';
import { LoginService } from './../Servicios/Login.service';
import { Component, OnInit, ViewChild, ViewChildren, Output, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';
import { ResultadosComponent } from '../resultados/resultados.component';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  
  @Output() listarValores = new EventEmitter();

  constructor(public loginService: LoginService, 
    private alertifyService : AlertifyService,
    private router: Router) { }

  ngOnInit() {
  }

  nuevaLogueo () {
    this.loginService.login().subscribe(login => {
      this.alertifyService.success("Nueva sesion de calculadora");
      this.listarValores.emit({parametro: "listar"});
    }, error => {
      this.alertifyService.error(error);
    });
  }

  logueo () {
    this.loginService.login().subscribe(login => {
      this.alertifyService.success("Iniciando calculadora");
    }, error => {
      this.alertifyService.error(error);
    });
  }

  salir() {
    this.loginService.userToken = null;
    localStorage.removeItem("token");
    this.alertifyService.message("vuelve pronto");
  }

}
