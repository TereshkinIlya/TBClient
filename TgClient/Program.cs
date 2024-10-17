using Microsoft.Extensions.DependencyInjection;
using TelegramBot.IoC;
using DataContexts.IoC;
using TelegramBot.Interfaces;
using Infrastrucrure.IoC;

IServiceCollection services = new ServiceCollection();

services.SetupDataContextsDependencies();
services.SetupInfrastrucrureDependencies();
services.SetupBotDependencies();

using var serviceProvider = services.BuildServiceProvider();
var launcher = serviceProvider.GetService<IView>();
launcher?.Run();