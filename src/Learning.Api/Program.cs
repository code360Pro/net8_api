using Serilog;
using Serilog.Exceptions;
using Serilog.Sinks.GoogleCloudLogging; // Import the sink


var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration
    .AddJsonFile("appsettings.json", optional: true)
    .AddEnvironmentVariables()
    .Build();

// Initialize Serilog
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .Enrich.FromLogContext()
    .Enrich.WithExceptionDetails()
    .CreateLogger();

builder.Host.UseSerilog();

Log.Information("Serilog has started.....!");

// Add services to the container.

builder.Services.AddControllers();
Log.Information("Serilog AddControllers completed.....!");

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
Log.Information("Serilog AddEndpointsApiExplorer completed.....!");

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddSwaggerGen();
    Log.Information("Serilog AddSwaggerGen completed.....!");
}
builder.Services.AddHealthChecks(); // Add health checks


var app = builder.Build();
Log.Information("Serilog Build completed.....!");




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    Log.Information("Serilog IsDevelopment completed.....!");
}

app.UseHttpsRedirection();

Log.Information("Serilog UseHttpsRedirection completed.....!");


app.UseAuthorization();

Log.Information("Serilog UseAuthorization completed.....!");

app.MapControllers();
Log.Information("Serilog MapControllers completed.....!");

app.MapHealthChecks("/health");

app.Run();
Log.Information("Serilog Run completed.....!");
