using AppDelivery.Api.Filters;
using AppDelivery.Api.Middleware;
using AppDelivery.Application;
using AppDelivery.Application.Services.WebSocketDeliveryTrackingService;
using AppDelivery.Infrastructure;
using AppDelivery.Infrastructure.Extensions;
using AppDelivery.Infrastructure.Migrations;
using Microsoft.AspNetCore.WebSockets;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddWebSockets(options =>
{
    options.KeepAliveInterval = TimeSpan.FromMinutes(2);
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseWebSockets();
app.UseMiddleware<CultureMiddleware>();
app.UseMiddleware<WebSocketMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//MigrateDatabase();

app.Run();
void MigrateDatabase()
{
    var connectionString = builder.Configuration.ConnectionString();

    var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();

    DatabaseMigration.Migrate(connectionString, serviceScope.ServiceProvider);
}
