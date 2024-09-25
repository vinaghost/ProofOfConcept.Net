// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Splat;
using Splat.Microsoft.Extensions.DependencyInjection;

var host = Host.CreateDefaultBuilder()
               .ConfigureServices((_context, services) =>
               {
                   services.UseMicrosoftDependencyResolver();
                   var resolver = Locator.CurrentMutable;
                   resolver.InitializeSplat();

                   services
                    .AddScoped<DataSerivce>()
                    .AddScoped<RandomCommand>();
               })
               .UseDefaultServiceProvider(config =>
               {
                   config.ValidateOnBuild = true;
               })
               .Build();
var container = host.Services;
container.UseMicrosoftDependencyResolver();

using (var scope = container.CreateScope())
{
    var dataService = scope.ServiceProvider.GetRequiredService<DataSerivce>();
    dataService.AccountId = 100;
    Console.WriteLine(dataService.AccountId);

    //var randomTask = Locator.Current.GetService<RandomCommand>();
    var randomTask = scope.ServiceProvider.GetRequiredService<RandomCommand>();
    randomTask?.Execute();
}