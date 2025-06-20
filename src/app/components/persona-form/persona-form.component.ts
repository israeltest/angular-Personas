import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { switchMap } from 'rxjs';
import { PersonaService } from '../../services/persona.service';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-persona-form',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterModule, HttpClientModule],
  templateUrl: './persona-form.component.html',
  styleUrl: './persona-form.component.css'
})
export class PersonaFormComponent implements OnInit {
 fb = inject(FormBuilder);
  personaService = inject(PersonaService);
  route = inject(ActivatedRoute);
  router = inject(Router);

  form = this.fb.group({
    nombre: ['', Validators.required],
    edad: [0, [Validators.required, Validators.min(18)]],
    estadoCivil: ['', Validators.required],
    fechaNacimiento: ['', Validators.required],
  });

  isEdit = false;
  id?: number;

  ngOnInit() {
    this.route.paramMap.pipe(
      switchMap(params => {
        const id = params.get('id');
        if (id) {
          this.isEdit = true;
          this.id = +id;
          return this.personaService.getById(this.id);
        }
        return [null];
      })
    ).subscribe(p => {
      if (p) this.form.patchValue(p);
    });
  }

  onSubmit() {
   if (this.form.invalid) {
    this.form.markAllAsTouched(); // <-- Esto muestra los errores
    return;
  }

    const raw = this.form.getRawValue();
    const data = {
      nombre: raw.nombre ?? '',
      edad: raw.edad ?? 0,
      estadoCivil: raw.estadoCivil ?? '',
      fechaNacimiento: raw.fechaNacimiento ?? ''
    };

    const action = this.isEdit
      ? this.personaService.update({ id: this.id!, ...data })
      : this.personaService.create(data);

    action.subscribe(() => this.router.navigate(['/']));
  }
}
