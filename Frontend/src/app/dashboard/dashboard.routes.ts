import { Routes } from '@angular/router';
import { CuadrillaComponent } from './cuadrilla/cuadrilla.component';
import { EmployeeReportComponent } from './employee-report/employee-report.component';
import { GeneralDetailComponent } from './general-detail/general-detail.component';
import { HomeComponent } from './home/home.component';
import { ReportsComponent } from './reports/reports.component';
import { OrderDetailComponent } from './order-detail/order-detail.component';
import { SearchCuadrillaComponent } from './search-cuadrilla/search-cuadrilla.component';
import { GeneralReportComponent } from './general-report/general-report.component';
import { EmployeeComponent } from './employee/employee.component';

export const DASHBOARD_ROUTES: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'cuadrilla', component: CuadrillaComponent },
  { path: 'reports', component: ReportsComponent },
  { path: 'employee-report', component: EmployeeReportComponent },
  { path: 'general-detail', component: GeneralDetailComponent },
  { path: 'general-report', component: GeneralReportComponent },
  { path: 'order-detail', component: OrderDetailComponent },
  { path: 'search-cuadrilla', component: SearchCuadrillaComponent },
  { path: 'employee', component: EmployeeComponent },
];
