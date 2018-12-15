import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

import { AuthGuardService } from '../guarda-rotas/auth-guard.service';
import { AmigoSecretoService } from './amigo-secreto.service';
import { FilterListaAmgPipe } from './lista-amigo-secreto/filterListaAmg.pipe';
import { ListaAmigoSecretoComponent } from './lista-amigo-secreto/lista-amigo-secreto.component';
@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
  ],
  declarations: [ FilterListaAmgPipe, ListaAmigoSecretoComponent
  ],
  providers: [AmigoSecretoService, AuthGuardService]

})
export class AmigoSecretoModule { }
