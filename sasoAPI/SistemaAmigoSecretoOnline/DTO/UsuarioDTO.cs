using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaAmigoSecretoOnline.Models
{
    public class UsuarioDTO
    {
       public int Id_usuario { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string ConfirmarSenha { get; set; }
        public string Email { get; set; }
        public DateTime Data_nascimento { get; set; }
        public int Fk_perfil { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Telefone { get; set; }
    }
}