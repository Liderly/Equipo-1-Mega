import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class DataServiceService {
  // private datos: any = {}; // Cambia `nombre` a un objeto

  constructor(private http: HttpClient) {}

  private UrlPuntosCuadrillaIndividual =
    'http://localhost:5295/api/PuntosCuadrilla';
  private UrlPuntosTecnico = 'http://localhost:5295/api/PuntosTecnico';
  private UrlAllCuadrillas = 'http://localhost:5295/api/PuntosAllCuadrillas';

  getDataCuadrillaIndividual(id_cuadrilla: number): Observable<any> {
    return this.http.get<any>(
      `${this.UrlPuntosCuadrillaIndividual}/${id_cuadrilla}`
    ); // Usa parámetros de consulta
  }

  getDataPuntosTecnico(id_tecnico: number): Observable<any> {
    return this.http.get<any>(`${this.UrlPuntosTecnico}/${id_tecnico}`); // Usa parámetros de consulta
  }

  getDataAllCuadrillas(): Observable<any> {
    return this.http.get<any>(this.UrlAllCuadrillas);
  }
}
