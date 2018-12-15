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
using System.Net.Mail;

namespace SistemaAmigoSecretoOnline.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/amigoOculto")]
    public class AmigoOcultoController : ApiController
    {
        private AmigoOcultoRepository amigo_oculto_Repository = new AmigoOcultoRepository();

        // GET: api/Amigo_Oculto

        [HttpGet]
        [Route("buscar-todos/{id:int}")]
        [ResponseType(typeof(Amigo_Oculto))]
        public List<AmigoOcultoDTO> GetAmigoOculto(int id)
        {
            List<AmigoOcultoDTO> list = new List<AmigoOcultoDTO>();

            var lista = new AmigoOcultoRepository().GetAll().ToList();

            foreach (var item in lista)
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
        [Route("buscar-todos-porUser")]
        [ResponseType(typeof(Amigo_Oculto))]
        public List<AmigoOcultoDTO> GetAmigoOcultoUsuario()
        {
            List<AmigoOcultoDTO> list = new List<AmigoOcultoDTO>();

            foreach (var item in amigo_oculto_Repository.GetAll())
            {
                AmigoOcultoDTO dto = new AmigoOcultoDTO();
                //dto.Id_amigo_oculto = item.Id_amigo_oculto;
                dto.Nome_amigo_oculto = item.Nome_amigo_oculto;
                dto.Descricao = item.Descricao;
                dto.Data_revelacao = item.Data_revelacao;

                list.Add(dto);
            }
            return list;
        }

        // GET: api/Amigo_Oculto/5
        [ResponseType(typeof(Amigo_Oculto))]
        public IHttpActionResult GetAmigo_Oculto(int id)
        {
            var amigo_oculto = amigo_oculto_Repository.GetOne(id);

            if (amigo_oculto == null)
                return BadRequest("amigo oculto não existe.");

            AmigoOcultoDTO dto = new AmigoOcultoDTO();

            dto.Nome_amigo_oculto = amigo_oculto.Nome_amigo_oculto;
            dto.Descricao = amigo_oculto.Descricao;
            dto.Data_revelacao = amigo_oculto.Data_revelacao;
         

            return Ok(dto);
        }

        // PUT: api/Amigo_Oculto/5
        [HttpPut]
        [Route("editar")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAmigo_Oculto(int id, AmigoOcultoDTO amigoOculto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != amigoOculto.Id_amigo_oculto)
            {
                return BadRequest();
            }


            try
            {
                amigo_oculto_Repository.Save(amigoOculto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Amigo_OcultoExists(id))
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
        [Route("convidar")]
        [ResponseType(typeof(AmigoOcultoDTO))]
        public IHttpActionResult MandarEmail(AmigoOcultoDTO amigoOculto)
        {
            amigo_oculto_Repository.SendMail(amigoOculto);
            return Ok();
        }

        [HttpPost]
        [Route("participar")]
        [ResponseType(typeof(AmigoOcultoDTO))]
        public IHttpActionResult Participar(ParticiparDTO participar)
        {
            amigo_oculto_Repository.participarAmg(participar);
            return Ok();
        }


        // POST: api/Amigo_Oculto
        [HttpPost]
        [Route("cadastrar")]
        [ResponseType(typeof(AmigoOcultoDTO))]
        public IHttpActionResult PostAmigo_Oculto(AmigoOcultoDTO amigoOculto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            amigo_oculto_Repository.Save(amigoOculto);

            return Created("DefaultApi", amigoOculto);
                // CreatedAtRoute("DefaultApi", new { id = amigoOculto.Id_amigo_oculto }, amigoOculto);
        }

        // DELETE: api/Amigo_Oculto/5
        [ResponseType(typeof(Amigo_Oculto))]
        public IHttpActionResult DeleteAmigo_Oculto(int id)
        {
          
            amigo_oculto_Repository.Delete(id);

            return Ok();

            
        }

        private bool Amigo_OcultoExists(int id)
        {
            return amigo_oculto_Repository.GetOne(id) != null;
        }

        
    }
}