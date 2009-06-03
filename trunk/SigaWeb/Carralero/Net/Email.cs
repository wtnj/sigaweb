using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;

namespace Carralero.Net
{
    public class Email
    {
        private MailMessage mail   = null;
        private SmtpClient  client = null;

        private void initializer(List<string> mailsTo, string subject, StringBuilder body, string mailFrom, string username, string password, string smtpHost, int smtpDoor)
        {
            //Configuração da Mensagem
            mail = new MailMessage();
            
            mail.From = new MailAddress(mailFrom); //"mario.pimenta@carralero.com.br");
            
            foreach(string mailTo in mailsTo)
                mail.To.Add(new MailAddress(mailTo));//"mariopimenta@ig.com.br"));
            
            mail.Subject = subject;
            mail.Body = body.ToString();

            //Configuração do Smtp
            client = new SmtpClient();
            client.Host = smtpHost; //"mail.carralero.com.br";
            client.Port = smtpDoor; //25;
            client.Credentials = new System.Net.NetworkCredential(username, password); //"mario.pimenta@carralero.com.br", "mpr@123");
        }
        public Email(string mailTo, string subject, StringBuilder body, string mailFrom, string username, string password, string smtpHost, int smtpDoor)
        {
            List<string> mailsTo = new List<string>();
            mailsTo.Add(mailTo);

            initializer(mailsTo,subject, body, mailFrom, username, password, smtpHost, smtpDoor);
        }
        public Email(List<string> mailsTo, string subject, StringBuilder body, string mailFrom, string username, string password, string smtpHost, int smtpDoor)
        {
            initializer(mailsTo,subject, body, mailFrom, username, password, smtpHost, smtpDoor);
        }

        public void Enviar()
        {
            try
            {
                if (mail!=null && client!=null)
                {
                    client.Send(mail);
                    Console.WriteLine("Mensgagem Enviada !");
                }
                else
                    throw new Exception("Email não configurado !");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void addTo( List<string> emails)
        {
            foreach (string email in emails)
                mail.To.Add(new MailAddress(email));
        }
        private void addCC( List<string> emails)
        {
            foreach (string email in emails)
                mail.CC.Add(new MailAddress(email));
        }
        private void addBcc(List<string> emails)
        {
            foreach (string email in emails)
                mail.Bcc.Add(new MailAddress(email));
        }
    }
}