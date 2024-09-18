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

  lista: any = [[1, 1002, 1, 2, 20240001, '18/09/2024', 'Activo', 5],
  [2, 1002, 3, 2, 20240011, '11/09/2024', 'En espera', 5],
  [3, 1005, 2, 3, 20240001, '05/03/2024', 'Activo', 7],
  [4, 1001, 1, 2, 20240002, '15/07/2024', 'En espera', 5],
  [5, 1003, 3, 1, 20240003, '22/10/2024', 'Activo', 6],
  [6, 1004, 4, 2, 20240004, '30/05/2024', 'En espera', 5],
  [7, 1006, 2, 3, 20240005, '01/12/2024', 'Activo', 3],
  [8, 1002, 1, 5, 20240006, '18/08/2024', 'En espera', 8],
  [9, 1007, 3, 2, 20240007, '14/04/2024', 'Activo', 5],
  [10, 1008, 4, 4, 20240008, '27/06/2024', 'En espera', 1],
  [11, 1002, 1, 1, 20240009, '10/02/2024', 'Activo', 9],
  [12, 1010, 2, 5, 20240010, '23/09/2024', 'En espera', 10]
  ]

  constructor(private employeeService: EnviaDatoService) { }

  ngOnInit() {
    this.employeeService.currentEmployee.subscribe(employee => {
      this.employeeNumber = employee;
      this.valor = this.employeeNumber
      // console.log('Número de empleado recibido:', this.employeeNumber);
    });
  }

}
