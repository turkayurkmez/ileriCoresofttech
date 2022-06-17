using LoggingSample.Infrastructure;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Logging.ClearProviders();
var config = new ColoredConsoleLoggingConfiguartion { LogLevel = LogLevel.Information };
builder.Logging.AddProvider(new ColoredConsoleLoggerProvider(config));
builder.Logging.SetMinimumLevel(LogLevel.Trace);
builder.WebHost.UseNLog();

/*
 * Özel bir Logger Configuration yapmak istiyoruz buna göre yazı rengi farklı bir yapı oluşturacağız.
 */

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
