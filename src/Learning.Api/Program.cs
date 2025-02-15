using Serilog;
using Serilog.Exceptions;
using Serilog.Sinks.GoogleCloudLogging; // Import the sink


var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration
    //.AddJsonFile("appsettings.json", optional: true)
    .AddEnvironmentVariables(); 

builder.Host.UseSerilog((context, services, configuration) => configuration
    .ReadFrom.Configuration(context.Configuration)
    .ReadFrom.Services(services)
    .Enrich.FromLogContext()
    .Enrich.WithExceptionDetails()
    .Enrich.WithEnvironmentName());

Log.Information("Serilog has started.....!"); // Or Log.Debug, Log.Information, etc.


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();
