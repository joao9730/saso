import { Component, OnInit } from '@angular/core';
import { CadastroAmgService } from '../cadastroAmg.service';
import {FormBuilder, FormControl, FormGroup} from '@angular/forms';

import 'rxjs/add/operator/switchMap';
import { ListarUsuario } from '../../models/listarUsuario';

@Component({
  selector: 'tcc-pesquisar-usuario',
  templateUrl: './pesquisar-usuario.component.html',
  styleUrls: ['./pesquisar-usuario.component.css']
  // pipes: [FilterPipe]
})
export class PesquisarUsuarioComponent implements OnInit {

  usuarios: ListarUsuario[];

  searchForm: FormGroup;
  searchControl: string;

  constructor(private service: CadastroAmgService) { }

  ngOnInit() {
    this.service.listar().subscribe((data: any[]) => {this.usuarios = data; } );
  }


}
