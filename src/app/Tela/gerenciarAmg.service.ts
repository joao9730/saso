import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { AmgSecreto } from '../models/amgSecreto';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { ListarUsuario } from '../models/listarUsuario';
import { Usuario } from '../models/usuario';
import { AttPerfil } from '../models/attPerfil.model';
import { AmgSecretoViewModel } from '../viewModel/amgSecreto.view-model';
import { environment } from 'src/environments/environment';
import { SorteioModelView } from '../models/sorteio.view-model';


const URL_API = 'http://localhost:23610/api';

@Injectable({
  providedIn: 'root'
})
export class GerenciarAmgService {
    constructor(private http: HttpClient) { }

    getHeaders() {
        const headers = new HttpHeaders();
        headers.append('Content-Type', 'application/json');
        return headers;
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

  detalhesAmgSecreto(id: number) {
    return this.http.get(`${URL_API}/usuarioAmgOculto/detalhes-amg-participantes/` + id);
  }

  sortear(idAmg: number) {
    return this.http.post(`${URL_API}/Sorteio/realizarSorteio/`
     + idAmg, idAmg, {headers: this.getHeaders()});
  }
}
