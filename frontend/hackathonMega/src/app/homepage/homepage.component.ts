import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { EnviaDatoService } from '../envia-dato.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-homepage',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css'] // Corrección aquí
})
export class HomepageComponent {
  numeroEmpleado: string = '';

  constructor(private employeeService: EnviaDatoService, private router: Router,) { }

  onSubmit() {
    this.employeeService.changeEmployee(this.numeroEmpleado);
    this.router.navigate(['/result']);
  }
}
