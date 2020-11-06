
    /// <summary>
    /// 
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<string>> SendMessage([FromBody] EmailEntity emailEntity)
        {
            try
            {
                var mail = new MailMessage();
                var smtp = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress(emailEntity.From);
                mail.To.Add(emailEntity.To);
                mail.Subject = "Assunto do texto";
                mail.Body = emailEntity.Message;


                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("username", "password");

                await smtp.SendMailAsync(mail);
                return Ok(new { message = "Email enviado com sucesso" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }