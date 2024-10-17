using Core.Interfaces;
using Database;
using Elastic.Clients.Elasticsearch;
using Infrastructure.Data.Elasticsearch;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataContexts.IoC
{
    public static class DataContextsDepencies
    {
        public static void SetupDataContextsDependencies(this IServiceCollection services)
        {
            services.AddDbContext<DemoContext>(options =>
                options.UseNpgsql("Host=localhost;Port=5432;Database=demo;Username=postgres;Password=12345"));

            services.AddKeyedScoped<IDataContext<ElasticsearchClient>, ElasticContext>("ElasticDB");
            services.AddKeyedScoped<IDataContext<DbContext>, DemoContext>("AirflightsDB");
        }
    }
}
