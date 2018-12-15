import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { CadastroAmgService } from '../cadastroAmg.service';
import { AmgSecreto } from '../../models/amgSecreto';
import { HttpErrorResponse } from '@angular/common/http';
import { ListarUsuario } from '../../models/listarUsuario';
import { Participantes } from 'src/app/models/participantesAmgSecreto';
import { GerenciarAmgService } from '../gerenciarAmg.service';
import { SorteioModelView } from 'src/app/models/sorteio.view-model';
import { AmgSecretoViewModel } from 'src/app/viewModel/amgSecreto.view-model';
import { Router } from '@angular/router';

@Component({
  selector: 'tcc-detalhes-amg',
  templateUrl: './detalhes-amg.component.html',
  styleUrls: ['./detalhes-amg.component.css']
})
export class DetalhesAmgComponent implements OnInit {

  participantes: Participantes[] = [];
  usuarios: ListarUsuario[] = [];
  formMail: FormGroup;
  amgSecreto: AmgSecreto = new AmgSecreto();
  searchForm: FormGroup;
  searchControl: string;
  amgSecretoView: AmgSecretoViewModel;
  sorteioModelView: SorteioModelView;


  constructor(
    private service: CadastroAmgService,
    private amgService: GerenciarAmgService,
    private formBuild: FormBuilder,
    private router: Router
  ) {

  }

  ngOnInit() {
    this.formMail = this.formBuild.group({
      Nome: [''],
      Email: ['']
    });

    const idAmg = JSON.parse(localStorage.getItem('numero'));
    this.amgService.detalhesAmgSecreto(idAmg).subscribe((data: any[]) => {this.usuarios = data;
      console.log(this.usuarios); });

  }
  realizarSorteio() {
    const idAmg = JSON.parse(localStorage.getItem('numero'));
    this.amgService.sortear(idAmg).subscribe(() => {
      alert('Sorteio realizado, os emails foram enviados');
      this.router.navigate(['/gerenciarAmg']);
    });
  }

  click() {
    this.amgSecreto.Nome = this.formMail.get('Nome').value;
    this.amgSecreto.Email = this.formMail.get('Email').value;
    this.service.convidar(this.amgSecreto).subscribe(
      () => {
        alert('Convite enviado!');
        this.formMail.reset();
        // quando convidar, adicionar o participante nesse amigo oculto
      },
      (err: HttpErrorResponse) => {
        alert('Convite não enviado erro: ' + err);
      });

    const usuario = new ListarUsuario();
    usuario.Email = this.formMail.get('Email').value;
    usuario.Nome = this.formMail.get('Nome').value;
    this.usuarios.unshift(usuario);

  }

  deletarLinha(Nome: string) {
    for ( let i = 0; i < this.usuarios.length; i++) {
      if (this.usuarios[i]['Nome'] === Nome) {
       this.usuarios.splice(i, 1);
       console.log(this.usuarios);
      }
    }
  }


}
