using Core.Interfaces;
using Infrastrucrure.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastrucrure.Services
{
    internal class TicketsSearcher : ISeacher<IEnumerable<IEntity>, string>
    {
        private IElasticRepository<IEntity> ElasticRepository {  get; set; }
        private IDbRepository<IEntity> DbRepository { get; set; }
        public TicketsSearcher([FromKeyedServices("ElasticTickets")] IElasticRepository<IEntity> elasticRepository,
                            [FromKeyedServices("DBtickets")] IDbRepository<IEntity> dbRepository)
        {
            ElasticRepository = elasticRepository;
            DbRepository = dbRepository;
        }
        public async Task<IEnumerable<IEntity>> GetDataAsync(string request)
        {
            IEnumerable<IEntity> elasticDocs = await ElasticRepository.GetByTextAsync(request);
            IEnumerable<IEntity> dbEntities = await DbRepository.GetByDocumentsAsync(elasticDocs);
            return dbEntities;
        }
    }
}
