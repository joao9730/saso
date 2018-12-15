import { Injectable } from '@angular/core';
import { LoginService } from '../home/login.service';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, CanDeactivate } from '@angular/router';
import { EventEmitter } from 'events';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService implements CanActivate {


  constructor(
    private loginService: LoginService,
    private router: Router ) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {

    console.log(this.loginService.buscaUsuariologado());
    if (this.loginService.buscaUsuariologado()) {
      return true;
    } else {
      this.router.navigate(['']);
      alert('Você precisa estar logado para acessar essa página!');
    return false;
     }
  }
}
