using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ServicioEmail
    {
        private SmtpClient server;
        private MailMessage mail;

        public ServicioEmail()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("pruebasutn@outlook.com","Pruebas2023");
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.office365.com";
        }

        public void armarCorreo(string destino,string asunto,string cuerpo)
        {
            mail = new MailMessage();
            mail.From=new MailAddress("pruebasutn@outlook.com");
            mail.To.Add(destino);
            mail.Subject = asunto;
            mail.Body = cuerpo;
        }

        public void enviarMail()
        {
            try
            {
                server.Send(mail);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
