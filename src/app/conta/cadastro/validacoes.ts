import { AbstractControl, FormControl, FormGroup } from '@angular/forms';

export class Validacoes {

     static dataInvalida(controle: AbstractControl) {
     const dataNascimento = controle.value;
     const hoje = new Date();

     if (dataNascimento <=  Date.now() ) {
         return null;
     }
     return { DataMaior: true };
     }


  static SenhasCombinam(controle: AbstractControl) {
    const senha = controle.get('Senha').value;
    const confirmarSenha = controle.get('ConfirmarSenha').value;

    if (senha === confirmarSenha) { return null; }

    controle.get('ConfirmarSenha').setErrors({ senhasNaoCoincidem: true });
  }

  static equalsTo(otherField: string) {
    const validator = (formControl: FormControl) => {
      if (otherField == null) {
        throw new Error('É necessário informar um campo.');
      }

      if (!formControl.root || !(<FormGroup>formControl.root).controls) {
        return null;
      }

      const field = (<FormGroup>formControl.root).get(otherField);

      if (!field) {
        throw new Error('É necessário informar um campo válido.');
      }

      if (field.value !== formControl.value) {
        return { equalsTo : otherField };
      }

      return null;
    };
    return validator;
}
}
