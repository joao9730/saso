using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaAmigoSecretoOnline.DTO
{
    public class SorteioDTO
    {
        public int Id_sorteio { get; set; }
        public int Fk_usuario_inicio { get; set; }
        public int Fk_amigo_oculto { get; set; }
        public int Fk_usuario_fim { get; set; }
        public string UsuarioInicio { get; set; }
        public string UsuarioFim { get; set; }
        public string UsuarioEmail { get; set; }
        public string Descricao { get; set; }
        public DateTime Data_revelacao { get; set; }
        public string NomeSorteio { get; set; }

    }
}