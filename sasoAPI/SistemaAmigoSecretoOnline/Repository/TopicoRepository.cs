using SistemaAmigoSecretoOnline.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SistemaAmigoSecretoOnline.Repository
{
    public class TopicoRepository : BaseRepositoy
    {
        public Topico GetOne(int id)
        {
            return DataModel.Topico.FirstOrDefault(e => e.Id_Topico == id);
        }

        public List<Topico> GetAll()
        {
            return DataModel.Topico.ToList();
        }
        public void Delete(int id)
        {
            var topico = GetOne(id);
            DataModel.Topico.Remove(topico);

            DataModel.SaveChanges();

        }
        public void Save(Topico entity)
        {
            DataModel.Entry(entity).State = entity.Id_Topico == 0 ?
                EntityState.Added : EntityState.Modified;

            DataModel.SaveChanges();

        }
    }
}