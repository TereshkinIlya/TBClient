
namespace Core.Interfaces
{
    internal interface IElasticRepository<IEntity>
    {
        Task<IEnumerable<IEntity>> GetByTextAsync(string text);
    }

}