using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaAmigoSecretoOnline.DTO
{
    public class AmigoOcultoDTO
    {

        public int Id_amigo_oculto { get; set; }
        public string Nome_amigo_oculto { get; set; }
        public string Descricao { get; set; }
        public DateTime Data_revelacao { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
    }
}