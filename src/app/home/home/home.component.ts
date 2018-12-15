import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Login } from 'src/app/models/login';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { LoginService } from '../login.service';
import { HeaderComponent } from '../../header/header.component';
import { LoginViewModel } from 'src/app/viewModel/login.view-model';
import { UserViewModel } from 'src/app/viewModel/user.view-model';
import { Usuario } from 'src/app/models/usuario';
import { Validacoes } from 'src/app/conta/cadastro/validacoes';

@Component({
  selector: 'tcc-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  loginData: LoginViewModel;
  loginForm: FormGroup;
  headers: HeaderComponent;
  usuario: Usuario;
  constructor(
    private fb: FormBuilder,
    private loginService: LoginService,
    private router: Router,
    private header: HeaderComponent) { }

  ngOnInit() {
    this.redirecionarLogado();
    this.loginForm = this.fb.group({
      Email: this.fb.control('', [Validators.required, Validators.email]),
      Senha: this.fb.control('', [Validators.required])
    });
    if (this.loginService.buscaUsuariologado()) {
      return true;
    } else {
      this.loginService.remove();
    }
  }
  login() {
    this.loginData = new LoginViewModel(this.loginForm.value);
    this.loginService.login(this.loginForm.value.Email, this.loginForm.value.Senha)
      .subscribe((result) => {
        this.loginService.setUserLocalStorage(new LoginViewModel(result));
        alert('Logado com sucesso. ');
        this.router.navigate(['/gerenciarAmg']);
        this.header.mudarNav();
      },
        (err: HttpErrorResponse) => {
          alert(err + 'Email ou Senha inválidos');
        }
      );
  }
  redirecionarLogado() {
    if (this.loginService.buscaUsuariologado()) {
      this.router.navigate(['/gerenciarAmg']);
    }
  }
}
