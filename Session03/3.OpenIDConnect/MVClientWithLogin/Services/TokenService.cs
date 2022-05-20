namespace MVCClient.Services
{
   public interface ITokenService
  {
    Task<TokenResponse> GetToken(string scope);
  }

  public class TokenService : ITokenService
  {
    private readonly ILogger<TokenService> _logger;
    private readonly IOptions<TokenServerSettings> _tokenServerSettings;
    private readonly DiscoveryDocumentResponse _discoveryDocument;

    public TokenService(ILogger<TokenService> logger, IOptions<TokenServerSettings> tokenServerSettings)
    {
      _logger = logger;
      _tokenServerSettings = tokenServerSettings;
    
      using var httpClient = new HttpClient();
      _discoveryDocument = httpClient.GetDiscoveryDocumentAsync(tokenServerSettings.Value.DiscoveryUrl).Result;
      if (_discoveryDocument.IsError)
      {
        _logger.LogError($"Unable to get discovery document. Error is: {_discoveryDocument.Error}");
        throw new Exception("Unable to get discovery document", _discoveryDocument.Exception);
      }
    }

    public async Task<TokenResponse> GetToken(string scope)
    {
      using var client = new HttpClient();
      var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
      {
        Address = _discoveryDocument.TokenEndpoint,
      
        ClientId = _tokenServerSettings.Value.ClientId,
        ClientSecret = _tokenServerSettings.Value.ClientPassword,
        Scope = scope
      });      
      
      if (tokenResponse.IsError)
      {
        _logger.LogError($"Unable to get token. Error is: {tokenResponse.Error}");
        throw new Exception("Unable to get token", tokenResponse.Exception);
      }
      
      return tokenResponse;
    }
  }

  public class TokenServerSettings
  {
    public string DiscoveryUrl { get; set; }
    public string ClientId { get; set; }
    public string ClientPassword { get; set; }
    public bool UseHttps { get; set; }
  }
}