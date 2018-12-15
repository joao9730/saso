using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SistemaAmigoSecretoOnline.Models;
using SistemaAmigoSecretoOnline.Repository;
using System.Web.Http.Cors;
using System.Web.UI.WebControls;
using SistemaAmigoSecretoOnline.DTO;

namespace SistemaAmigoSecretoOnline.Controllers
{


    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/usuario")]
    public class UsuariosController : ApiController
    {
        private UsuarioRepository usuarioRepository = new UsuarioRepository();
        private UsuarioAmigoOcultoRepository usuarioAmigoOcultoRepository = new UsuarioAmigoOcultoRepository();

        private EntityDataModel dataModel = new EntityDataModel();

        [HttpGet]
        [Route("buscar-todos")]
        [ResponseType(typeof(Usuario))]
        public List<UsuarioDTO> GetUsuario()
        {
            List<UsuarioDTO> list = new List<UsuarioDTO>();

            foreach (var item in usuarioRepository.GetAll())
            {
                UsuarioDTO dto = new UsuarioDTO();
               // dto.Id_usuario = item.Id_usuario;
                dto.Nome = item.Nome;
                dto.Login = item.Login;
                dto.Senha = item.Senha;
                dto.Email = item.Email;
                list.Add(dto);
            }
            return list;
        }

        [HttpGet]
        [Route("participando/{id:int}")]
        [ResponseType(typeof(Usuario_Amigo_Oculto))]
        public List<AmigoOcultoDTO> GetUsuarioParticipando(int id)
        {
            List<AmigoOcultoDTO> list = new List<AmigoOcultoDTO>();

            var lista = usuarioAmigoOcultoRepository.GetParticipando(id).ToList();


            foreach (var item in lista )
            {
                AmigoOcultoDTO dto = new AmigoOcultoDTO();

                dto.Id_amigo_oculto = item.Id_amigo_oculto;
                dto.Nome_amigo_oculto = item.Nome_amigo_oculto;
                dto.Descricao = item.Descricao;
                dto.Data_revelacao = item.Data_revelacao;

                list.Add(dto);
            }
            return list;
        }


        [HttpGet]
        [Route("busca-por-id/{id:int}")]
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult GetUsuario(int id)
        {
            var usuario = usuarioRepository.GetOne(id);

            if (usuario == null)
                return BadRequest("Usuario não existe.");

            UsuarioDTO dto = new UsuarioDTO();

            dto.Nome = usuario.Nome;
            dto.Login = usuario.Login;
            dto.Senha = usuario.Senha;
            dto.Email = usuario.Email;

            return Ok(dto);
        }

        [HttpPost]
        [Route("logar")]
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult Login(UsuarioDTO entity)
        {
            var usuario = usuarioRepository.Login(entity.Email, entity.Senha);
            

            if (usuario == null)
            {
                return BadRequest("Usuario não existe.");
            }
            else
            {
                UsuarioDTO dto = new UsuarioDTO();
                
                dto.Id_usuario = usuario.Id_usuario;
                dto.Email = usuario.Email;
                dto.Senha = usuario.Senha;
                dto.Nome = usuario.Nome;
                dto.Telefone = usuario.Telefone;
                dto.Cidade = usuario.Cidade;
                dto.Estado = usuario.Estado;
                dto.Data_nascimento = usuario.Data_nascimento;
                dto.Login = usuario.Login;

                return Ok(dto);
            }
        }

        [HttpGet]
        [Route("busca-por-nome")]
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult GetName(string nome)
        {
            var usuario = usuarioRepository.GetName(nome);

            if (usuario == null)
                return BadRequest("Usuario não existe.");

            UsuarioDTO dto = new UsuarioDTO();

            dto.Nome = usuario.Nome;
            dto.Login = usuario.Login;
            dto.Senha = usuario.Senha;
            dto.Email = usuario.Email;

            return Ok(dto);
        }
       

        [HttpPut]
        [Route("editar/{id:int}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsuario(int id, UsuarioDTO dto)
        {
            Usuario usuario = new Usuario();

            if (id != dto.Id_usuario)
            {
                return BadRequest();
            }
            
            try
            {
                var updatedUser = dataModel.Usuario.SingleOrDefault(x => x.Id_usuario == id);

                updatedUser.Nome = dto.Nome;
                updatedUser.Login = dto.Login;
                updatedUser.Senha = dto.Senha;
                updatedUser.Fk_perfil = dto.Fk_perfil;
                updatedUser.Estado = dto.Estado;
                updatedUser.Cidade = dto.Cidade;
                updatedUser.Email = dto.Email;
                updatedUser.Telefone = dto.Telefone;
                updatedUser.Data_nascimento = dto.Data_nascimento;
                
                dataModel.Entry(updatedUser).State = EntityState.Modified;
                dataModel.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return StatusCode(HttpStatusCode.NoContent);
        }


        [HttpPost]
        [Route("cadastrar")]
        [ResponseType(typeof(UsuarioDTO))]
        public IHttpActionResult PostUsuario(UsuarioDTO usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            usuarioRepository.Save(usuario);

            return Created("DefaultApi", usuario);
        }

        [HttpDelete]
        [Route("deletar/{id:int}")]
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult DeleteUsuario(int id)
        {
            usuarioRepository.Delete(id);

            return Ok();

        }

        private bool UsuarioExists(int id)
        {

            return usuarioRepository.GetOne(id) != null;
        }

        
    }
}