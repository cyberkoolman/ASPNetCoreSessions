namespace Gateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<AuthToken> Login()
        {
            var user = new AuthUser { Username = "Randy", Password = "908798"};
            return new ApiTokenService().GenerateToken(user);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<AuthToken> Login([FromBody] AuthUser user)
        {
            if (user.Username != "weatherman" || user.Password != "weatherman")
            {
                return BadRequest(new { message = "Username or Password is invalid" });
            }

            return new ApiTokenService().GenerateToken(user);
        }
    }
}