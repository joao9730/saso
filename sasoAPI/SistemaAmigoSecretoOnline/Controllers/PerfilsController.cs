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
    public class PerfilsController : ApiController
    {
        private PerfilRepository perfilRepository = new PerfilRepository();

        // GET: api/Perfils
        public List<PerfilDTO> GetPerfil()
        {
            List<PerfilDTO> list = new List<PerfilDTO>();

            foreach (var item in perfilRepository.GetAll())
            {
                PerfilDTO dto = new PerfilDTO();
                dto.Id_perfil = item.Id_perfil;
                dto.Nome = item.Nome;


                list.Add(dto);
            }
            return list;
        }

        // GET: api/Perfils/5
        [ResponseType(typeof(Perfil))]
        public IHttpActionResult GetPerfil(int id)
        {
            var perfil = perfilRepository.GetOne(id);

            if (perfil == null)
                return BadRequest(" perfil não existe.");

            PerfilDTO dto = new PerfilDTO();

            dto.Nome = perfil.Nome;
    


            return Ok(dto);
        }

    }
}