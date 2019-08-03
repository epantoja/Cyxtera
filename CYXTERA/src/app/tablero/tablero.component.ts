import { HistorialComponent } from './../historial/historial.component';
import { LoginService } from './../Servicios/Login.service';
import { Component, OnInit, ViewChild } from '@angular/core';
import { ResultadosComponent } from '../resultados/resultados.component';

@Component({
  selector: 'app-tablero',
  templateUrl: './tablero.component.html',
  styleUrls: ['./tablero.component.css']
})
export class TableroComponent implements OnInit {

  @ViewChild(ResultadosComponent) resultados: ResultadosComponent;
  @ViewChild(HistorialComponent) historial: HistorialComponent;

  constructor(public loginService: LoginService) { }

  ngOnInit() {
  }

  listarLosValores(parametro: any) {
    this.resultados.listarValores();
    this.historial.listarHistorico();
  }
}
