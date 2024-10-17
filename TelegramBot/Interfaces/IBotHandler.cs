using Telegram.Bot.Types;
using Telegram.Bot;

namespace TelegramBot.Interfaces
{
    internal interface IBotHandler<THandler> :IBotErrorHandler,IBotUpdateHandler where THandler: class
    {
        THandler GetBotHandler();
    }
    internal interface IBotUpdateHandler
    {
        Task UpdateHandler(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken);
    }
    internal interface IBotErrorHandler
    {
        Task ErrorHandler(ITelegramBotClient botClient, Exception error, CancellationToken cancellationToken);
    }
}
