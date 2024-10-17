using Core.Interfaces;
using Elastic.Clients.Elasticsearch;
using System.IO;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBot.Interfaces;

namespace TelegramBot
{
    internal class TgBotHandler : IBotHandler<TgBotHandler>
    {
        public TaskCompletionSource? TaskCompSource { get; set; }
        private IRequestHandler<Stream, string> RequestHandler { get; set; }
        public TgBotHandler(IRequestHandler<Stream, string> handler)
        {
            RequestHandler = handler;
        }
        public async Task UpdateHandler(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            try
            {
                switch (update.Type)
                {
                    case UpdateType.Message:
                        {
                            if (update?.Message?.Text != null)
                            {
                                if(update.Message.Text.Contains("/")) return;

                                var rezult = await RequestHandler.HandleRequestAsync(update.Message.Text);
                                
                                await botClient.SendDocumentAsync(update.Message.Chat.Id, new InputFileStream(rezult, "output.csv"));
                                
                                if (rezult != null) rezult.Dispose();
                            }    
                            else
                                Console.WriteLine("Необходим текстовый запрос!");
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public Task ErrorHandler(ITelegramBotClient botClient, Exception error, CancellationToken cancellationToken)
        {
            var ErrorMessage = error switch
            {
                ApiRequestException apiRequestException
                  => $"{DateTime.Now.ToString()} - Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => $"{DateTime.Now.ToString()} - {error.ToString()}"
            };
            Console.WriteLine(ErrorMessage);

            TaskCompSource?.SetResult();
            return Task.CompletedTask;
        }

        public TgBotHandler GetBotHandler()
        {
            return this;
        }
    }
}
