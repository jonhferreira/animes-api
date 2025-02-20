using AnimesAPI.Application.DTO;
using AnimesAPI.Domain.Interfaces.Abstractions;
using AnimesAPI.Domain.Interfaces.Repositories;
using AnimesAPI.Infrastructure.Data.Context;
using AnimesAPI.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AnimesAPI.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddContext(this IServiceCollection services, IConfiguration configuration)
        {
            #region Connection
            string variable = configuration.GetConnectionString("ANIME_CONNECTION_STRING") ?? throw new Exception($"Nenhuma conexão foi definida.");
            string connection = Environment.GetEnvironmentVariable(variable) ?? throw new Exception($"Erro ao recuperar a variável de conexão ao banco de dados.");

            services.AddDbContext<AnimesDBContext>(options => options.UseSqlServer(connection));
            #endregion
        }

        public static void AddDependencies(this WebApplicationBuilder builder)
        {

            AddRepository(builder);
            AddMediate(builder);
            AddTransient(builder);
        }

        private static void AddRepository(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IAnimeRepository, AnimeRepository>();
        }

        public static void AddTransient(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IErrorMessage, ErrorMessage>();
            builder.Services.AddTransient<ISuccessMessage, SuccessfulMessage>();
            builder.Services.AddTransient<MessageGet, MessageGet>();
            builder.Services.AddTransient<MessagePost, MessagePost>();
            builder.Services.AddTransient<MessageDelete, MessageDelete>();
            builder.Services.AddTransient<MessageUpdate, MessageUpdate>();
        }

        private static void AddMediate(WebApplicationBuilder builder)
        {
            var myhandlers = AppDomain.CurrentDomain.Load("AnimesAPI.Application");
            builder.Services.AddMediatR(c => c.RegisterServicesFromAssemblies(myhandlers));
        }
    }
}
