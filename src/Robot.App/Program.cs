using Robot.App;
using Robot.Core.Interfaces;
using Robot.Core.Services;
using Robot.Core.Validations;



IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        var config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .Build();
        var options = config.Get<AppSettings>();
        services.AddSingleton(options)
        .AddTransient<ISurface, Surface>()
        .AddTransient<ICommand, Command>()
        .AddTransient<ICommandRunner, CommandRunner>()
        .AddTransient<IPlaceValidation, PlaceValidation>()
        .AddTransient<IMoveValidation, MoveValidation>()
        .AddTransient<ICommandValidation, CommandValidation>()
        .AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();