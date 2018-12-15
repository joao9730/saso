import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Usuario } from '../models/usuario';

const URL_API = 'http://localhost:23610/api';

@Injectable({
  providedIn: 'root'
})
export class ContaService {

  constructor(private http: HttpClient) { }

  buscaTodasCidades() {
    return this.http.get(URL_API + '/usuario/busca-todas-cidades');
  }

  cadastrarUsuario(usuario: Usuario) {
    return this.http.post(URL_API + '/usuario/cadastrar/', usuario);
  }
}
