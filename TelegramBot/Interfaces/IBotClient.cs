
namespace TelegramBot.Interfaces
{
    internal interface IBotClient<out TClient> where TClient: class
    {
        TClient GetBot();
    }
}
