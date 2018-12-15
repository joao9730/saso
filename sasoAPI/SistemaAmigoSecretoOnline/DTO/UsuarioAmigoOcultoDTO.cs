using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaAmigoSecretoOnline.DTO
{
    public class UsuarioAmigoOcultoDTO
    {
        public int Id_usuario_amigo_oculto { get; set; }
        public int Fk_usuario { get; set; }
        public int Fk_amigo_oculto { get; set; }
    }
}