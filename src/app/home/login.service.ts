import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { LoginViewModel } from '../viewModel/login.view-model';
import { UserViewModel } from '../viewModel/user.view-model';
import { Usuario } from '../models/usuario';
import { Login } from '../models/login';


@Injectable({
  providedIn: 'root'
})
export class LoginService {
  URL_DEFAULT = environment.URL_API;
  reload: boolean;
  constructor(private http: HttpClient) { }

  getHeaders() {
    const headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    return headers;
}

  login(Email: string, Senha: string ): Observable<LoginViewModel> {
  return this.http.post<LoginViewModel>(environment.LOGIN_ENDPOINT,
     {Email: Email, Senha: Senha}, {headers: this.getHeaders()});
  }

  setUserLocalStorage(usuario: LoginViewModel) {
    localStorage.setItem('userLogado', JSON.stringify(usuario));
  }

  buscaUsuariologado() {
    return localStorage.getItem('userLogado');
  }

  remove() {
    localStorage.removeItem('userLogado');
  }

  Talogado() {
    return !!localStorage.getItem('usuarioLogado');
  }
}
