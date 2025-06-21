import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Transaccion } from '../models/transaccion.model';

@Injectable({ providedIn: 'root' })
export class TransaccionService {
  private baseUrl = 'https://localhost:7241/api/transacciones'; 

  constructor(private http: HttpClient) {}

  listar(
    productoId?: number,
    tipo?: string,
    fechaDesde?: Date,
    fechaHasta?: Date
  ): Observable<Transaccion[]> {
    let params = new HttpParams();

    if (productoId != null) {
      params = params.set('productoId', productoId.toString());
    }

    if (tipo) {
      params = params.set('tipo', tipo);
    }

    if (fechaDesde) {
      params = params.set('fechaDesde', fechaDesde.toISOString());
    }

    if (fechaHasta) {
      params = params.set('fechaHasta', fechaHasta.toISOString());
    }

    return this.http.get<Transaccion[]>(this.baseUrl, { params });
  }
  // Obtener una transacción por ID
  obtener(id: number): Observable<Transaccion> {
    return this.http.get<Transaccion>(`${this.baseUrl}/${id}`);
  }

  // Crear una nueva transacción
  crear(transaccion: Transaccion): Observable<Transaccion> {
    return this.http.post<Transaccion>(this.baseUrl, transaccion);
  }

  // Actualizar una transacción
  actualizar(id: number, transaccion: Transaccion): Observable<Transaccion> {
    return this.http.put<Transaccion>(`${this.baseUrl}/${id}`, transaccion);
  }

  // Eliminar una transacción
  eliminar(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
