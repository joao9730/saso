export class SorteioModelView {

    Nome?: string[];
    Email?: string[];

    constructor(s) {
    this.Nome = s.Nome !== null ? s.Nome : null;
    this.Email = s.Email !== null ? s.Email : null;
}
}
