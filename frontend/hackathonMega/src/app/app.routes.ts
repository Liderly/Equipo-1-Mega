import { Routes } from '@angular/router';
import { HomepageComponent } from './homepage/homepage.component';
import { ResultsComponent } from './results/results.component';
import { LoginComponent } from './login/login.component';

export const routes: Routes = [
    { path: '', redirectTo: '/home', pathMatch: 'full' }, // Redirige la ruta vacía a 'home'
    { path: 'home', component: HomepageComponent }, // Ruta para el componente Home
    { path: 'result', component: ResultsComponent }, // Ruta para el componente Results
    { path: 'login', component: LoginComponent }, // Ruta para el componente Login
];
