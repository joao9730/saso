import { ContaService } from './../conta.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Usuario } from '../../models/usuario';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { Http } from '@angular/http';
import { AlertService } from 'src/app/shared/alert.service';
import { Validacoes } from './validacoes';

@Component({
  selector: 'tcc-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css']
})
export class CadastroComponent implements OnInit {

  form: FormGroup;
  usuario: Usuario = new Usuario();
  router: Router;
  loading = false;
  submitted = false;

  constructor(
    private service: ContaService,
    private formBuild: FormBuilder,
    http: Http, router: Router,
    private alertService: AlertService
    ) {
      this.router = router;
    }

  ngOnInit() {

    this.form = this.formBuild.group({
      Nome: ['', Validators.compose([
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(50)])],
      Login: ['', Validators.compose([
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(50)])],
      Senha: ['', Validators.compose([Validators.required, Validators.minLength(3)])],
      Email: ['', Validators.compose([Validators.email, Validators.required])],
      DataNascimento: ['', Validators.compose([Validators.required])],
      Estado: ['', Validators.compose([Validators.required])],
      Telefone: ['', Validators.compose([Validators.required])],
      Cidade: ['', Validators.compose([Validators.required])],
      ConfirmarSenha: ['', Validators.compose([Validators.required, Validacoes.equalsTo('Senha')])]}
    );
  }
  get f() { return this.form.controls; }

  onSubmit() {
 this.submitted = true;

  if (this.form.invalid) {
    console.log('formulario invalido');
    Object.keys(this.form.controls).forEach((campo => {
      console.log(campo);
      const controle = this.form.get(campo);
    }));
  } else {
    this.loading = true;
    this.usuario.Nome = this.form.get('Nome').value;
    this.usuario.Login = this.form.get('Login').value;
    this.usuario.Senha = this.form.get('Senha').value;
    this.usuario.Fk_perfil = 2;
    this.usuario.Cidade = this.form.get('Cidade').value;
    this.usuario.Telefone = this.form.get('Telefone').value;
    this.usuario.Estado = this.form.get('Estado').value;
    this.usuario.Email = this.form.get('Email').value;
    this.usuario.Data_nascimento = this.form.get('DataNascimento').value;
    this.service.cadastrarUsuario(this.usuario).subscribe(
      () => {
        this.form.reset();
        alert('Cadastrado com sucesso!');
        this.router.navigate(['/']);
      },
      (error: HttpErrorResponse) => {
        // this.alertService.error();
          console.log(error);
      });
    }
  }
}
