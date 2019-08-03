import { AlertifyService } from './../Servicios/Alertify.service';
import { ValoresService } from './../Servicios/Valores.service';
import { Valor } from './../Model/Valor';
import { HistorialComponent } from './../historial/historial.component';
import { LoginService } from './../Servicios/Login.service';
import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { ResultadosComponent } from '../resultados/resultados.component';

import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';


@Component({
  selector: 'app-tablero',
  templateUrl: './tablero.component.html',
  styleUrls: ['./tablero.component.css']
})
export class TableroComponent implements OnInit {

  listaValores: Valor[] = [] as Valor[];
  @ViewChild(ResultadosComponent) resultados: ResultadosComponent;
  @ViewChild(HistorialComponent) historial: HistorialComponent;
  modalRef: BsModalRef;

  constructor(public loginService: LoginService,
    private valoresService: ValoresService,
    private alertifyService: AlertifyService,
    private modalService: BsModalService) { 
    }

  ngOnInit() {
  }

  listarLosValores(parametro: any) {
    this.resultados.listarValores();
    this.historial.listarHistorico();
  }

  openModal(historicoId: any, template: TemplateRef<any>) {
    this.valoresService.obtenerHistorial(historicoId.historicoId).subscribe(
    lista => {
      this.listaValores = lista;
      this.modalRef = this.modalService.show(template);
    },
    error => {
      this.alertifyService.error(error);
    });
  }
}
