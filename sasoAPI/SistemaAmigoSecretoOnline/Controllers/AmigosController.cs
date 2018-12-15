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

namespace SistemaAmigoSecretoOnline.Controllers
{
    public class AmigosController : ApiController
    {
        private AmigosRepository amigosRepository = new AmigosRepository();

        // GET: api/Amigos
        public List<AmigosDTO> GetAmigos()
        {
            List<AmigosDTO> list = new List<AmigosDTO>();

            foreach (var item in amigosRepository.GetAll())
            {
                AmigosDTO dto = new AmigosDTO();

                dto.Id_amigo = item.Id_amigo;
                dto.Data_solicitacao = item.Data_solicitacao;
                dto.Data_confirmacao = item.Data_confirmacao;
                dto.Situacao = item.Situacao;
                dto.Fk_usuario_solicitante = item.Fk_usuario_solicitante;
                dto.Fk_usuario_destino = item.Fk_usuario_destino;
                list.Add(dto);
            }
            return list;
        }

        // GET: api/Amigos/5
        [ResponseType(typeof(Amigos))]
        public IHttpActionResult GetAmigos(int id)
        {
            var amigos = amigosRepository.GetOne(id);

            if (amigos == null)
                return BadRequest("Amigo não existe.");

            AmigosDTO dto = new AmigosDTO();

            dto.Id_amigo = amigos.Id_amigo;
            dto.Data_solicitacao = amigos.Data_solicitacao;
            dto.Data_confirmacao = amigos.Data_confirmacao;
            dto.Situacao = amigos.Situacao;
            dto.Fk_usuario_solicitante = amigos.Fk_usuario_solicitante;
            dto.Fk_usuario_destino = amigos.Fk_usuario_destino;

            return Ok(dto);
        }

        // PUT: api/Amigos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAmigos(int id, Amigos amigos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != amigos.Id_amigo)
            {
                return BadRequest();
            }

           
            try
            {
                amigosRepository.Save(amigos);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AmigosExists(id))
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

        // POST: api/Amigos
        [ResponseType(typeof(Amigos))]
        public IHttpActionResult PostAmigos(Amigos amigos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            amigosRepository.Save(amigos);

            return CreatedAtRoute("DefaultApi", new { id = amigos.Id_amigo }, amigos);
        }

        // DELETE: api/Amigos/5
        [ResponseType(typeof(Amigos))]
        public IHttpActionResult DeleteAmigos(int id)
        {
            amigosRepository.Delete(id);
            return Ok();
        }

      

        private bool AmigosExists(int id)
        {
            return amigosRepository.GetOne(id) != null;
        }
    }
}