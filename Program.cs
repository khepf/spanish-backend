using BackEnd.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddDbContext<AnimalContext>(options =>
    options.UseNpgsql(Environment.GetEnvironmentVariable("DefaultConnection")));

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        var frontendUrl = Environment.GetEnvironmentVariable("FRONTEND_URL") ?? "http://localhost:5173"; // Use environment variable with fallback
        if (string.IsNullOrEmpty(frontendUrl))
        {
            throw new ArgumentNullException("FRONTEND_URL", "FRONTEND_URL environment variable is not set.");
        }

        builder.WithOrigins(frontendUrl)
               .AllowAnyHeader()
               .AllowAnyMethod()
               .AllowCredentials(); // Allow credentials if needed
    });
});

// Configure logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Information);

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseCors(); // Enable CORS

app.MapControllers();

// Seed the database
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AnimalContext>();
    context.Database.Migrate(); // Ensure the database is created and up-to-date
    context.Seed(); // Call the Seed method
}

// Add a logger message to verify logging
var logger = app.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation("Application has started successfully.");

app.Run();
