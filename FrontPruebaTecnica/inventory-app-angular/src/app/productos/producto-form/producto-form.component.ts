import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RouterModule, ActivatedRoute, Router } from '@angular/router';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { ProductoService } from '../../services/producto.service';
import { Producto } from '../../models/producto.model';
import { Observable } from 'rxjs';

import { NO_SPECIAL_CHARS } from '../../utils/validators';

@Component({
  selector: 'app-producto-form',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatSnackBarModule
  ],
  templateUrl: './producto-form.component.html',
  styleUrls: ['./producto-form.component.scss']
})
export class ProductoFormComponent implements OnInit {
  form!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private svc: ProductoService,
    private route: ActivatedRoute,
    private router: Router,
    private snack: MatSnackBar
  ) {}

  ngOnInit() {
    this.form = this.fb.group({
      nombreProducto: ['', [Validators.required, Validators.pattern(NO_SPECIAL_CHARS)]],
      descripcionProducto: ['', Validators.pattern(NO_SPECIAL_CHARS)],
      categoriaProducto: ['', Validators.pattern(NO_SPECIAL_CHARS)],
      imagenProducto: [''],
      precioProducto: [0, [Validators.required, Validators.min(0)]],
      stockProducto: [0, [Validators.required, Validators.min(0)]]
    });

    const id = Number(this.route.snapshot.paramMap.get('id'));
    if (id) {
      this.svc.obtener(id).subscribe(prod => this.form.patchValue(prod));
    }
  }

  submit() {
    if (this.form.invalid) return;

    const id = Number(this.route.snapshot.paramMap.get('id'));
    const producto: Producto = this.form.value;

    const obs: Observable<Producto | void> = id
      ? this.svc.actualizar(id, producto)
      : this.svc.crear(producto);

    obs.subscribe({
      next: () => {
        this.snack.open('Guardado con éxito', 'Cerrar', { duration: 2000 });
        this.router.navigate(['/productos']);
      },
      error: () => this.snack.open('Error al guardar', 'Cerrar', { duration: 3000 })
    });
  }
}
