using Microsoft.Extensions.DependencyInjection;

namespace BLL_USER.Configurations;

public static class AutoMapperRecorder
{
    public static IServiceCollection AddMapper(this IServiceCollection services) => services
        .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
}