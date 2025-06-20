import { Component, inject } from '@angular/core';
import { PersonaService } from '../../services/persona.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { SolicitudService } from '../../services/solicitud.service';
import { SolicitudDto } from '../../Models/SolicitudDto.model';

@Component({
  selector: 'app-solicitud-list',
  imports: [CommonModule,FormsModule ],
  templateUrl: './solicitud-list.component.html',
  styleUrl: './solicitud-list.component.css'
})
export class SolicitudListComponent {
  servicio = inject(SolicitudService);
  personas = inject(PersonaService).personas; // para combo
  dto: SolicitudDto = { personaId: 0, estado: 'En proceso' };

  crear() {
    this.servicio.create(this.dto).subscribe(() => { this.dto = { personaId: 0, estado: 'En proceso' }; });
  }
}
