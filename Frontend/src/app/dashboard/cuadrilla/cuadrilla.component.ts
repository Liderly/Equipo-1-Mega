import { Component } from '@angular/core';
import { RouterLink, Router } from '@angular/router';
import { DataServiceService } from '../../services/dataService/data-service.service';
import { FormsModule } from '@angular/forms';
@Component({
  selector: 'app-cuadrilla',
  standalone: true,
  imports: [RouterLink, FormsModule],
  templateUrl: './cuadrilla.component.html',
  styleUrl: './cuadrilla.component.css',
})
export class CuadrillaComponent {
  num_cuadrilla: string = '';

  constructor(
    private router: Router,
    private dataService: DataServiceService
  ) {}

  onSubmit() {
    if (this.num_cuadrilla) {
      const datos = {
        num_cuadrilla: this.num_cuadrilla,
      };
      //this.dataService.setDatos(datos);  // Guarda el objeto JSON en el servicio
      localStorage.setItem('buscar_reporte_cuadrilla', JSON.stringify(datos));

      this.router.navigate(['dashboard/reports']);
    }
  }
}
