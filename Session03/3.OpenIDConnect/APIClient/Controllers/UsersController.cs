namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet("claims")]
        public ActionResult<List<string>> Claims()
        {
            if (this.User == null) return NotFound();
            var claims = this.User.Claims;
            if (claims.Any()) {
                var userClaims = User.Claims.Select(c => new { c.Type, c.Value });
                return Ok(userClaims);
            } else {
                return NotFound();
            }
        }
    }
}
