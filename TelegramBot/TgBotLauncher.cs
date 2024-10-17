using Telegram.Bot;
using Telegram.Bot.Polling;
using TelegramBot.Interfaces;

namespace TelegramBot
{
    internal class TgBotLauncher : IBotLauncher
    {
        private TgBotHandler _botHandler;
        private TgBotClient _bot;
        public TgBotLauncher(IBotClient<TgBotClient> botClient, IBotHandler<TgBotHandler> botHandler) 
        {
            _bot = botClient.GetBot();
            _botHandler = botHandler.GetBotHandler();
        }
        public async Task StartAsync()
        {
            ReceiverOptions options = _bot.ReceiverOptions;
            try
            {
                while (true)
                    await RunAsync(options);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                _botHandler?.TaskCompSource?.SetResult();
            }
        }
        private async Task RunAsync(ReceiverOptions options)
        {
            
            using CancellationTokenSource cancellationToken = new();
            _botHandler.TaskCompSource = new();
            
            _bot.BotClient?.StartReceiving(_botHandler.UpdateHandler,
                                           _botHandler.ErrorHandler,
                                           options,
                                           cancellationToken.Token);
            Console.WriteLine($"{DateTime.Now.ToString()} - Бот запущен!");

            await _botHandler.TaskCompSource.Task;
            cancellationToken.Cancel();
        }
    }
}
