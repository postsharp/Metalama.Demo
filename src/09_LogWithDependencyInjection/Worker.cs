using Microsoft.Extensions.Hosting;

partial class Worker : BackgroundService
{
    [Log]
    protected override Task ExecuteAsync( CancellationToken stoppingToken )
    {
        Console.WriteLine( "Hello, world." );

        return Task.CompletedTask;
    }
}


