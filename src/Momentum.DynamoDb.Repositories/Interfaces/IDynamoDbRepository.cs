using Momentum.Repositories.Interfaces;

namespace Momentum.DynamoDb.Repositories.Interfaces
{
    public interface IDynamoDbRepository<TId, T> : IRepository<TId, T>
    {
        
    } // end interface
} // end namespace