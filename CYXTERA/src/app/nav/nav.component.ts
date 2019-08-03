import { AlertifyService } from './../Servicios/Alertify.service';
import { LoginService } from './../Servicios/Login.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  
  constructor(public loginService: LoginService, 
    private alertifyService : AlertifyService,
    private router: Router) { }

  ngOnInit() {
  }

  nuevaLogueo () {
    this.loginService.login().subscribe(login => {
      this.alertifyService.success("Nueva sesion de calculadora");
      this.router.navigate(["/tablero"]);
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
