using System.Data;
using Auction.Api.Configurations;
using Auction.Api.DependencyInjection;
using Auction.Api.Middlewares;
using Auction.Api.Routes;
using Auction.Application.DependencyInjection;
using Auction.Infrastructure.DependencyInjection;
using Auction.Infrastructure.Options;
using Auction.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Serilog;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Host.ConfigureSerilog();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApi(builder.Environment, builder.Configuration);

var app = builder.Build();

await using var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateAsyncScope();
var context = serviceScope.ServiceProvider.GetRequiredService<AuctionDbContext>();

await context.Database.MigrateAsync();

if (context.Database.GetDbConnection() is NpgsqlConnection npgsqlConnection)
{
    if (npgsqlConnection.State is not ConnectionState.Open)
    {
        await npgsqlConnection.OpenAsync();
    }
    
    try
    {
        await npgsqlConnection.ReloadTypesAsync();
    }
    finally
    {
        await npgsqlConnection.CloseAsync();
    }

}

app.UseCors(corsPolicyBuilder =>
{
    corsPolicyBuilder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
});

app.UseSerilogRequestLogging();

app.UseMiddleware<ExceptionalMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(swaggerUiOptions =>
    {
        var swaggerOptions = app.Configuration
            .GetSection(SwaggerOptions.Section)
            .Get<SwaggerOptions>()!;

        swaggerUiOptions.RoutePrefix = swaggerOptions.RoutePrefix;
        
        foreach (var swaggerEndpoint in swaggerOptions.Endpoints)
        {
            swaggerUiOptions.SwaggerEndpoint(swaggerEndpoint.Url, swaggerEndpoint.Name);
        }
    });
}

app.UseAuthentication();
app.UseAuthorization();

#region Routing

var apiGroup = app.MapGroup("api");

apiGroup
    .MapGroup("users")
    .MapUsersRoutes();

apiGroup
    .MapGroup("bids")
    .MapBidsRoutes();

apiGroup
    .MapGroup("messages")
    .MapMessagesRoutes();

apiGroup
    .MapGroup("auctions")
    .MapAuctionsRoutes();

app
    .MapGroup("lots")
    .MapLotsRoutes();

#endregion

app.Run();
