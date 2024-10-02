import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DataServiceService } from '../../services/dataService/data-service.service';

@Component({
  selector: 'app-order-detail',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './order-detail.component.html',
  styleUrl: './order-detail.component.css',
})
export class OrderDetailComponent {
  datos: any = {};
  lista: any = {};
  lista_empleados: any = [];

  constructor(private dataService: DataServiceService) { }

  ngOnInit() {
    const datosGuardados = localStorage.getItem('datos_reporte_cuadrilla'); // Debe coincidir
    this.datos = datosGuardados ? JSON.parse(datosGuardados) : null;
    
    if (this.datos) {
        
      this.dataService.getDataPuntosTecnico(this.datos.orden.numTecnico).subscribe({
        next: (data) => {
          this.lista = data
        
          // Filtra datos para obtener numero y nombre de suscriptor
          this.lista = data.filter((item: any) => item.numSuscriptor === this.datos.orden.numSuscriptor);
          this.lista = this.lista[0]
          
          // Lista de empleados de la cuadrilla
          this.lista_empleados = Object.values(this.datos.orden.cuadrilla);
  
        },
        error: (err) => {
          console.error('Error al insertar registro:', err);
        }
      });
    }
    

    /*this.dataService.getDataCuadrillaIndividual(this.datos.num_cuadrilla).subscribe({
      next: (data) => {
        this.lista = data;
        console.log(this.lista)
      },
      error: (err) => {
        console.error('Error al insertar registro:', err);
      }
    });*/

  }
}
