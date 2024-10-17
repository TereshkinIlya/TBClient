
namespace Core.Interfaces
{
    public interface IDataContext<out TDataBase> where TDataBase : class
    {
        TDataBase DataBase { get; }
    }
}
