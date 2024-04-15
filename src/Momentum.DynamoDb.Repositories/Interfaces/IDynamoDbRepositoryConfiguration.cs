namespace Momentum.DynamoDb.Repositories.Interfaces
{
    public interface IDynamoDbRepositoryConfiguration
    {
        string TableName { get; }
        string PartitionKey { get; }
        string? RangeKey { get; }
        bool AllowUpsert { get; }
    } // end interface
} // end namespace