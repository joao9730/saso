using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaAmigoSecretoOnline.DTO
{
    public class ParticiparDTO
    {
        public int Id_usuario_amigo_oculto { get; set; }
        public int Id_usuario { get; set; }
        public int Id_amigo_oculto { get; set; }
    }
}