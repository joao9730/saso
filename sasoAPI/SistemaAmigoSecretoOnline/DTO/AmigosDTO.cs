using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaAmigoSecretoOnline.DTO
{
    public class AmigosDTO
    {
        public int Id_amigo { get; set; }
        public System.DateTime Data_solicitacao { get; set; }
        public System.DateTime Data_confirmacao { get; set; }
        public string Situacao { get; set; }
        public int Fk_usuario_solicitante { get; set; }
        public int Fk_usuario_destino { get; set; }
    }
}