
namespace Core.Interfaces
{
    public interface IRequestHandler<TResponse, TMessage>
    {
        Task<TResponse> HandleRequestAsync (TMessage message);
    }
}
