using BarService.API.Data;
using BarService.API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

using static BarService.API.Config.ServicesConfig;
using static BarService.API.Config.PipelineConfig;

var builder = WebApplication.CreateBuilder(args);

// Configuration setup
var configuration = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

// Add services to the container
ConfigureServices(builder.Services, configuration);

var app = builder.Build();

// Configure the HTTP request pipeline
ConfigurePipeline(app, app.Environment);

app.Run();


