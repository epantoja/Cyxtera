import { AlertifyService } from './../Servicios/Alertify.service';
import { Component, OnInit } from '@angular/core';
import { ValoresService } from '../Servicios/Valores.service';
import { Usuario } from '../Model/Usuario';

@Component({
  selector: 'app-historial',
  templateUrl: './historial.component.html',
  styleUrls: ['./historial.component.css']
})
export class HistorialComponent implements OnInit {

  listaHitorico: Usuario[] = [] as Usuario[];

  constructor(private valoresService: ValoresService,
    private alertifyService: AlertifyService) { }

  ngOnInit() {
    this.listarHistorico();
  }

  listarHistorico() {
    this.valoresService.listarHistorial().subscribe(
      lista => {
        this.listaHitorico = lista;
      },
      error => {
        this.alertifyService.error(error);
      }
    );
  }

}
