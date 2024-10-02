import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { DataServiceService } from '../../services/dataService/data-service.service';

@Component({
  selector: 'app-employee',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './employee.component.html',
  styleUrl: './employee.component.css',
})
export class EmployeeComponent {
  num_empleado: string = '';

  constructor(
    private router: Router,
    private dataService: DataServiceService
  ) {}

  onSubmit() {
    if (this.num_empleado) {
      const datos = {
        num_empleado: this.num_empleado,
      };
      localStorage.setItem('buscar_reporte_empleado', JSON.stringify(datos));

      this.router.navigate(['dashboard/employee-report']);
    }
  }
}
