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
    public class SorteioRepository : BaseRepositoy
    {
        public Sorteio GetOne(int id)
        {
            return DataModel.Sorteio.FirstOrDefault(e => e.Id_sorteio == id);
        }

        public List<Sorteio> GetAll()
        {
            return DataModel.Sorteio.ToList();
        }
        
        public void Delete(int id)
        {
            var sorteio = GetOne(id);
            DataModel.Sorteio.Remove(sorteio);

            DataModel.SaveChanges();

        }
        public void SendMail(string email, string nome, string saiuCom, string descricao, DateTime dataRevelacao, string nomeAmgOculto)
        {
            SmtpClient SmtpServer = new SmtpClient("smtp.live.com");
            var mail = new MailMessage();
            mail.From = new MailAddress("amigosecretosaso@hotmail.com");
            mail.To.Add(email);
            mail.Subject = "SASO";
            mail.IsBodyHtml = true;
            string htmlBody;
            htmlBody = "Saudações " + nome + ", você está participando do Sorteio " 
                + nomeAmgOculto + " que contem a seguinte descrição: '" + descricao + "'. A revelação ocorrerá na seguinte data: "
                + dataRevelacao + " . O sorteio já foi relaizado e você saiu com : " + saiuCom + " . Boa sorte! Não se atrase =)";
            mail.Body = htmlBody;
            SmtpServer.Port = 587;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new System.Net.NetworkCredential("amigosecretosaso@hotmail.com", "Sasoamigosecreto");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
        }

        public void Save(Sorteio entity)
        {
            DataModel.Entry(entity).State = entity.Id_sorteio == 0 ?
                EntityState.Added : EntityState.Modified;

            DataModel.SaveChanges();

        }
        public List<SorteioDTO> NomearSorteio(int id)
        {
            List<SorteioDTO> lista = new List<SorteioDTO>();
            var sorteio = GetOne(id);
            
            var usuario = new UsuarioRepository().GetUsuarioFim(sorteio.Fk_usuario_fim);
        
                SorteioDTO dto = new SorteioDTO();
                dto.Fk_amigo_oculto = sorteio.Fk_amigo_oculto;

                dto.UsuarioInicio = sorteio.Usuario.Nome;
                dto.UsuarioEmail = sorteio.Usuario.Email; // pegar esse email e enviar o dto.usuarioFim

                dto.Fk_usuario_inicio = sorteio.Fk_usuario_inicio;
                dto.Fk_usuario_fim = sorteio.Fk_usuario_fim;
                dto.UsuarioFim = usuario.Nome;

            lista.Add(dto);

            return lista;
        }
    }
}