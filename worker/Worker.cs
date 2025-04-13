namespace worker;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                // nasluchiwanie zmian statusow zamowien w systemie zewnetrznym i mozliwosc aktualizacji po naszej stronie
                // w worker nie rozbijał bym na projekty, posłużym bym się "monolitem" ewentualnie stworzył klase repozytorium i reszte tutaj ewentualnie jakiś helper, starałbym się tworzć tutaj jak najmniej plików
                // uzylbym paczki System.Reactive.Linq
            }
            await Task.Delay(1000, stoppingToken);
        }
    }
}
