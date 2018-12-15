import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

import { AuthGuardService } from '../guarda-rotas/auth-guard.service';

@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule
  ],
  declarations: [
  ],
  providers: [AuthGuardService]

})
export class LoginModule { }
