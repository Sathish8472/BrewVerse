using BeerService.API.Data;
using BeerService.API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configuration setup
var configuration = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

builder.Services.AddControllers();

// Configure services and dependency injection
builder.Services.AddDbContext<BeerDbContext>(options =>
{
    options.UseSqlite(configuration.GetConnectionString("DefaultConnection")); // Use SQLite database
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "BeerService API", Version = "v1" });
});

builder.Services.AddScoped<IBeerService, BeerService.API.Services.BeerService>(); // Add the BeerService with scoped lifetime

// Add additional services here if needed

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Show detailed error page in development
}

app.UseHttpsRedirection();

// Configure Swagger
app.UseSwagger(); // Enable Swagger JSON endpoint
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "BeerService API V1"); // Configure Swagger UI
    c.RoutePrefix = string.Empty; // Serve Swagger UI at the root URL
});

app.MapControllers(); // Map controllers to the application

app.Run();
