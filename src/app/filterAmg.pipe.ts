import { Pipe, PipeTransform } from '@angular/core';
import { AmgSecreto } from './models/amgSecreto';

@Pipe({
  name: 'filterAmg'
})
export class FilterAmgPipe implements PipeTransform {

  transform(amigosSecretos: AmgSecreto[], termo: string): any {
    // checar se estiver incorreto
    if (termo === undefined) { return amigosSecretos; }
    // return update usuario array
    return amigosSecretos.filter(function(amgSecreto) {
      return amgSecreto.Nome_amigo_oculto.toLowerCase()
      .includes(termo.toLowerCase()) || amgSecreto.Descricao.toLowerCase().includes(termo.toLocaleLowerCase());
    });
  }
}
