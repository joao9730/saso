import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';


import { CadastroAmgService } from './cadastroAmg.service';
import { CadastroAmgSecretoComponent } from './cadastro-amg-secreto/cadastro-amg-secreto.component';
import { PesquisarUsuarioComponent } from '../Tela/pesquisar-usuario/pesquisar-usuario.component';
import { FilterPipe } from '../filter.pipe';
import { FilterAmgPipe } from '../filterAmg.pipe';
import { GerenciarAmgComponent } from '../Tela/gerenciar-amg/gerenciar-amg.component';
import { DetalhesAmgComponent } from '../Tela/detalhes-amg/detalhes-amg.component';
import { VisualizarAmgComponent } from '../Tela/visualizar-amg/visualizar-amg.component';
import { GerenciarPerfilComponent } from '../Tela/gerenciar-perfil/gerenciar-perfil.component';
import { SolicitacoesComponent } from '../Tela/solicitacoes/solicitacoes.component';
import { GerenciarAmgService } from './gerenciarAmg.service';
import { FilterListaAmgPipe } from '../amigo-secreto/lista-amigo-secreto/filterListaAmg.pipe';

@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule
  ],
  declarations: [
    CadastroAmgSecretoComponent,
    PesquisarUsuarioComponent,
    FilterPipe,
    GerenciarAmgComponent,
    DetalhesAmgComponent,
    VisualizarAmgComponent,
    GerenciarPerfilComponent,
    SolicitacoesComponent,
    FilterAmgPipe
  ],
  providers: [ CadastroAmgService, GerenciarAmgService ]
})
export class CadastroAmgModule { }
