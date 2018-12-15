export class LoginViewModel {
    Id_usuario: number;
    Email: string;
    Senha: string;
    Nome: string;
    Telefone: number;
    Estado: string;
    Cidade: string;
    Data_nascimento: string;
    Login: string;

    constructor(l) {
        this.Id_usuario = l.Id_usuario !== null ? l.Id_usuario : null;
        this.Email = l.Email !== null ? l.Email : null;
        this.Senha = l.Senha !== null ? l.Senha : null;
        this.Nome = l.Nome !== null ? l.Nome : null;
        this.Telefone = l.Telefone !== null ? l.Telefone : null;
        this.Estado = l.Estado !== null ? l.Estado : null;
        this.Cidade = l.Cidade !== null ? l.Cidade : null;
        this.Data_nascimento = l.Data_nascimento !== null ? l.Data_nascimento : null;
        this.Login = l.Login !== null ? l.Login : null;
    }
}
