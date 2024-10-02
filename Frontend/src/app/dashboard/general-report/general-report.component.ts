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
  lista: any = {};

  constructor(
    private router: Router,
    private dataService: DataServiceService
  ) {}

  ngOnInit(): void {
    this.showBodies = new Array(this.cuadrillas.length).fill(false);

    this.dataService.getDataAllCuadrillas().subscribe((data) => {
      console.log('data: ', data);
      this.cuadrillas = data;
    });
  }

  toggleBody(index: number): void {
    this.showBodies[index] = !this.showBodies[index];
  }

  irADetalle(cuadrilla: number): void {
    const datos = {
      num_cuadrilla: cuadrilla,
    };

    localStorage.setItem('datos_reporte_general', JSON.stringify(datos));
    this.router.navigate(['/dashboard/general-detail']);
  }
}
