using BinaryCalculator;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class BinaryCalculatorServiceCollectionExtensions
    {
        public static IServiceCollection AddBinaryCalculator(this IServiceCollection services)
        {
            services.AddTransient<IBinaryCalculator>(serviceProvider => new BinaryCalculator.BinaryCalculator(new Int32BinaryBuilder(), new AddOperator(), new SubtractOperator()));
            return services;
        }
    }
}
