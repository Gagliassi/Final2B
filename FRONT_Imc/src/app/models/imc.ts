import { Usuario } from "./usuario";

export interface Imc {
  id?: number;
  peso: number;
  altura: number;
  imc: number;
  usuarioId: string;
  usuario?: Usuario;
  classificacaoImc: string;
  criadoEm?: Date;
}
