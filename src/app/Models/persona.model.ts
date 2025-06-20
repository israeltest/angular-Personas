export interface Persona {
  id: number;
  nombre: string;
  edad: number;
  estadoCivil: string;
  fechaNacimiento: string;
}
export type PersonaDto = Omit<Persona, 'id'>;