import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { EnviaDatoService } from '../envia-dato.service';

@Component({
  selector: 'app-results',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './results.component.html',
  styleUrl: './results.component.css'
})
export class ResultsComponent {

  valor: any;
  employeeNumber: string = '';

  lista: any = [[1, 1002, 2, 'Juan Perez', 20240001, '18/09/2024', 'Activo', 180, '$500'],
  [2, 1002, 3, 'Maria Gomez' , 20240011, '11/09/2024', 'Activo', 211, '$650'],
  [3, 1005, 2, 'Luis Fernandez', 20240001, '05/03/2024', 'Activo', 70, '$0'],
  [4, 1001, 1, 'Ana Martinez', 20240002, '15/07/2024', 'Activo', 50, '$0'],
  [5, 1003, 3, 'Carlos Sanchez', 20240003, '22/10/2024', 'Activo', 46, '$0'],
  [6, 1004, 4, 'Lucia Ramirez', 20240004, '30/05/2024', 'Activo', 300, '$650'],
  [7, 1006, 2, 'Arturo Mendoza', 20240005, '01/12/2024', 'Activo', 123, '$300'],
  [8, 1002, 1, 'Ruben Almazan', 20240006, '18/08/2024', 'Activo', 228, '$650'],
  [9, 1007, 3, 'Ivonne Alvarez', 20240007, '14/04/2024', 'Activo', 125, '$300'],
  [10, 1008, 4, 'Omar Ramirez', 20240008, '27/06/2024', 'Activo', 100, '$300'],
  [11, 1002, 1, 'Jesus Molina', 20240009, '10/02/2024', 'Activo', 92, '$300'],
  [12, 1010, 2, 'Pedro Avilar', 20240010, '23/09/2024', 'Activo', 130, '$300']
  ]

  constructor(private employeeService: EnviaDatoService) { }

  ngOnInit() {
    this.employeeService.currentEmployee.subscribe(employee => {
      this.employeeNumber = employee;
      this.valor = this.employeeNumber
    });
  }

  

}
