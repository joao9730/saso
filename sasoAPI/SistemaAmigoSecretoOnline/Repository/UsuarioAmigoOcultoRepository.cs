using AutoMapper;
using SistemaAmigoSecretoOnline.DTO;
using SistemaAmigoSecretoOnline.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SistemaAmigoSecretoOnline.Repository
{
    public class UsuarioAmigoOcultoRepository :BaseRepositoy
    {
        public Usuario_Amigo_Oculto GetOne(int id)
        {
            return DataModel.Usuario_Amigo_Oculto.FirstOrDefault(e => e.Id_usuario_amigo_oculto == id);
        }

        public List<Usuario_Amigo_Oculto> GetAllByIdAmigoOculto(int id)
        {
            return DataModel.Usuario_Amigo_Oculto.Where(e => e.Fk_amigo_oculto == id).ToList();

        }
        public List<Sorteio> GetAllSorteioById(int id)
        {
            return DataModel.Sorteio.Where(e => e.Fk_amigo_oculto == id).ToList();

        }
        public List<Amigo_Oculto> GetUserNaoParticipa(int id)
        {
            List<Amigo_Oculto> grupos = new List<Amigo_Oculto>();

            var userAmgOculto = DataModel.Usuario_Amigo_Oculto.Where
                (x => x.Fk_usuario == id).ToList();
            var getAll = new AmigoOcultoRepository().GetAll().ToList();
            foreach (var item in userAmgOculto)
            {
                var amgOculto = DataModel.Amigo_Oculto.Where(e => e.Id_amigo_oculto == item.Fk_amigo_oculto).First();
                grupos.Add(amgOculto);
            }
            var differences1 = getAll.Except(grupos).ToList();
            var differences2 = grupos.Except(getAll).ToList();
            //var overAllDifferences = differences1.Union(differences2).ToList();
           
            return differences2;

            
        }

        public List<Usuario_Amigo_Oculto> GetAll()
        {
            return DataModel.Usuario_Amigo_Oculto.ToList();
        }

        public List<Usuario> ListaParticipantes(int id)
        {
            List<Usuario> participantes = new List<Usuario>();

            var resultado = DataModel.Usuario_Amigo_Oculto.Where
                (x => x.Fk_amigo_oculto == id).ToList();

            foreach (var item in resultado)
            {
                var participante = DataModel.Usuario.Where(x => x.Id_usuario == item.Fk_usuario).First();
                participantes.Add(participante);
            }

            return participantes;
        }
        
        public List<Amigo_Oculto> GetParticipando(int id)
        {

            List<Amigo_Oculto> grupos = new List<Amigo_Oculto>();

            var resultado = DataModel.Usuario_Amigo_Oculto.Where
                (x => x.Fk_usuario == id).ToList();

            foreach (var item in resultado)
            {
              var grupo = DataModel.Amigo_Oculto.Where(x => x.Id_amigo_oculto == item.Fk_amigo_oculto).First();
                grupos.Add(grupo);
            }

            return grupos;
        }
        public void Delete(int id)
        {
            var usuario_amigo_oculto = GetOne(id);
            DataModel.Usuario_Amigo_Oculto.Remove(usuario_amigo_oculto);

            DataModel.SaveChanges();

        }
        public void Save(Usuario_Amigo_Oculto entity)
        {
            DataModel.Entry(entity).State = entity.Id_usuario_amigo_oculto == 0 ?
                EntityState.Added : EntityState.Modified;

            DataModel.SaveChanges();

        }
    }
}