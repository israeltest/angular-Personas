import { Routes } from '@angular/router';
import { PersonaListComponent } from './components/persona-list/persona-list.component';
import { PersonaFormComponent } from './components/persona-form/persona-form.component';
import { SolicitudListComponent } from './components/solicitud-list/solicitud-list.component';

//export const routes: Routes = [];

export const appRoutes: Routes = [
  { path: '', component: PersonaListComponent },
  { path: 'crear', component: PersonaFormComponent },
  { path: 'editar/:id', component: PersonaFormComponent },
  { path: 'solicitudes', component: SolicitudListComponent } // 👈 agrega esta ruta
  //{ path: '**', redirectTo: '' }
];
