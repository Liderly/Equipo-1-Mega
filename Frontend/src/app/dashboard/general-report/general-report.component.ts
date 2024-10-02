import { Component, OnInit } from '@angular/core';
import { CommonModule, NgFor, NgIf } from '@angular/common';
import { Router } from '@angular/router';
import { DataServiceService } from '../../services/dataService/data-service.service';


interface Cuadrillas {
  num_tecnico: number;
  nombre_tecnico: string;
  num_cuadrilla: number;
  trabajo_realizado: string;
  servicio: string;
  puntos_generados: number;
  total_puntos_tecnico: number;
  estatus: string;
  num_suscriptor: number;
  fecha: Date;
  valorPago: number;
}

@Component({
  selector: 'app-general-report',
  standalone: true,
  imports: [CommonModule, NgFor, NgIf],
  templateUrl: './general-report.component.html',
})

export class GeneralReportComponent implements OnInit {
  datos: any = {};
  cuadrillas: any = [];
  showBodies: boolean[] = [];
  lista_ordenes: any = {};
  lista_bonos: any = {};
  lista_empleados: any = {};
  lista_ordenes_filtradas: any = {};

  constructor(
    private router: Router,
    private dataService: DataServiceService
  ) { }

  ngOnInit(): void {
    this.showBodies = new Array(this.cuadrillas.length).fill(false);

    this.dataService.getDataAllCuadrillas().subscribe((data) => {
      this.cuadrillas = data;
    });
  }

  generaReporte(ordenes: any): any {

    this.lista_ordenes = {};
    this.lista_bonos = {};
    this.lista_empleados = {};
    this.lista_ordenes_filtradas = {};

    this.lista_ordenes = ordenes.filter(
      (item: any) => item.estatus === 'Instalado'
    );

    this.lista_bonos = this.lista_ordenes[0];

    // console.log('-', this.lista_bonos)

    //  Recibe la lista de empleados que ejecutaron esas ordenes
    this.lista_empleados = this.lista_ordenes.map((item: any) => ({
      numTecnico: item.numTecnico,
      nombreTecnico: item.nombreTecnico,
    }));

    this.lista_empleados = Array.from(
      new Map(
        this.lista_empleados.map((item: any) => [item.numTecnico, item])
      ).values()
    );

    let pivote = this.lista_empleados[0].nombreTecnico;
    this.lista_ordenes_filtradas = this.lista_ordenes
      .filter((item: any) => item.nombreTecnico === pivote)
      .map((item: any) => ({
        fecha: item.fecha,
        numSuscriptor: item.numSuscriptor,
        trabajoRealizado: item.trabajoRealizado,
        puntosGenerados: item.puntosGenerados,
        numTecnico: item.numTecnico,
        servicio: item.servicio,
        cuadrilla: this.lista_empleados,
      }));

    return {
      lista_ordenes: this.lista_ordenes,
      lista_bonos: this.lista_bonos,
      lista_empleados: this.lista_empleados,
      lista_ordenes_filtradas: this.lista_ordenes_filtradas
    };

  }

  toggleBody(index: number): void {
    this.showBodies[index] = !this.showBodies[index];
  }

  irADetalle(cuadrilla: number, orden: any): void {
    const datos = {
      num_cuadrilla: cuadrilla,
      orden: orden
    };

    localStorage.setItem('datos_reporte_general', JSON.stringify(datos));
    console.log(datos)
    this.router.navigate(['/dashboard/general-detail']);
  }


}
