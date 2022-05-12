namespace TodoApi.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _conf;

        public AuthenticationController(IConfiguration conf)
        {
            _conf = conf ?? throw new ArgumentException(nameof(conf));
        }

        [HttpPost("authenticate")]
        public ActionResult<string> Authenticate(LoginModel loginModel)
        {
            // Step 1: Validate Credential
            var user = ValidateCredential(loginModel.UserName, loginModel.Password);
            if (user == null) return Unauthorized();

            // Step 2: Create Access Token
            // Setp 2-1: Prepare Claims
            var claims = new List<Claim>();
            claims.Add(new Claim("sub", user.UserId.ToString()));
            claims.Add(new Claim("given_name", user.FirstName));
            claims.Add(new Claim("family_name", user.LastName));
            claims.Add(new Claim("role", user.Role));

            // Setp 2-2: Create Token
            var securityKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(_conf["JWT:Secret"]));
            var signingCredentials = new SigningCredentials(
                securityKey, SecurityAlgorithms.HmacSha256);
            var jwt = new JwtSecurityToken(
                _conf["JWT:Issuer"],
                _conf["JWT:Audience"],
                claims,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(5),
                signingCredentials);

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);
            return Ok(token);
        }

        private TodoUser ValidateCredential(string? userName, string? password)
        {
            // TODO: check user name & password is valid
            // For now, validate always
            return new TodoUser(1, userName ?? "", "John", "Doe", "Submitter");
        }
    }
}