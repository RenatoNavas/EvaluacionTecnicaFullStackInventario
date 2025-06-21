export interface Transaccion {
  transaccionId?: number;
  fechaTransaccion?: string; 
  tipoTransaccion: 'compra' | 'venta';
  productoId: number;
  cantidadTransaccion: number;
  precioUnitarioTransaccion: number;
  precioTotalTransaccion?: number; 
  detalleTransaccion?: string;
}
