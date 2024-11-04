using _Nexus.Services.MLRecommendationService;
using _Nexus.Services.SecurityService;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Nexus.Configuration;
using Nexus.Extensions;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;
APIConfiguration appConfiguration = new();
configuration.Bind(appConfiguration);

var token = configuration["Authentication:Token"]; 

builder.Services.AddAuthentication("Bearer") 
    .AddScheme<TokenAuthenticationOptions, TokenAuthenticationHandler>("Bearer", options =>
    {
        options.Token = token; 
    });

builder.Services.Configure<APIConfiguration>(configuration);
builder.Services.AddSwagger(appConfiguration);
builder.Services.AddHealthChecks();
builder.Services.AddMongoDbContext(appConfiguration);
builder.Services.AddScoped<RecommendationEngine>();
builder.Services.AddControllers();
builder.Services.AddServices();
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

app.UseAuthentication(); 
app.UseAuthorization();

app.UseMiddleware<TokenAuthenticationMiddleware>(token); 
app.MapControllers();

app.MapHealthChecks("/health-check", new HealthCheckOptions()
{
    Predicate = _ => true,
    ResponseWriter = HealthCheckExtensions.WriteResponse
});

app.Run();
