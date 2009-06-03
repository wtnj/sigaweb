using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;

namespace SigaObjects.Comunicacao
{
    public class Email
    {
        private MailMessage mail = null;
        private SmtpClient client = null;

        public Email()
            //string Host, string Port, string usuario,
            //string senha, string Subject, string From,string Body,
            //List<string> To, List<string> CC, List<string> Bcc)
        {
            //Configuração da Mensagem
            mail = new MailMessage();

            StringBuilder str = new StringBuilder();
            str.AppendLine("Email de Teste");
            str.AppendLine("Email de Teste");

            mail.From = new MailAddress("mario.pimenta@carralero.com.br");
            mail.To.Add(new MailAddress("mariopimenta@ig.com.br"));
            mail.Subject = "C#";
            mail.Body = str.ToString();

            //Configuração do Smtp
            client = new SmtpClient();
            client.Host = "mail.carralero.com.br";
            client.Port = 25;
            client.Credentials = new System.Net.NetworkCredential("mario.pimenta@carralero.com.br", "mpr@123");
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

        private void addTo(List<string> emails)
        {
            foreach (string email in emails)
                mail.To.Add(new MailAddress(email));
        }
        private void addCC(List<string> emails)
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