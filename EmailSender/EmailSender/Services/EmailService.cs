using EmailSender.Interface;
using System.Net;
using System.Net.Mail;

namespace EmailSender.Services
{
    public class EmailService : IEmailService
    {

        public async Task EnviarEmail(string corpo, string destinatario, string assunto)
        {
            using var mensagem = new MailMessage();

            string email = ""; //adicione seu email aqui
            string senhaDoGoogle = ""; //adicione sua senha de app do google aqui

            mensagem.From = new MailAddress(email);
            mensagem.To.Add(destinatario);

            mensagem.ReplyToList.Add(new MailAddress(email));

            mensagem.Subject = assunto;
            mensagem.Body = corpo;
            mensagem.IsBodyHtml = true;

            using var smtp = new SmtpClient("smtp.gmail.com", 587);

            smtp.Credentials = new NetworkCredential(
                email,
                senhaDoGoogle
            );

            smtp.EnableSsl = true;

            await smtp.SendMailAsync(mensagem);          
        }
    }
}
