namespace MVCClient.Services
{
  public interface ITokenService
  {
    Task<TokenResponse> GetToken(string scope);
  }
}