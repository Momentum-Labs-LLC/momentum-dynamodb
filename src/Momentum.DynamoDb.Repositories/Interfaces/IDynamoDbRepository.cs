using Momentum.Repositories.Interfaces;

namespace Momentum.DynamoDb.Repositories.Interfaces
{
    public interface IDynamoDbRepository<TId, T, TConfig> : IRepository<TId, T>
        where TConfig : IDynamoDbRepositoryConfiguration
    {        
    } // end interface

    public interface IDynamoDbRepository<T, TConfig> : IRepository<T>, IDynamoDbRepository<Guid, T, TConfig>
        where TConfig : IDynamoDbRepositoryConfiguration
    {} // end interface

    public interface IDynamoDbLookupRepository<T, TConfig> : ILookupRepository<T>, IDynamoDbRepository<int, T, TConfig>
        where TConfig : IDynamoDbRepositoryConfiguration
    {} // end interface
} // end namespace