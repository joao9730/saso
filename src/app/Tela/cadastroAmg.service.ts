import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { AmgSecreto } from '../models/amgSecreto';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { ListarUsuario } from '../models/listarUsuario';
import { Usuario } from '../models/usuario';
import { AttPerfil } from '../models/attPerfil.model';
import { AmgSecretoViewModel } from '../viewModel/amgSecreto.view-model';


const URL_API = 'http://localhost:23610/api';

@Injectable({
  providedIn: 'root'
})
export class CadastroAmgService {

  getHeaders() {
    const headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    return headers;
}

  constructor(private http: HttpClient) { }

  cadastrarAmgSecreto(amgSecreto: AmgSecreto) {
    return this.http.post(URL_API + '/amigoOculto/cadastrar/', amgSecreto);
  }

  convidar( amgSecreto: AmgSecreto) {
    return this.http.post(URL_API + '/amigoOculto/convidar/', amgSecreto);
  }

  listar() {
    return this.http.get(`${URL_API}/usuario/buscar-todos`);
   }

   listarParticipantes() {
    return this.http.get(`${URL_API}/usuarioAmgOculto/busca-por-amigo-oculto/`);
   }

   listarAmgSecreto(id: number) {
     return this.http.get(`${URL_API}/usuario/participando/` + id);
   }

   excluirUsuario(id: number) {
     return this.http.delete(`${URL_API}/usuario/deletar/` + id);
   }

  pesquisarNome() {
    return this.http.get(`${URL_API}/usuario/busca-por-nome`);
  }

  atualizarPerfil(usuario: Usuario) {
    return this.http.put(`${URL_API}/usuario/editar/` + usuario.Id_usuario, usuario);
   }

  setUserLocalStorage(usuario: AmgSecretoViewModel) {
    localStorage.setItem('userLogado', JSON.stringify(usuario));
  }

  buscaUsuariologado() {
    return localStorage.getItem('userLogado');
  }

  remove() {
    localStorage.removeItem('userLogado');
  }
}


