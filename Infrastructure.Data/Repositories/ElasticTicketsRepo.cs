using Core.Interfaces;
using Elastic.Clients.Elasticsearch;
using Entities;
using Entities.Elastic;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastrucrure.Repositories
{
    internal class ElasticTicketsRepo : IElasticRepository<IEntity>
    {
        private IDataContext<ElasticsearchClient> ElasticContext { get; set; }
        public ElasticTicketsRepo([FromKeyedServices("ElasticDB")] IDataContext<ElasticsearchClient> elasticRepository)
        {
            ElasticContext = elasticRepository;
        }
        public async Task<IEnumerable<IEntity>> GetByTextAsync(string text)
        {
            SearchResponse<Tickets> response = await ElasticContext.DataBase.SearchAsync<Tickets>(s => s
            .Index("tickets")
                .Size(1000)
                    .Query(q => q
                        .Match(mq => mq
                            .Field(f => f.passenger_name)
                                .Query(text))));

            return response.Documents; 
        }
    }
}
