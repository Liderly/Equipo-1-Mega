import { NgFor, NgIf } from '@angular/common';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { DataServiceService } from '../../services/dataService/data-service.service';
import { AnyCatcher } from 'rxjs/internal/AnyCatcher';

import jsPDF from 'jspdf';
import html2canvas from 'html2canvas';

@Component({
  selector: 'app-reports',
  standalone: true,
  imports: [NgFor, NgIf],
  templateUrl: './reports.component.html',
  styleUrl: './reports.component.css',
})
export class ReportsComponent implements OnInit {
  datos: any = {};
  lista_ordenes: any = {};
  lista_empleados: any = {};
  lista_bonos: any = {};
  lista_ordenes_filtradas: any = {};

  showEmpleados: boolean = false; // Estado para mostrar/ocultar la tabla de empleados
  showOrdenes: boolean = false; // Estado inicial

  constructor(
    private router: Router,
    private dataService: DataServiceService
  ) {}

  @ViewChild('cardBody') cardBody!: ElementRef;

  ngOnInit() {
    const datosGuardados = localStorage.getItem('buscar_reporte_cuadrilla');
    this.datos = datosGuardados ? JSON.parse(datosGuardados) : null;

    this.dataService
      .getDataCuadrillaIndividual(this.datos.num_cuadrilla)
      .subscribe({
        next: (data) => {
          // Recibe las ordenes que y fueron instaladas
          this.lista_ordenes = data.filter(
            (item: any) => item.estatus === 'Instalado'
          );
          //console.log(this.lista_ordenes)

          // Recibe los puntajes y bonos obtenidos
          this.lista_bonos = this.lista_ordenes[0];

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

          // MUestra las ordenes realizadas por cuadrilla
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

        },
        error: (err) => {
          console.error('Error al insertar registro:', err);
          alert('Numero de cuadrilla no encontrado, inténtenlo de nuevo');
          this.router.navigate(['/dashboard/cuadrilla']);
        },
      });
  }

  toggleBody(): void {
    const body = this.cardBody.nativeElement;
    body.style.display =
      body.style.display === 'none' || body.style.display === ''
        ? 'block'
        : 'none';
  }

  empleados(): void {
    this.showEmpleados = !this.showEmpleados; // Cambia el estado de la tabla de empleados
  }

  ordenes(): void {
    this.showOrdenes = !this.showOrdenes; // Cambia el estado de la tabla de ordenes
  }

  irADetalle(orden: any): void {
    const datos = {
      num_cuadrilla: this.datos.num_cuadrilla,
      orden: orden,
    };
    localStorage.setItem('datos_reporte_cuadrilla', JSON.stringify(datos));
    console.log(datos);
    this.router.navigate(['/dashboard/order-detail']);
  }



  generarPDF() {
    const element = document.getElementById('contenido-a-imprimir');
    if (element) {
      html2canvas(element).then(canvas => {
        const imgData = canvas.toDataURL('image/png');
        const pdf = new jsPDF('p', 'mm', 'a4');

        const imgProps = pdf.getImageProperties(imgData);
        const pdfWidth = pdf.internal.pageSize.getWidth();
        const pdfHeight = (imgProps.height * pdfWidth) / imgProps.width;

        pdf.addImage(imgData, 'PNG', 0, 0, pdfWidth, pdfHeight);
        pdf.save('reporte.pdf');
      });
    }
  }

}
