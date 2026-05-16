
using BikeStore.Infrastructure;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();


// add intrasrtusture extention
builder.Services.AddInfrastructure(builder.Configuration);

// Add logging (default providers are already added, but you can configure here if needed)
builder.Logging.AddConsole();

// Add ProblemDetails middleware for better error handling
builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler();
}

app.UseHttpsRedirection();
app.UseRouting();

// for api end points enabling authorization if needed in the future
app.MapControllers();

// Example usage of logging in a minimal API endpoint
app.MapGet("/health", async (ILoggerFactory loggerFactory) =>
{
    var logger = loggerFactory.CreateLogger("HealthEndpoint");
    logger.LogInformation("Health check endpoint was called.");
    return new { status = true, messaeg = "Healthy" };
});

await app.RunAsync();
