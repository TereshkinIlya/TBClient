using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using TelegramBot.Interfaces;

namespace TelegramBot
{
    internal class TgBotClient : IBotClient<TgBotClient>
    {
        private string _apiKey = "7120770756:AAH3qRkJ_7_rInr-CM8CL6MhqYIIgClYYtM";
        public ReceiverOptions ReceiverOptions { get; private set; }
        public TelegramBotClient? BotClient { get; private set; }
        public TgBotClient()
        {
            ReceiverOptions = new ReceiverOptions
            {
                AllowedUpdates = new[]
            {
                UpdateType.Message,
            },
                ThrowPendingUpdates = true,
            };
        }
        public TgBotClient GetBot()
        {
            if (BotClient != null)
                return this;
            else
            {
                BotClient = new TelegramBotClient(_apiKey)
                {
                    Timeout = TimeSpan.FromSeconds(90)
                };
                
                return this;
            }
        }
    }
}
