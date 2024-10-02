import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DataServiceService } from '../../services/dataService/data-service.service';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-general-detail',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './general-detail.component.html',
  styleUrl: './general-detail.component.css',
})
export class GeneralDetailComponent implements OnInit {
  datos: any = {};
  lista: any = {};
  lista_empleados: any = [];

  constructor(private dataService: DataServiceService) {}

  ngOnInit() {
    const datosGuardados = localStorage.getItem('datos_reporte_general');
    this.datos = datosGuardados ? JSON.parse(datosGuardados) : null;

    if (this.datos) {
      /*console.log(
        'Aqui esta el numero de cuadrilla para la API',
        this.datos.num_cuadrilla, this.datos.orden
      );*/
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
    }
  }
}
