
namespace Infrastrucrure.Interfaces
{
    internal interface IDbRepository<IEntity>
    {
        Task<IEnumerable<IEntity>> GetByDocumentsAsync(IEnumerable<IEntity> elasticDocs);

    }
}
