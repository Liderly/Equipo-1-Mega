import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  
  constructor(
    private router: Router,
  ) { }

  onSubmit(form: any) {

    if(!form.value.name || !form.value.password)
    {
      alert('Ingrese un usuario y contraseña valido')
    }
    else
    {
      this.router.navigate(['/home']);
    }
  }
}
