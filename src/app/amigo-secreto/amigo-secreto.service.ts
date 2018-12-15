import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { idLocale } from 'ngx-bootstrap/chronos/i18n/id';
import { AmgSecretoViewModel } from '../viewModel/amgSecreto.view-model';

const URL_API = 'http://localhost:23610/api';

@Injectable({
  providedIn: 'root'
})
export class AmigoSecretoService {


  constructor(private http: HttpClient) { }

  getHeaders() {
    const headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    return headers;
}

  listarAmgSecreto(Id_usuario: number) {
    return this.http.get(`${URL_API}/amigoOculto/buscar-todos/` + Id_usuario);
  }

  participar(Id_amigo_oculto: number, Id_usuario: number) {
   return this.http.post(`${URL_API}/amigoOculto/participar`, {Id_amigo_oculto: Id_amigo_oculto, Id_usuario: Id_usuario});
  }

  setAmgSecretoLocalStorage(gerenciarAmg: AmgSecretoViewModel) {
    localStorage.setItem('amgSecreto', JSON.stringify(gerenciarAmg));
  }

  buscaAmgSecreto() {
    return localStorage.getItem('amgSecreto');
  }

  removeAmgSecreto() {
    localStorage.removeItem('amgSecreto');
  }
}
