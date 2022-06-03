namespace Gateway.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<AuthToken> Login()
        {
            var user = new AuthUser { Username = "weather", Password = "weather"};
            return new ApiTokenService().GenerateToken(user);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<AuthToken> Login([FromBody] AuthUser user)
        {
            if (user.Username != "weather" || user.Password != "weather")
            {
                return BadRequest(new { message = "Username or Password is invalid" });
            }

            return new ApiTokenService().GenerateToken(user);
        }
    }
}