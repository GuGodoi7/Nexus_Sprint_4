using _Nexus.Database;
using _Nexus.Models;
using _Nexus.Repository.Interface;
using _Nexus.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Nexus.Configuration;
using Nexus.UseCase;
using System.Reflection;

namespace Nexus.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services, APIConfiguration appConfiguration)
        {
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = appConfiguration.Swagger.Title,
                    Version = "v1",
                    Description = appConfiguration.Swagger.Description,
                    Contact = new OpenApiContact() { Email = appConfiguration.Swagger.Email, Name = appConfiguration.Swagger.Name }
                });

                x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    Description = "Insira o token JWT com o prefixo 'Bearer ' no campo abaixo."
                });

                x.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] {}
            }
        });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                x.IncludeXmlComments(xmlPath);
            });

            return services;
        }


        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<UsuarioUseCase>();
            services.AddScoped<ProdutoUseCase>();
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepository<UsuarioModel>, Repository<UsuarioModel>>();
            services.AddScoped<IRepository<ProdutosModel>, Repository<ProdutosModel>>();
            services.AddScoped<IRepository<UsuarioLike>, Repository<UsuarioLike>>();
            return services;
        }


        public static IServiceCollection AddMongoDbContext(this IServiceCollection services, APIConfiguration appConfiguration)
        {
            services.AddDbContext<NXContext>(options =>
            {
                options.UseMongoDB(appConfiguration.MongoDbConnectionString, appConfiguration.MongoDbDatabase);
            });
            return services;
        }
    }
}
