import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Usuario } from 'src/app/models/usuario';
import { Router } from '@angular/router';
import { CadastroAmgModule } from '../cadastroAmg.module';
import { CadastroAmgService } from '../cadastroAmg.service';
import { Http } from '@angular/http';
import { HttpErrorResponse } from '@angular/common/http';
import { AttPerfil } from 'src/app/models/attPerfil.model';
import { LoginService } from 'src/app/home/login.service';

@Component({
  selector: 'tcc-gerenciar-perfil',
  templateUrl: './gerenciar-perfil.component.html',
  styleUrls: ['./gerenciar-perfil.component.css']
})
export class GerenciarPerfilComponent implements OnInit {
  form: FormGroup;
  usuario: Usuario = new Usuario();
  router: Router;
  submitted = false;

  constructor(
    private service: CadastroAmgService,
    private loginService: LoginService,
    private formBuild: FormBuilder,
    http: Http, router: Router
  ) { this.router = router; }

  ngOnInit() {
    const user = JSON.parse(localStorage.getItem('userLogado'));
    // console.log(user.Nome);

    this.form = this.formBuild.group({
      Nome: [user.Nome, Validators.compose([
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(50)])],
      Email: [user.Email, Validators.compose([Validators.email, Validators.required])],
      Senha: [user.Senha, Validators.compose([Validators.required, Validators.minLength(3)])],
      Telefone: [user.Telefone, Validators.compose([Validators.required])],
      Estado: [user.Estado, Validators.compose([Validators.required])],
      Cidade: [user.Cidade, Validators.compose([Validators.required])]
    });
  }

  deletarUsuario() {
 const user = JSON.parse(localStorage.getItem('userLogado'));
  this.service.excluirUsuario(user.Id_usuario).subscribe(() => {
    alert('Conta deletada com sucesso!');
    this.loginService.remove();
    this.router.navigate(['/']);
  });
  }

  onSubmit() {
    const user = JSON.parse(localStorage.getItem('userLogado'));
    this.submitted = true;

    if (this.form.invalid) {
      console.log('formulario invalido');
      Object.keys(this.form.controls).forEach((campo => {
        console.log(campo);
        const controle = this.form.get(campo);
      }));
    } else {
      this.usuario.Nome = this.form.get('Nome').value;
      this.usuario.Email = this.form.get('Email').value;
      this.usuario.Senha = this.form.get('Senha').value;
      this.usuario.Telefone = this.form.get('Telefone').value;
      this.usuario.Estado = this.form.get('Estado').value;
      this.usuario.Cidade = this.form.get('Cidade').value;
      this.usuario.Fk_perfil = 2;
      this.usuario.Login = user.Login;
      this.usuario.Id_usuario = user.Id_usuario;
      this.usuario.Data_nascimento = user.Data_nascimento;
      this.service.atualizarPerfil(this.usuario).subscribe(() => {
        alert('Atualizado com sucesso!');
        this.router.navigate(['/logado']);
      },
      (error: HttpErrorResponse) => {
        // this.alertService.error();
          console.log(error);
        } );
    }

  }
}

