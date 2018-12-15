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
    public static class IListExt
    {
        static Random r = new Random(DateTime.Now.Millisecond);

        public static void Shuffle<T>(this IList<T> list)
        {
            var upperItem = list.Count;
            var lowerItem = 0;
            for (int i = lowerItem; i < upperItem; i++)
            {
                int j = r.Next(i, upperItem);
                T tmp = list[j];
                list[j] = list[i];
                list[i] = tmp;
            }
        }

    }
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Sorteio")]
    public class SorteiosController : ApiController
    {
        private SorteioRepository sorteioRepository = new SorteioRepository();
        private UsuarioAmigoOcultoRepository usuarioAmigoOcultoRepository = new UsuarioAmigoOcultoRepository();
        private AmigoOcultoRepository amigoOcultoRepository = new AmigoOcultoRepository();



        // POST: api/Sorteios
        [HttpPost]
        [Route("realizarSorteio/{id}")]
        public IHttpActionResult RealizarSorteio(int id)
        {
            List<int> listIdsUsuario = new List<int>();
            List<int> listIdSorteio = new List<int>();

            var listUsuarios = usuarioAmigoOcultoRepository.GetAllByIdAmigoOculto(id);
            var listSorteios = usuarioAmigoOcultoRepository.GetAllSorteioById(id);
            

            foreach (var usuario in listUsuarios)
            {
                listIdsUsuario.Add(usuario.Fk_usuario);
            }

            listIdsUsuario.Shuffle<int>();
            
            int i = 0;
            
            bool ok = false;

            while(!ok)
            {
                foreach (var usuario in listUsuarios)
                {
                    if (listIdsUsuario[i] == usuario.Fk_usuario)
                    {
                        listIdsUsuario.Shuffle<int>();
                        break;
                    }
                    else
                    {
                        
                        ok = true;
                    }

                }
            }


            

            i = 0;
            foreach (var usuario in listUsuarios)
            {
                int idUsuarioSorteado = listIdsUsuario[i];
                if (idUsuarioSorteado != usuario.Fk_usuario)
                {
                    Sorteio sorteio = new Sorteio();
                    sorteio.Fk_usuario_inicio = usuario.Fk_usuario;
                    sorteio.Fk_usuario_fim = idUsuarioSorteado;
                   
                    sorteio.Fk_amigo_oculto = id;
                    
                    sorteioRepository.Save(sorteio);
                    
                    i++;

                    var Idsorteio = sorteio.Id_sorteio;
                    Nomear(Idsorteio);
                }
                

            }

            return StatusCode(HttpStatusCode.NoContent);   


        }        

        // GET: api/Sorteios
        public List<SorteioDTO> GetSorteio()
        {
            List<SorteioDTO> list = new List<SorteioDTO>();

            foreach (var item in sorteioRepository.GetAll())
            {
                SorteioDTO dto = new SorteioDTO();

                dto.Id_sorteio = item.Id_sorteio;
                dto.Fk_usuario_inicio = item.Fk_usuario_inicio;
                dto.Fk_amigo_oculto = item.Fk_amigo_oculto;
                dto.Fk_usuario_fim = item.Fk_usuario_fim;


                list.Add(dto);
            }
            return list;
        }

        // GET: api/Sorteios/5
        [ResponseType(typeof(Sorteio))]
        public IHttpActionResult Nomear(int id)
        {
            var sortear = sorteioRepository.GetOne(id);
           
            if (sortear == null)
                return BadRequest("  sorteio não existe.");

            var usuarioInicio = new UsuarioRepository().GetOne(sortear.Fk_usuario_inicio);
            SorteioDTO dto = new SorteioDTO();
            var usuarioFim = new UsuarioRepository().GetUsuarioFim(sortear.Fk_usuario_fim);
            var amgOculto = new AmigoOcultoRepository().GetOne(sortear.Fk_amigo_oculto);

            dto.Fk_amigo_oculto = sortear.Fk_amigo_oculto;

            dto.UsuarioInicio = usuarioInicio.Nome;
            dto.UsuarioEmail = usuarioInicio.Email; // pegar esse email e enviar o dto.usuarioFim
            
            dto.Fk_usuario_inicio = sortear.Fk_usuario_inicio;
            dto.Fk_usuario_fim = sortear.Fk_usuario_fim;
            dto.UsuarioFim = usuarioFim.Nome;
            dto.Descricao = amgOculto.Descricao;
            dto.Data_revelacao = amgOculto.Data_revelacao;
            dto.NomeSorteio = amgOculto.Nome_amigo_oculto;
           
            // enviar email
            string email = dto.UsuarioEmail;
            string nome = dto.UsuarioInicio;
            string saiuCom = dto.UsuarioFim;
            string nomeAmgOculto = dto.NomeSorteio;
            string descricao = dto.Descricao;
            DateTime dataRevelacao = dto.Data_revelacao;
            sorteioRepository.SendMail(email, nome, saiuCom, descricao, dataRevelacao, nomeAmgOculto);

            return Ok(dto);
        }

        // PUT: api/Sorteios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSorteio(int id, Sorteio sorteio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sorteio.Id_sorteio)
            {
                return BadRequest();
            }



            try
            {
                sorteioRepository.Save(sorteio);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SorteioExists(id))
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

        // POST: api/Sorteios
        [ResponseType(typeof(Sorteio))]
        public IHttpActionResult PostSorteio(Sorteio sorteio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            sorteioRepository.Save(sorteio);

            return CreatedAtRoute("DefaultApi", new { id = sorteio.Id_sorteio }, sorteio);
        }

        // DELETE: api/Sorteios/5
        [ResponseType(typeof(Sorteio))]
        public IHttpActionResult DeleteSorteio(int id)
        {

            sorteioRepository.Delete(id);

            return Ok();
        }



        private bool SorteioExists(int id)
        {
            return sorteioRepository.GetOne(id) != null;
        }
    }
}