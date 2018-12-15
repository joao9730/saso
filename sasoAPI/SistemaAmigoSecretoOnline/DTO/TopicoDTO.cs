using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaAmigoSecretoOnline.DTO
{
    public class TopicoDTO
    {
        public int Id_Topico { get; set; }
        public string Discursao { get; set; }
        public DateTime Data_inicio { get; set; }
        public int FK_amigo_oculto { get; set; }


    }
}