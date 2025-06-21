export interface Producto {
  productoId: number;
  nombreProducto: string;
  descripcionProducto?: string;
  categoriaProducto?: string;
  imagenProducto?: string;
  precioProducto: number;
  stockProducto: number;
}
