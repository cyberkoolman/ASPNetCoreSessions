var builder = WebApplication.CreateBuilder(args);

// TODO 1: Add API Service Health Check
// builder.Services.AddHealthChecks()
//     .AddCheck<ApiHealthCheck>("ApiHealth");

// TODO 2: In order to request IHttpClientFactory
// builder.Services.AddHttpClient();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// TODO 3: Provide API Service Health Check
// app.MapHealthChecks("/api/health");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
