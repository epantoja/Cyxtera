import { ValoresService } from './../Servicios/Valores.service';
import { Valor } from './../Model/Valor';
import { AlertifyService } from './../Servicios/Alertify.service';
import { OperacionesService } from './../Servicios/Operaciones.service';
import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-agregar-valor',
  templateUrl: './agregar-valor.component.html',
  styleUrls: ['./agregar-valor.component.css']
})
export class AgregarValorComponent implements OnInit {

  valor: Valor = {} as Valor;

  @Output() listarValores = new EventEmitter();

  constructor(private operacionesService: OperacionesService,
    private valoresService: ValoresService,
    private alertifyService: AlertifyService) { }

  ngOnInit() {
  }

  registrarValor(txtValor: any){
    if (txtValor.value != "") {

      this.valor.valorOperacion = txtValor.value;
      this.valoresService.registrarValor(this.valor).subscribe(
        valor => {
          this.alertifyService.success("Numero " + this.valor.valorOperacion + " agregado correctamente");
          this.listarValores.emit({parametro: "listar"});
        },
        error => {
          this.alertifyService.error(error);
        }
      );
      txtValor.value = "";
    }
  }

  potenciaValores() {
    this.operacionesService.PotenciaValores().subscribe(
      estado => {
        this.alertifyService.success("Operacion Potenciacion realizada");
        this.listarValores.emit({parametro: "listar"});
      },
      error => {
        this.alertifyService.error(error);
      }
    );
  }

  dividirValores() {
    this.operacionesService.DividirValores().subscribe(
      estado => {
        this.alertifyService.success("Operacion Division realizada");
        this.listarValores.emit({parametro: "listar"});
      },
      error => {
        this.alertifyService.error(error);
      }
    );
  }

  multiplicarValores() {
    this.operacionesService.MultiplicarValores().subscribe(
      estado => {
        this.alertifyService.success("Operacion Multiplicacion realizada");
        this.listarValores.emit({parametro: "listar"});
      },
      error => {
        this.alertifyService.error(error);
      }
    );
  }

  restarValores() {
    this.operacionesService.restarValores().subscribe(
      estado => {
        this.alertifyService.success("Operacion Resta realizada");
        this.listarValores.emit({parametro: "listar"});
      },
      error => {
        this.alertifyService.error(error);
      }
    );
  }

  sumarValores() {
    this.operacionesService.sumarValores().subscribe(
      estado => {
        this.alertifyService.success("Operacion Suma realizada");
        this.listarValores.emit({parametro: "listar"});
      },
      error => {
        this.alertifyService.error(error);
      }
    );
  }

}
