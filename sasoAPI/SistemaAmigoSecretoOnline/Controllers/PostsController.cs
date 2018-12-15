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
using SistemaAmigoSecretoOnline.DTO;
using SistemaAmigoSecretoOnline.Repository;

namespace SistemaAmigoSecretoOnline.Controllers
{
    public class PostsController : ApiController
    {
        private PostRepository postRepository = new PostRepository();

        // GET: api/Posts
        public List<PostDTO> GetPost()
        {
            List<PostDTO> list = new List<PostDTO>();

            foreach (var item in postRepository.GetAll())
            {
                PostDTO dto = new PostDTO();

                dto.Id_post = item.Id_post;
                dto.Descricao_post = item.Descricao_post;
                dto.Data_post = item.Data_post;
                dto.Fk_topico = item.Fk_topico;
            //    dto.Fk_post = item.Fk_post;(erro)

                list.Add(dto);
            }
            return list;
        }


        // GET: api/Posts/5
        [ResponseType(typeof(Post))]
        public IHttpActionResult GetPost(int id)
        {
            var post = postRepository.GetOne(id);

            if (post == null)
                return BadRequest("post não existe.");

            PostDTO dto = new PostDTO();

            dto.Id_post = post.Id_post;
            dto.Descricao_post = post.Descricao_post;
            dto.Data_post = post.Data_post;
            dto.Fk_topico = post.Fk_topico;
          //  dto.Fk_post = post.Fk_post;(erro)


            return Ok(dto);
        }

        // PUT: api/Posts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPost(int id, Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != post.Id_post)
            {
                return BadRequest();
            }

            

            try
            {
                postRepository.Save(post);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
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

        // POST: api/Posts
        [ResponseType(typeof(Post))]
        public IHttpActionResult PostPost(Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            postRepository.Save(post);

            return CreatedAtRoute("DefaultApi", new { id = post.Id_post }, post);
        }

        // DELETE: api/Posts/5
        [ResponseType(typeof(Post))]
        public IHttpActionResult DeletePost(int id)
        {
            postRepository.Delete(id);

            return Ok();
        }

      

        private bool PostExists(int id)
        {
            return postRepository.GetOne(id) != null;
        }
    }
}