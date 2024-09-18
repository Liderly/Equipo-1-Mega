import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EnviaDatoService {

  private employeeSource = new BehaviorSubject<string>('');
  currentEmployee = this.employeeSource.asObservable();

  changeEmployee(employee: string) {
    this.employeeSource.next(employee);
  }
}
