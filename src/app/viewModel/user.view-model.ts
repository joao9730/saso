export class UserViewModel {

    nome: string;
    email: string;
    usuario_ID: string;

    constructor(u) {
        this.nome = u.nome !== null ? u.nome : null;
        this.email = u.email !== null ? u.email : null;
        this.usuario_ID = u.usuario_ID !== null ? u.usuario_ID : null;
    }
}
