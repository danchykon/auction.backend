using System.Reflection;
using Auction.Application.Common.Mediator.PipelineBehaviours;
using Auction.Application.Dtos;
using Auction.Application.Mediator.Commands.Auctions;
using FastExpressionCompiler;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace Auction.Application.DependencyInjection;

public static class Application
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(mediatRServiceConfiguration =>
        {
            mediatRServiceConfiguration.Lifetime = ServiceLifetime.Scoped;

            mediatRServiceConfiguration.AddBehavior<TransactionalPipelineBehaviour<CreateAuctionCommand, AuctionDto>>();
            
            mediatRServiceConfiguration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });
        
        services.AddMapster();
        
        TypeAdapterConfig.GlobalSettings.Compiler = expression => expression.CompileFast();
        
        return services;
    }
}