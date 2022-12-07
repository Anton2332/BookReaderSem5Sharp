using BLL1.Interfaces;
using BLL1.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BLL1.Configurations;

public static class ServicesRegistrator
{
    public static IServiceCollection AddServices(this IServiceCollection service) => service
        .AddTransient<ICommentsService, CommentsService>()
        .AddTransient<ICommentsLikesService, CommentsLikesService>()
    ;
}