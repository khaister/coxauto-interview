using System;
using BLL.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class BllServicesExtensions
    {
        public static IServiceCollection AddBllServices(this IServiceCollection services)
        {
            return services
                .AddScoped<IAnswerSubmissionService, AnswerSubmissionService>()
                .AddSwaggerClientServices();
        }
    }
}
