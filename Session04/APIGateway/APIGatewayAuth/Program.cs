var builder = WebApplication.CreateBuilder(args);

// Configure Custom Authentication
builder.Services.AddAuthentication()
    .AddJwtBearer("api_auth_scheme", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("very_bad_api_secret")),
            ValidAudience = "WeatherAudience",
            ValidIssuer = "WeatherIssuer",
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    });

// Configure Gateway
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.UseOcelot();

app.Run();
