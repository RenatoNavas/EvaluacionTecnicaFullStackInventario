import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Producto } from '../models/producto.model';

@Injectable({ providedIn: 'root' })
export class ProductoService {
  private baseUrl = 'https://localhost:7256/api/productos'; 

  constructor(private http: HttpClient) {}

  // Listar todos los productos
  listar(): Observable<Producto[]> {
    return this.http.get<Producto[]>(this.baseUrl);
  }

  // Obtener producto por ID
  obtener(id: number): Observable<Producto> {
    return this.http.get<Producto>(`${this.baseUrl}/${id}`);
  }

  // Crear un nuevo producto
  crear(producto: Producto): Observable<Producto> {
    return this.http.post<Producto>(this.baseUrl, producto);
  }

  // Actualizar un producto existente
  actualizar(id: number, producto: Producto): Observable<Producto> {
    return this.http.put<Producto>(`${this.baseUrl}/${id}`, producto);
  }

  // Eliminar un producto
  eliminar(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }

  // Ajustar stock (solo para ventas)
  ajustarStock(id: number, cantidad: number): Observable<void> {
    return this.http.put<void>(`${this.baseUrl}/${id}/ajustar-stock`, cantidad);
  }
}
