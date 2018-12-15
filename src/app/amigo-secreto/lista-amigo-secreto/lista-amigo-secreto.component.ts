import { Component, OnInit } from '@angular/core';
import { AmigoSecretoService } from '../amigo-secreto.service';
import { Router } from '@angular/router';
import { ListarAmgSecreto } from 'src/app/models/listarAmgSecreto';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'tcc-lista-amigo-secreto',
  templateUrl: './lista-amigo-secreto.component.html',
  styleUrls: ['./lista-amigo-secreto.component.css']
})
export class ListaAmigoSecretoComponent implements OnInit {

  amigosSecretos: ListarAmgSecreto[];
  searchForm: FormGroup;
  searchControl: string;
  router: Router;

  constructor(private service: AmigoSecretoService, router: Router) { this.router = router; }

  ngOnInit() {
    const user = JSON.parse(localStorage.getItem('userLogado'));
    this.service.listarAmgSecreto(user.Id_usuario).subscribe((data: any[]) => {this.amigosSecretos = data; });
  }

  voltar() {
    this.router.navigate(['/gerenciarAmg']);
  }

  participar(id: number) {
    const user = JSON.parse(localStorage.getItem('userLogado'));
    this.service.participar( id , user.Id_usuario)
    .subscribe((data: any[]) => { this.amigosSecretos = data;
    alert('Você agora faz parte do grupo');
    this.router.navigate(['/gerenciarAmg']); } );
  }
}
