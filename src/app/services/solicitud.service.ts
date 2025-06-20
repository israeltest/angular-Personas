import { HttpClient } from '@angular/common/http';
import { Injectable, signal } from '@angular/core';
import { tap } from 'rxjs';
import { Solicitud } from '../Models/Solicitud.model';
import { SolicitudDto } from '../Models/SolicitudDto.model';



@Injectable({
  providedIn: 'root'
})
export class SolicitudService {
 private api = 'https://localhost:7152/api/Solicitud';
  solicitudes = signal<Solicitud[]>([]);
  constructor(private http: HttpClient) { this.loadAll().subscribe(); }

  loadAll() {
    return this.http.get<Solicitud[]>(this.api).pipe(tap(data => this.solicitudes.set(data)));
  }

  create(dto: SolicitudDto) {
    return this.http.post(this.api, dto).pipe(tap(() => this.loadAll()));
  }
}
