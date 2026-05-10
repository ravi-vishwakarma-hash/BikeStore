
using BikeStore.Infrastructure;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();

// Add Opentelemetry Service
//builder.Services.AddOpenTelemetryObservability(builder.Configuration);

// Add logging (default providers are already added, but you can configure here if needed)
// Example: builder.Logging.AddConsole();

// Configure controllers to respect the Accept header and support XML formatters
//builder.Services.AddControllers(option =>
//{
//    option.RespectBrowserAcceptHeader = true;
//}).AddXmlSerializerFormatters();

builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseRouting();

// for api end points enabling authorization if needed in the future
app.MapControllers();

// Example usage of logging in a minimal API endpoint
app.MapGet("/health", (ILoggerFactory loggerFactory) =>
{
    var logger = loggerFactory.CreateLogger("HealthEndpoint");
    logger.LogInformation("Health check endpoint was called.");
    return new { status = true, messaeg = "Healthy" };
});

await app.RunAsync();
