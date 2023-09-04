using BrewVerse.API.Config;

var builder = WebApplication.CreateBuilder(args);

// Configuration setup
var configuration = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

// Add services to the container
ServicesConfig.ConfigureServices(builder.Services, configuration);

var app = builder.Build();

// Configure the HTTP request pipeline
PipelineConfig.ConfigurePipeline(app, app.Environment);

app.Run();
