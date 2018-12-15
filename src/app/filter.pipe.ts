import { Pipe, PipeTransform } from '@angular/core';
import { Usuario } from './models/usuario';
import { AmgSecreto } from './models/amgSecreto';

@Pipe({
  name: 'filter'
})
export class FilterPipe implements PipeTransform {

  transform(usuarios: Usuario[], term: string): any {
    // checar se estiver incorreto
    if (term === undefined) { return usuarios; }
    // return update usuario array
    return usuarios.filter(function(usuario) {
      return usuario.Nome.toLowerCase()
      .includes(term.toLowerCase()) || usuario.Email.toLowerCase().includes(term.toLocaleLowerCase());
    });
  }
}
