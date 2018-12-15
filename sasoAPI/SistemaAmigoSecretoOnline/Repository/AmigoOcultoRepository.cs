using SistemaAmigoSecretoOnline.DTO;
using SistemaAmigoSecretoOnline.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace SistemaAmigoSecretoOnline.Repository
{
    public class AmigoOcultoRepository : BaseRepositoy
    {
      

        public Amigo_Oculto GetOne(int id)
            {
                return DataModel.Amigo_Oculto.FirstOrDefault(e => e.Id_amigo_oculto == id);
            }
        

            public List<Amigo_Oculto> GetAll()
            {
                return DataModel.Amigo_Oculto.ToList();
            }

          

        public void Delete(int id)
            {
                var amigo_oculto = GetOne(id);
                DataModel.Amigo_Oculto.Remove(amigo_oculto);

                DataModel.SaveChanges();

            }
            public void Save(AmigoOcultoDTO entity)
            {

            Amigo_Oculto amigoOculto = new Amigo_Oculto
            {
                Nome_amigo_oculto = entity.Nome_amigo_oculto,
                Descricao = entity.Descricao,
                Data_revelacao = entity.Data_revelacao,
                
            };

                DataModel.Entry(amigoOculto).State = entity.Id_amigo_oculto == 0 ?
                    EntityState.Added : EntityState.Modified;

                DataModel.SaveChanges();

            }
        public void participarAmg (ParticiparDTO entity)
        {
            Usuario_Amigo_Oculto usuarioAmigoOculto = new Usuario_Amigo_Oculto();
            {
                usuarioAmigoOculto.Fk_usuario = entity.Id_usuario;
                usuarioAmigoOculto.Fk_amigo_oculto = entity.Id_amigo_oculto;
            };
            DataModel.Entry(usuarioAmigoOculto).State = entity.Id_usuario_amigo_oculto == 0 ?
                EntityState.Added : EntityState.Modified;

            DataModel.SaveChanges();
        }

        public void SendMail(AmigoOcultoDTO entity)
        {
           
                SmtpClient SmtpServer = new SmtpClient("smtp.live.com");
                var mail = new MailMessage();
                mail.From = new MailAddress("amigosecretosaso@hotmail.com");
                mail.To.Add(entity.Email);
                mail.Subject = "SASO";
                mail.IsBodyHtml = true;
                string htmlBody;
                htmlBody = "Olá "+entity.Nome+", você foi convidado(a) para participar do SASO";
                mail.Body = htmlBody;
                SmtpServer.Port = 587;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("amigosecretosaso@hotmail.com", "Sasoamigosecreto");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                        
        }
        
        }
    }
