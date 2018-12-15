using SistemaAmigoSecretoOnline.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SistemaAmigoSecretoOnline.Repository
{
    public class AmigosRepository :BaseRepositoy
    {
        public Amigos GetOne(int id)
        {
            return DataModel.Amigos.FirstOrDefault(e => e.Id_amigo == id);
        }

        public List<Amigos> GetAll()
        {
            return DataModel.Amigos.ToList();
        }
        public void Delete(int id)
        {
            var amigos = GetOne(id);
            DataModel.Amigos.Remove(amigos);

            DataModel.SaveChanges();

        }
        public void Save(Amigos entity)
        {
            DataModel.Entry(entity).State = entity.Id_amigo == 0 ?
                EntityState.Added : EntityState.Modified;

            DataModel.SaveChanges();

        }
    }
}