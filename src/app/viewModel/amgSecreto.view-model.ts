export class AmgSecretoViewModel {

    Id_amigo_oculto: number;
    Nome_amigo_oculto: string;
    Data_revelacao: string;

    constructor(a) {
        this.Id_amigo_oculto = a.Id_amigo_oculto !== null ? a.Id_amigo_oculto : null;
        this.Nome_amigo_oculto = a.Nome_amigo_oculto !== null ? a.Nome_amigo_oculto : null;
        this.Data_revelacao = a.Data_revelacao !== null ? a.Data_revelacao : null;
    }
}
