var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityServer(options =>
{
    options.Events.RaiseErrorEvents = true;
    options.Events.RaiseInformationEvents = true;
    options.Events.RaiseFailureEvents = true;
    options.Events.RaiseSuccessEvents = true;

    options.EmitStaticAudienceClaim = true;
// }).AddTestUsers(new List<TestUser>())
//   .AddInMemoryClients(new List<Client>())
//   .AddInMemoryApiResources(new List<ApiResource>())
//   .AddInMemoryApiScopes(new List<ApiScope>())
//   .AddInMemoryIdentityResources(new List<IdentityResource>());
}).AddTestUsers(TestUsers.Users)
  .AddInMemoryClients(Config.Clients)
  .AddInMemoryApiResources(Config.ApiResources)
  .AddInMemoryApiScopes(Config.ApiScopes)
  .AddInMemoryIdentityResources(Config.IdentityResources);

var app = builder.Build();
app.UseIdentityServer();

app.MapGet("/", () => "Welcome to Identity Server");

app.Run();
