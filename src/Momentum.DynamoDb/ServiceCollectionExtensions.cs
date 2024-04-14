using Microsoft.Extensions.DependencyInjection;
using Momentum.DynamoDb.Client;
using Momentum.DynamoDb.Client.Interfaces;

namespace Momentum.DynamoDb
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDynamoDbClientFactory(this IServiceCollection services)
        {
            return services            
                .AddSingleton<IDynamoClientConfiguration, DynamoClientConfiguration>()
                .AddSingleton<IDynamoDBClientFactory, DynamoDbClientFactory>();
        } // end method
    } // end class
} // end namespace