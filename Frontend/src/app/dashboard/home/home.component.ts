import { Component } from '@angular/core';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
})
export class HomeComponent {
  constructor(private router: Router) {}

  general(): void {
    this.router.navigate(['/dashboard/general-report']);
  }

  cuadrillas(): void {
    this.router.navigate(['/dashboard/cuadrilla']);
  }

  empleado(): void {
    this.router.navigate(['/dashboard/employee']);
  }
}
