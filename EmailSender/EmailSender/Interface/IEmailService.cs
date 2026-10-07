namespace EmailSender.Interface
{
    public interface IEmailService
    {
        public Task EnviarEmail(string corpo, string destinatario, string assunto); 
    }
}
