using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaAmigoSecretoOnline.DTO
{
    public class PostDTO
    {
        public int Id_post { get; set; }
        public string Descricao_post { get; set; }
        public DateTime Data_post { get; set; }
        public int Fk_topico { get; set; }
        public int Fk_post { get; set; }

    }
}