import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home/home.component';
import { ROUTES } from './app.routes';
import { HeaderComponent } from './header/header.component';
import { ContaModule } from './conta/conta.module';
import { LogadoComponent } from './Tela/menu-logado/logado.component';
import { CadastroAmgModule } from './Tela/cadastroAmg.module';
import { TelaComponent } from './convidarAmg/tela/tela.component';
import { LoginModule } from './home/login.module';
import { AlertService } from './shared/alert.service';
import { ListaAmigoSecretoComponent } from './amigo-secreto/lista-amigo-secreto/lista-amigo-secreto.component';
import { FilterListaAmgPipe } from './amigo-secreto/lista-amigo-secreto/filterListaAmg.pipe';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    HeaderComponent,
    LogadoComponent,
    TelaComponent,
    ListaAmigoSecretoComponent,
    FilterListaAmgPipe
  ],
  imports: [
    BrowserModule,
    HttpModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    ContaModule,
    CadastroAmgModule,
    LoginModule,
    RouterModule.forRoot(ROUTES)
  ],
  providers: [HeaderComponent, AlertService],
  bootstrap: [AppComponent]
})
export class AppModule {}
