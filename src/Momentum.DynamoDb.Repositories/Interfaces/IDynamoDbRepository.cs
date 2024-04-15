using Momentum.Repositories.Interfaces;

namespace Momentum.DynamoDb.Repositories.Interfaces
{
    public interface IDynamoDbRepository<TId, T, TConfig> : IRepository<TId, T>
        where TConfig : IDynamoDbRepositoryConfiguration
    {        
    } // end interface
} // end namespace