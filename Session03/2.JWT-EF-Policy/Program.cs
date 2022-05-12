Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/jwtpolicy.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();
var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<TodoDbContext>(o => 
    o.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
);
builder.Services.AddScoped<ITodoRepository, TodoRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure Bearer Token Middleware
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(o => 
    {
        o.TokenValidationParameters = new TokenValidationParameters ()
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["JWT:Audience"],
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(builder.Configuration["JWT:Secret"]))
        };
    });

// Configure Custom Policy
builder.Services.AddAuthorization(o =>
{
    o.AddPolicy("Approver", policy => policy.RequireClaim(ClaimTypes.Role, "Teamlead"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
