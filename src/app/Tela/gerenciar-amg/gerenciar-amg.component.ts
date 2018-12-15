import { Component, OnInit } from '@angular/core';
import { ListarAmgSecreto } from 'src/app/models/listarAmgSecreto';
import { FormGroup } from '@angular/forms';
import { CadastroAmgService } from '../cadastroAmg.service';
import { Router } from '@angular/router';
import { GerenciarAmgService } from '../gerenciarAmg.service';
import { AmgSecretoViewModel } from 'src/app/viewModel/amgSecreto.view-model';
import { SorteioModelView } from 'src/app/models/sorteio.view-model';

@Component({
  selector: 'tcc-gerenciar-amg',
  templateUrl: './gerenciar-amg.component.html',
  styleUrls: ['./gerenciar-amg.component.css']
})
export class GerenciarAmgComponent implements OnInit {

  amigosSecretos: ListarAmgSecreto[];
  searchForm: FormGroup;
  searchControl: string;
  router: Router;

  constructor(private service: CadastroAmgService, router: Router,
    private amgService: GerenciarAmgService) { this.router = router; }

  ngOnInit() {
    const user = JSON.parse(localStorage.getItem('userLogado'));
    this.service.listarAmgSecreto(user.Id_usuario)
    .subscribe((data: any[]) => {this.amigosSecretos = data;
      // fazer isso dentro do detalhesAmg passando o amgSecreto.Id_amigo_secreto pra listar somente os que participam
     } );

  }
  voltar() {
    this.router.navigate(['/logado']);
  }
  detalhesAmgCorresp(id: number) {
     localStorage.setItem('numero', id.toString());
      this.router.navigate(['/detalhesAmg']);

  }

}
