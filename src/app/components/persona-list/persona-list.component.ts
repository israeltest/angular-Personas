import { Component, inject } from '@angular/core';
import { PersonaService } from '../../services/persona.service';
import { CommonModule } from '@angular/common';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-persona-list',
  imports: [CommonModule, RouterModule],
  templateUrl: './persona-list.component.html',
  styleUrl: './persona-list.component.css'
})
export class PersonaListComponent {
  personaService = inject(PersonaService);
  router = inject(Router);

  constructor() {
    this.personaService.loadAll().subscribe();
  }

  eliminar(id: number) {
    if (confirm('¿Seguro que deseas eliminar esta persona?')) {
      this.personaService.delete(id).subscribe(() => {
        this.personaService.loadAll().subscribe();
      });
    }
  }
}
