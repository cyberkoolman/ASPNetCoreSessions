using Microsoft.AspNetCore.Mvc;

namespace ListUsers.Controllers
{
    [ApiController]
	[Route("api/users")]
    public class UsersController : ControllerBase
    {
        private List<Recipient> recipients = new List<Recipient> {
                new Recipient { RecipientId=1, RecipientName = "User One", RecipientEmail = "UserOne@test.com"},
                new Recipient { RecipientId=2, RecipientName = "User Two", RecipientEmail = "UserTwo@test.com"},
                new Recipient { RecipientId=3, RecipientName = "User Three", RecipientEmail = "UserThree@test.com"},
                new Recipient { RecipientId=4, RecipientName = "User Four", RecipientEmail = "UserFour@test.com"}
        };


        [HttpGet]
        public ActionResult<IEnumerable<Recipient>> GetUsers()
        {
            return recipients;
        }
		
        [HttpGet("{id}")]
        public ActionResult<Recipient> GetUser(int id)
        {
            var recipient = recipients.FirstOrDefault(user => user.RecipientId == id);
            if (recipient == null)
            {
                return NotFound();
            }
            return Ok(recipient);
        }        
    }

    public class Recipient
    {
        public int? RecipientId { get; set; }
        public string? RecipientName { get; set; }
        public string? RecipientEmail { get; set; }
    }    
}