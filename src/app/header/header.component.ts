import { Component, OnInit } from '@angular/core';
import { LoginService } from '../home/login.service';
import { Router } from '@angular/router';
import { AuthGuardService } from '../guarda-rotas/auth-guard.service';
declare var $: any;
@Component({
  selector: 'tcc-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

 // tslint:disable-next-line:typedef-whitespace
 router : Router;
  constructor(private loginService: LoginService,
    router: Router, private auth: AuthGuardService) { this.router = router; }

  ngOnInit() {
    $('.dropdown-trigger').dropdown();

    if (this.loginService.buscaUsuariologado()) {
    const user = JSON.parse(localStorage.getItem('userLogado'));
    $('#send').show();
    $('#menu').show();
    $('#inicio').hide();
    $('#cadastro').hide();
    $('#welcome').text('Bem vindo ' + user.Nome);
    return true;
  } else {
      $('#send').hide();
    $('#menu').hide();
    $('#welcome').hide();
    return false;
    } { }
  }

  click() {
    $('#send').fadeOut();
    $('#inicio').show();
    $('#menu').hide();
    $('#cadastro').show();
    $('#welcome').hide();
  this.loginService.remove();

  console.log(this.loginService.buscaUsuariologado());

   if (!this.loginService.buscaUsuariologado()) {
      return false;
   }
   this.router.navigate(['']);
      return true;
  }
  mudarNav() {
    const user = JSON.parse(localStorage.getItem('userLogado'));
    $('#send').show();
    $('#menu').show();
    $('#welcome').text('Bem vindo ' + user.Nome);
    $('#welcome').show();
    $('#inicio').hide();
    $('#cadastro').hide();
  }

}



