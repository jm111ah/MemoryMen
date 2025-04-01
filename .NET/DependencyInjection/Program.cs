

using DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddScoped<IDbContext, DbContext>();
    })
    .Build();


var greeter = host.Services.GetRequiredService<IDbContext>();
Console.WriteLine(greeter.GetName());
