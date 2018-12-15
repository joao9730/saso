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
using SistemaAmigoSecretoOnline.DTO;
using System.Web.Http.Cors;

namespace SistemaAmigoSecretoOnline.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/usuarioAmgOculto")]
    public class UsuariosAmigoOcultoController : ApiController
    {
        private UsuarioAmigoOcultoRepository usuarioAmigoOcultoRepository = new UsuarioAmigoOcultoRepository();
        private UsuarioRepository usuarioRepository = new UsuarioRepository();
        // GET: api/Usuario_Amigo_Oculto

        

        [HttpGet]
        [Route("detalhes-amg-participantes/{id:int}")]
        [ResponseType(typeof(Usuario_Amigo_Oculto))]
        public List<UsuarioDTO> GetByIdAmigoOculto(int id)
        {
            List<UsuarioDTO> list = new List<UsuarioDTO>();

              var lista = usuarioAmigoOcultoRepository.ListaParticipantes(id).ToList();

            foreach (var item in lista)
            {
                UsuarioDTO dto = new UsuarioDTO();

                dto.Id_usuario = item.Id_usuario;
                dto.Nome = item.Nome;
               // dto.Senha = item.Senha;
                dto.Email = item.Email;

                list.Add(dto);
            }
            return list;
        }
   
    

        // GET: api/Usuario_Amigo_Oculto/5
        [ResponseType(typeof(Usuario_Amigo_Oculto))]
        public IHttpActionResult GetUsuario_Amigo_Oculto(int id)
        {
            var usuarioAmigoOculto = usuarioAmigoOcultoRepository.GetOne(id);

            if (usuarioAmigoOculto == null)
                return BadRequest(" usuario  não existe.");

            UsuarioAmigoOcultoDTO dto = new UsuarioAmigoOcultoDTO();

            dto.Id_usuario_amigo_oculto = usuarioAmigoOculto.Id_usuario_amigo_oculto;
            dto.Fk_usuario = usuarioAmigoOculto.Fk_usuario;
            dto.Fk_amigo_oculto = usuarioAmigoOculto.Fk_amigo_oculto;
          
          


            return Ok(dto);
        }

        // PUT: api/Usuario_Amigo_Oculto/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsuario_Amigo_Oculto(int id, Usuario_Amigo_Oculto usuario_Amigo_Oculto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuario_Amigo_Oculto.Id_usuario_amigo_oculto)
            {
                return BadRequest();
            }

            

            try
            {
                usuarioAmigoOcultoRepository.Save(usuario_Amigo_Oculto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Usuario_Amigo_OcultoExists(id))
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

        // POST: api/Usuario_Amigo_Oculto
        [ResponseType(typeof(Usuario_Amigo_Oculto))]
        public IHttpActionResult PostUsuario_Amigo_Oculto(Usuario_Amigo_Oculto usuario_Amigo_Oculto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            usuarioAmigoOcultoRepository.Save(usuario_Amigo_Oculto);

            return CreatedAtRoute("DefaultApi", new { id = usuario_Amigo_Oculto.Id_usuario_amigo_oculto }, usuario_Amigo_Oculto);
        }

        // DELETE: api/Usuario_Amigo_Oculto/5
        [ResponseType(typeof(Usuario_Amigo_Oculto))]
        public IHttpActionResult DeleteUsuario_Amigo_Oculto(int id)
        {
            usuarioAmigoOcultoRepository.Delete(id);

            return Ok();
        }

       
        private bool Usuario_Amigo_OcultoExists(int id)
        {
            return usuarioAmigoOcultoRepository.GetOne(id) != null;
        }
    }
}