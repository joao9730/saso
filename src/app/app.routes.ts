import { Routes } from '@angular/router';
import { HomeComponent } from './home/home/home.component';
import { CadastroComponent } from './conta/cadastro/cadastro.component';
import { LogadoComponent } from './Tela/menu-logado/logado.component';
import { CadastroAmgSecretoComponent } from './Tela/cadastro-amg-secreto/cadastro-amg-secreto.component';
import { PesquisarUsuarioComponent } from './Tela/pesquisar-usuario/pesquisar-usuario.component';
import { GerenciarAmgComponent } from './Tela/gerenciar-amg/gerenciar-amg.component';
import { DetalhesAmgComponent } from './Tela/detalhes-amg/detalhes-amg.component';
import { VisualizarAmgComponent } from './Tela/visualizar-amg/visualizar-amg.component';
import { GerenciarPerfilComponent } from './Tela/gerenciar-perfil/gerenciar-perfil.component';
import { SolicitacoesComponent } from './Tela/solicitacoes/solicitacoes.component';
import { AuthGuardService } from './guarda-rotas/auth-guard.service';
import { ListaAmigoSecretoComponent } from './amigo-secreto/lista-amigo-secreto/lista-amigo-secreto.component';

export const ROUTES: Routes = [
    { path: '', component: HomeComponent },
    { path: 'cadastro', component: CadastroComponent },
    { path: 'logado', component: LogadoComponent, canActivate: [AuthGuardService] },
    { path: 'cadastroAmgSecreto', component: CadastroAmgSecretoComponent, canActivate: [AuthGuardService] },
    { path: 'pesquisarUsuario', component: PesquisarUsuarioComponent, canActivate: [AuthGuardService]},
    { path: 'gerenciarAmg', component: GerenciarAmgComponent, canActivate: [AuthGuardService] },
    { path: 'detalhesAmg', component: DetalhesAmgComponent, canActivate: [AuthGuardService] },
    { path: 'visualizarAmg', component: VisualizarAmgComponent, canActivate: [AuthGuardService] },
    { path: 'gerenciarPerfil', component: GerenciarPerfilComponent, canActivate: [AuthGuardService] },
    { path: 'solicitacoes', component: SolicitacoesComponent, canActivate: [AuthGuardService] },
    { path: 'pesquisarAmgSecreto', component: ListaAmigoSecretoComponent, canActivate: [AuthGuardService]}];
