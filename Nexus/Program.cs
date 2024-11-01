using _Nexus.Services.MLRecommendationService;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Nexus.Configuration;
using Nexus.Extensions;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;
APIConfiguration appConfiguration = new();
configuration.Bind(appConfiguration);

builder.Services.Configure<APIConfiguration>(configuration);

builder.Services.AddSwagger(appConfiguration);

builder.Services.AddHealthChecks();
builder.Services.AddMongoDbContext(appConfiguration);
builder.Services.AddScoped<RecommendationEngine>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddUseCases();
builder.Services.AddRepositories();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/health-check", new HealthCheckOptions()
{
    Predicate = _ => true,
    ResponseWriter = HealthCheckExtensions.WriteResponse
});

app.Run();