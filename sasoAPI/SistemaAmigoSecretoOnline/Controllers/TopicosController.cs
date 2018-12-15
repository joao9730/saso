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
    public class TopicosController : ApiController
    {
        private TopicoRepository topicoRepository = new TopicoRepository();

        // GET: api/Topicoes
        public List<TopicoDTO> GetTopico()
        {
            List<TopicoDTO> list = new List<TopicoDTO>();

            foreach (var item in topicoRepository.GetAll())
            {
                TopicoDTO dto = new TopicoDTO();

                dto.Id_Topico = item.Id_Topico;
                dto.Discursao = item.Discursao;
                dto.Data_inicio = item.Data_inicio;
                dto.FK_amigo_oculto = item.Fk_amigo_oculto;
                
                list.Add(dto);
            }
            return list;
        }

        // GET: api/Topicoes/5
        [ResponseType(typeof(Topico))]
        public IHttpActionResult GetTopico(int id)
        {
            var usuario = topicoRepository.GetOne(id);

            if (usuario == null)
                return BadRequest("Topico não existe.");

            TopicoDTO dto = new TopicoDTO();

            dto.Discursao = usuario.Discursao;
            dto.Data_inicio = usuario.Data_inicio;
            dto.FK_amigo_oculto = usuario.Fk_amigo_oculto;
          

            return Ok(dto);
        }

        // PUT: api/Topicoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTopico(int id, Topico topico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != topico.Id_Topico)
            {
                return BadRequest();
            }

           

            try
            {
                topicoRepository.Save(topico);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TopicoExists(id))
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

        // POST: api/Topicoes
        [ResponseType(typeof(Topico))]
        public IHttpActionResult PostTopico(Topico topico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            topicoRepository.Save(topico);

            return CreatedAtRoute("DefaultApi", new { id = topico.Id_Topico }, topico);
        }

        // DELETE: api/Topicoes/5
        [ResponseType(typeof(Topico))]
        public IHttpActionResult DeleteTopico(int id)
        {
            
           topicoRepository.Delete(id);

           return Ok();
        }

        

        private bool TopicoExists(int id)
        {
            return topicoRepository.GetOne(id) != null;
        }
    }
}