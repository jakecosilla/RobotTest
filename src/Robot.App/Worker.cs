using Robot.Core.Interfaces;
using Robot.Core.Models;
using System.ComponentModel;

namespace Robot.App
{
    public class Worker : BackgroundService
    {
        private readonly AppSettings _appSettings;
        private readonly ILogger<Worker> _logger;
        private readonly ICommandRunner _commandRunner;
        private readonly ISurface _surface;
       
        public Worker(AppSettings appSettings, ILogger<Worker> logger, ICommandRunner commandRunner, ISurface surface)
        {
            _appSettings = appSettings;
            _logger = logger;
            _commandRunner = commandRunner;
            _surface = surface;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var robotState = new RobotState();
            var surfaceDimension = _surface.InitializeSurface(_appSettings.SurfaceDimension.Width, _appSettings.SurfaceDimension.Length);
            robotState.SurfaceDimension = surfaceDimension;
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                    var command = Console.ReadLine();
                    _commandRunner.Execute(command.Split(), robotState);
                    await Task.Delay(1000, stoppingToken);
                }
                catch (WarningException e)
                {
                    Console.WriteLine("Message: " + e.Message);
                }
            }
        }
    }
}