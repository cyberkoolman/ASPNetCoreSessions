public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope("todoapi.read"),
            new ApiScope("todoapi.write"),
        };

    public static IEnumerable<ApiResource> ApiResources => new[]
    {
        new ApiResource("todoapi")
        {
            Scopes = new List<string> {"todoapi.read", "todoapi.write"},
            ApiSecrets = new List<Secret> {new Secret("ScopeSecret".Sha256())},
            UserClaims = new List<string> {"role"}
        }
    };
    
    public static IEnumerable<Client> Clients =>
        new Client[]
        {
            // m2m client credentials flow client
            new Client
            {
                ClientId = "m2m.client",
                ClientName = "Client Credentials Client",

                AllowedGrantTypes = GrantTypes.ClientCredentials,

                ClientSecrets = { new Secret("A0000000-B000-C000-D000-E00000000000".Sha256()) },
                AllowedScopes = {"todoapi.read", "todoapi.write"}
            }
        };
}
