using Microsoft.AspNetCore.Mvc;
using BAL;

[ApiController]
[Route("api/Email")]
public class EmailController : ControllerBase
{
    [HttpPost("add")]
    public IActionResult AddEmail([FromBody] string email)
    {
        EmailService.AddEmail(email);
        return Ok("Email added successfully.");
    }

    [HttpDelete("delete/by-id/{id}")]
    public IActionResult DeleteById(int id)
    {
        EmailService.DeleteEmailById(id);
        return Ok("Email deleted by ID.");
    }

    [HttpDelete("delete/by-address")]
    public IActionResult DeleteByAddress([FromBody] string email)
    {
        EmailService.DeleteEmailByAddress(email);
        return Ok("Email deleted by address.");
    }

    [HttpGet("all")]
    public IActionResult GetAllEmails()
    {
        var emails = EmailService.GetAllEmails();
        return Ok(emails);
    }

    [HttpGet("transactions")]
    public IActionResult GetAllTransactions()
    {
        var logs = EmailService.GetAllEmailTransactions();
        return Ok(logs);
    }

    [HttpPost("send")]
    public IActionResult SendToAll([FromBody] SendRequest request)
    {
        EmailService.SendEmailToAll(request.Sender, request.Subject, request.Body);
        return Ok("Emails sent to all.");
    }

    public class SendRequest
    {
        public string Sender { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
