using ExceptionsLibrary.Interfaces;
using ExceptionsLibrary.Middleware;
using OrderService.Api.Mapping;
using OrderService.Application.Services;
using OrderService.Infrastructure.Data;
using OrderService.Infrastructure.Repositories;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureApplicationContext(builder.Configuration);
builder.Services.ConfigureServices();
builder.Services.ConfigureRepositories();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Services.AddLogging(options => { options.AddSerilog(); });
builder.Services.AddSingleton<IGlobalExceptionMapper, GlobalExceptionMapper>();

var app = builder.Build();

app.UseMiddleware<LoggingMiddleware.Middleware.LoggingMiddleware>();
app.UseMiddleware<GlobalExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Services.GetRequiredService<IHostApplicationLifetime>()
    .ApplicationStarted.Register(async () =>
    {
        using var scope = app.Services.CreateScope();
        await scope.ServiceProvider.GetRequiredService<ApplicationContext>().MigrateAsync();
    });

app.MapControllers();

app.Run();