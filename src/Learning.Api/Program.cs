using Serilog;
using Serilog.Exceptions;
using Serilog.Sinks.GoogleCloudLogging; // Import the sink


var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration
    .AddJsonFile("config/appsettings.json", optional: true)
    .AddEnvironmentVariables()
    .Build();

// Initialize Serilog
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .Enrich.FromLogContext()
    .Enrich.WithExceptionDetails()
    .CreateLogger();

builder.Host.UseSerilog();
var appSettings = configuration.GetSection("AppSettings");
Log.Information("Serilog has started.....!");
Log.Information($"appsettings:TestConfigMap value is {appSettings.GetValue<string>("TestConfigMap")}");
// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddSwaggerGen();
}
builder.Services.AddHealthChecks(); // Add health checks


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapHealthChecks("/health");

app.Run();
