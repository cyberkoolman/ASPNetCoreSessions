namespace Gateway.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        [Route("weather/v2")]
        [AllowAnonymous]
        public ActionResult<AuthToken> GetAuthentication([FromBody] AuthUser user)
        {
            if (user.Username != "weatherman" || user.Password != "weatherman")
            {
                return BadRequest(new { message = "Username or Password is invalid" });
            }

            return new ApiTokenService().GenerateToken(user);
        }
    }
}