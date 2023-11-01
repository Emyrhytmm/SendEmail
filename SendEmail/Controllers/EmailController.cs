
using EmailApi.Services;
using Microsoft.AspNetCore.Mvc;
using SendEmail.Models;

namespace EmailApi.Controllers
{
    [ApiController]
    [Route("api/email")]
    public class EmailController : ControllerBase
    {
        private readonly EmailService _emailService;

        public EmailController(EmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("send")]
        public IActionResult SendEmail([FromBody] EmailRequest emailRequest)
        {
            try
            {
                _emailService.SendEmail(emailRequest.ToEmail, emailRequest.Subject, emailRequest.Message);
                return Ok("Mail başarıyla gönderilmiştir");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"E-posta gönderme hatası: {ex.Message}");
            }
        }

    }
}
