using EmailSender.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EmailSender.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class EnviarEmailController : ControllerBase
    {
        private readonly IEmailService emailService;

        public EnviarEmailController(IEmailService emailService)
        {
            this.emailService = emailService;
        }

        [HttpGet]
        public string HelloWorld ()=> "Olá Mundo";

        [HttpPost] 
        public async Task<IActionResult> EnviaEmail([FromBody] EmailRequest request)
        {
            try
            {
            if (request == null)
                return BadRequest("Dados da requisição inválidos.");

                await emailService.EnviarEmail(request.Mensagem, request.Destinatario, request.Assunto);

                return Ok($"Email enviado com sucesso com a mensagem abaixo: \n {request.Mensagem}");
            }
            catch(Exception)
            {
                return BadRequest("Houve uma exceção ao tentar executar o endpoint.");
            }
        }
    }

    public class EmailRequest
    {
        public string Destinatario { get; set; } = "";
        public string Mensagem { get; set; } = "";
        public string Assunto { get; set; } = "";
    }
}
