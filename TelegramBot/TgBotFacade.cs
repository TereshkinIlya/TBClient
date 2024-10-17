using TelegramBot.Interfaces;

namespace TelegramBot
{
    public class TgBotFacade : IView
    {
        private IBotLauncher _botLauncher;
        public TgBotFacade(IBotLauncher botLauncher)
        {
            _botLauncher = botLauncher;
        }
        public void Run()
        {
            _botLauncher.StartAsync().Wait();
        }
    }
}
