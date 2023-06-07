using Microsoft.Extensions.Hosting;

class Worker : BackgroundService
{
    [Log]
    protected override Task ExecuteAsync( CancellationToken stoppingToken )
    {
        Console.WriteLine( "Hello, world." );

        return Task.CompletedTask;
    }
}


