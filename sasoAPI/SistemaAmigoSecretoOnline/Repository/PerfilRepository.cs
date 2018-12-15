using SistemaAmigoSecretoOnline.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SistemaAmigoSecretoOnline.Repository
{
    public class PerfilRepository : BaseRepositoy
    {
        public Perfil GetOne(int id)
        {
            return DataModel.Perfil.FirstOrDefault(e => e.Id_perfil == id);
        }

        public List<Perfil> GetAll()
        {
            return DataModel.Perfil.ToList();
        }
        public void Delete(int id)
        {
            var perfil = GetOne(id);
            DataModel.Perfil.Remove(perfil);

            DataModel.SaveChanges();

        }
        public void Save(Perfil entity)
        {
            DataModel.Entry(entity).State = entity.Id_perfil == 0 ?
                EntityState.Added : EntityState.Modified;

            DataModel.SaveChanges();

        }
    }
}