import { LoginService } from './../Servicios/Login.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-tablero',
  templateUrl: './tablero.component.html',
  styleUrls: ['./tablero.component.css']
})
export class TableroComponent implements OnInit {

  constructor(public loginService: LoginService) { }

  ngOnInit() {
  }

}
