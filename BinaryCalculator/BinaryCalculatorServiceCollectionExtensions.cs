using BinaryCalculator;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class BinaryCalculatorServiceCollectionExtensions
    {
        public static IServiceCollection AddBinaryCalculator(this IServiceCollection services)
        {
            services.AddTransient<IBinaryCalculator, BinaryCalculator.BinaryCalculator>();
            return services;
        }
    }
}
