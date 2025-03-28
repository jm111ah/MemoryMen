

using DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddScoped<IGreeter, Greeter>();
    })
    .Build();


var greeter = host.Services.GetRequiredService<IGreeter>();
Console.WriteLine(greeter.GetName("MM"));
