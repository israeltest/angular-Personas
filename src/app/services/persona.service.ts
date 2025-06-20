import { inject, Injectable, signal } from '@angular/core';
import { Persona, PersonaDto } from '../Models/persona.model';
import { HttpClient } from '@angular/common/http';
import { tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PersonaService {

  private readonly api = 'https://localhost:7152'; // Ajusta según tu API
  personas = signal<Persona[]>([]);

  constructor(private http: HttpClient) {}

  loadAll() {
    return this.http.get<Persona[]>(`${this.api}/ObtenerPersona`)
      .pipe(tap(data => this.personas.set(data)));
  }

  getById(id: number) {
    return this.http.get<Persona>(`${this.api}/ObtenerPersonaID/${id}`);
  }

  create(persona: PersonaDto) {
    return this.http.post(`${this.api}/CrearPersona`, persona);
  }

  update(persona: Persona) {
    return this.http.put(`${this.api}/ActualizarPersona`, persona);
  }

  delete(id: number) {
    return this.http.delete(`${this.api}/DeletePersona/${id}`);
  }
}
