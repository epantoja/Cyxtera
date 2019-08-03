import { AlertifyService } from './../Servicios/Alertify.service';
import { LoginService } from './../Servicios/Login.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  
  constructor(public loginService: LoginService, 
    private alertifyService : AlertifyService) { }

  ngOnInit() {
  }

  loguear() {
    this.loginService.login().subscribe(login => {
    }, error => {
      this.alertifyService.error(error);
    });
  }

  logout() {
    this.loginService.userToken = null;
    localStorage.removeItem("token");
    this.alertifyService.message("Chao, vuelve pronto");
  }

}
