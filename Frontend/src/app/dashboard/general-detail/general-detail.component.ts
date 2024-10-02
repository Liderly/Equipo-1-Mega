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

  constructor(private dataService: DataServiceService) {}

  ngOnInit() {
    const datosGuardados = localStorage.getItem('datos_reporte_general');
    this.datos = datosGuardados ? JSON.parse(datosGuardados) : null;

    if (this.datos) {
      console.log(
        'Aqui esta el numero de cuadrilla para la API',
        this.datos.num_cuadrilla
      );
    }
  }
}
