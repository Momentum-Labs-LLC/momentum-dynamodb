using Amazon.DynamoDBv2;

namespace Momentum.DynamoDb.Client.Interfaces
{
    public interface IDynamoDBClientFactory
    {
        Task<IAmazonDynamoDB?> GetAsync(CancellationToken token = default);
    } // end interface
} // end namespace