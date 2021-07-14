using IO.Swagger.Api;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SwaggerClientExtensions
    {
        public static IServiceCollection AddSwaggerClientServices(this IServiceCollection services)
        {
            return services
                .AddScoped<IDataSetApi, DataSetApi>()
                .AddScoped<IDealersApi, DealersApi>()
                .AddScoped<IVehiclesApi, VehiclesApi>()
                .AddScoped<IClientApi, ClientApi>();
        }
    }
}
