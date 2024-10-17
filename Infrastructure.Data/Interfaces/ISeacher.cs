
namespace Infrastrucrure.Interfaces
{
    internal interface ISeacher<TRezult, TRequest>
    {
        Task<TRezult> GetDataAsync(TRequest request);
    }
}
