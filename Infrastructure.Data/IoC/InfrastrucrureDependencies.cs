using Core.Interfaces;
using Infrastrucrure.Interfaces;
using Infrastrucrure.Repositories;
using Infrastrucrure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastrucrure.IoC
{
    public static class InfrastrucrureDependencies
    {
        public static void SetupInfrastrucrureDependencies(this IServiceCollection services)
        {
            
            services.AddTransient<ISeacher<IEnumerable<IEntity>, string>, TicketsSearcher>();
            services.AddTransient<IRequestHandler<Stream, string>, TgBotRequestHandler>();
            services.AddTransient<IPacker<Stream, IEntity>, PackerCsv>();
            services.AddKeyedScoped<IDbRepository<IEntity>, DbTicketsRepo>("DBtickets");
            services.AddKeyedScoped<IElasticRepository<IEntity>, ElasticTicketsRepo>("ElasticTickets");
        }
    }
}
