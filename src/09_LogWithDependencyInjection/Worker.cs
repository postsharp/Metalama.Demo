using Microsoft.Extensions.Hosting;

namespace Demo1;

partial class Worker : BackgroundService
{
    [Log]
    protected override Task ExecuteAsync( CancellationToken stoppingToken )
    {
        Console.WriteLine( "Hello, world." );

        return Task.CompletedTask;
    }
}