import { Component, OnInit } from '@angular/core';
import { AmgSecreto } from 'src/app/models/amgSecreto';
import { FormGroup, FormBuilder, FormControl, FormControlName, Validators } from '@angular/forms';
import { CadastroAmgService } from '../cadastroAmg.service';
import { HttpErrorResponse } from '@angular/common/http';
declare var $: any;

@Component({
  selector: 'tcc-cadastro-amg-secreto',
  templateUrl: './cadastro-amg-secreto.component.html',
  styleUrls: ['./cadastro-amg-secreto.component.css']
})
export class CadastroAmgSecretoComponent implements OnInit {

  formAmg: FormGroup;
  formMail: FormGroup;
  amgSecreto: AmgSecreto = new AmgSecreto();

  constructor(
    private service: CadastroAmgService,
    private formBuild: FormBuilder
  ) { }

  ngOnInit() {
    this.formMail = this.formBuild.group({
      Nome: [''],
      Email: ['']
    });

    this.formAmg = this.formBuild.group({
      Nome_amigo_oculto: ['', Validators.required],
      Descricao: ['', Validators.required],
      Data_revelacao: ['', Validators.required, Validators.maxLength(8)]

    });
  }
  click() {
  this.amgSecreto.Email = this.formMail.get('Email').value;
  this.amgSecreto.Nome = this.formMail.get('Nome').value;
  this.service.convidar(this.amgSecreto).subscribe(
    () => {
      alert('Email enviado com sucesso.');
      this.formMail.reset();
    },
    (err: HttpErrorResponse) => {
     console.log(err);
    }
  );
  }

  onSubmit() {
    this.amgSecreto.Nome_amigo_oculto = this.formAmg.get('Nome_amigo_oculto').value;
    this.amgSecreto.Descricao = this.formAmg.get('Descricao').value;
    this.amgSecreto.Data_revelacao = this.formAmg.get('Data_revelacao').value;

    this.service.cadastrarAmgSecreto(this.amgSecreto).subscribe(
      () => {
        alert('Cadastrado com sucesso.');
      },
      (err: HttpErrorResponse) => {
       console.log(err);
      }
    );
  }
  /*public adicionarCampo() {
    $(function () {
      var scntDiv = $('#dynamicDiv');
      $(document).on('click', '#addInput', function () {
        $('<p>' +
          '<input formControlName="Email2 type="text" id="inputeste" size="20" value="" placeholder="" />' +
          '<a class="btn btn-danger btn-small" href="javascript:void(0)" id="remInput" style="background: rgb(214, 30, 30)">' +
          '<span class="glyphicon glyphicon-minus" aria-hidden="true"></span>' +
          'Remover Campo'+
          '</a>' +
          '<br/>'+
          '<br/>'+
          '</p>').appendTo(scntDiv);
        return false;
      });
      $(document).on('click', '#remInput', function () {
        $(this).parents('p').remove();
        return false;
      });
    });

  }*/
}

