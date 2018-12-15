using SistemaAmigoSecretoOnline.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.UI.WebControls;

namespace SistemaAmigoSecretoOnline.Repository
{
    public class UsuarioRepository : BaseRepositoy
    {
        public Usuario GetOne(int id)
        {
            return DataModel.Usuario.FirstOrDefault(e => e.Id_usuario == id);
        }
        public List<Usuario> GetAll()
        {
            return DataModel.Usuario.ToList();
        }
        
        public Usuario GetUsuarioFim(int id)
        {
            return DataModel.Usuario.FirstOrDefault(e => e.Id_usuario == id);
        }

        public Usuario GetName(string nome)
        {
            return DataModel.Usuario.FirstOrDefault(e => e.Nome == nome);
        }

        public Usuario Login(string email, string senha)
        {
            return (DataModel.Usuario.FirstOrDefault(e => e.Email == email && e.Senha == senha));
        }

        public void Delete(int id)
        {
            var usuarioAmgOculto = DataModel.Usuario_Amigo_Oculto.FirstOrDefault(e => e.Fk_usuario == id);
            var usuario = GetOne(id);

            if (usuarioAmgOculto != null)
            {
                DataModel.Usuario_Amigo_Oculto.Remove(usuarioAmgOculto);
            }
            DataModel.Usuario.Remove(usuario);
            DataModel.SaveChanges();

        }
        public Usuario GetId(int id)
        {
            return DataModel.Usuario.FirstOrDefault(e => e.Id_usuario == id);
        }
        public void Update(UsuarioDTO entity)
        {
            Usuario usuario = new Usuario();

        }
        public void Save(UsuarioDTO entity)
        {

            Usuario usuario = new Usuario();
            {

                usuario.Nome = entity.Nome;
                usuario.Data_nascimento = entity.Data_nascimento;
                usuario.Email = entity.Email;
                usuario.Cidade = entity.Cidade;
                usuario.Estado = entity.Estado;
                usuario.Telefone = entity.Telefone;
                usuario.Fk_perfil = entity.Fk_perfil;
                usuario.Login = entity.Login;
                usuario.Senha = entity.Senha;
            };
                DataModel.Entry(usuario).State = entity.Id_usuario == 0 ?
                    EntityState.Added : EntityState.Modified;
            
            DataModel.SaveChanges();
            

        }

        

    }
 }
    
