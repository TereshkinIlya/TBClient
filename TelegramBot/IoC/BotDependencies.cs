using Microsoft.Extensions.DependencyInjection;
using TelegramBot.Interfaces;

namespace TelegramBot.IoC
{
    public static class BotDependencies
    {
        public static void SetupBotDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IBotClient<TgBotClient>, TgBotClient>();
            services.AddSingleton<IBotHandler<TgBotHandler>, TgBotHandler>();
            services.AddSingleton<IBotLauncher, TgBotLauncher>();
            services.AddSingleton<IView, TgBotFacade>();
        }
    }
}
