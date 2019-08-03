import { AlertifyService } from './../Servicios/Alertify.service';
import { Valor } from './../Model/Valor';
import { ValoresService } from './../Servicios/Valores.service';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-resultados',
  templateUrl: './resultados.component.html',
  styleUrls: ['./resultados.component.css']
})
export class ResultadosComponent implements OnInit {

  listaValores: Valor[] = [] as Valor[];

  constructor(private valoresService: ValoresService,
    private alertifyService: AlertifyService) { 
      this.listarValores();
    }

  ngOnInit() {
    
  }

  listarValores() {
    this.valoresService.listarValores().subscribe(
      lista => {
        this.listaValores = lista;
      },
      error => {
        this.alertifyService.error(error);
      }
    );
  }
}
