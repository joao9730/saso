using SistemaAmigoSecretoOnline.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SistemaAmigoSecretoOnline.Repository
{
    public class PostRepository : BaseRepositoy
    {
        public Post GetOne(int id)
        {
            return DataModel.Post.FirstOrDefault(e => e.Id_post == id);
        }

        public List<Post> GetAll()
        {
            return DataModel.Post.ToList();
        }
        public void Delete(int id)
        {
            var post = GetOne(id);
            DataModel.Post.Remove(post);

            DataModel.SaveChanges();

        }
        public void Save(Post entity)
        {
            DataModel.Entry(entity).State = entity.Id_post == 0 ?
                EntityState.Added : EntityState.Modified;

            DataModel.SaveChanges();

        }
    }
}