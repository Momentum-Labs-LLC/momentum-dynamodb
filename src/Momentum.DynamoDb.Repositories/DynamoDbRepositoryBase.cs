using Microsoft.Extensions.Logging;
using Momentum.DynamoDb.Client.Interfaces;
using Momentum.DynamoDb.Repositories.Interfaces;

namespace Momentum.DynamoDb.Repositories
{
    public abstract class DynamoDbRepositoryBase<TId, T> : IDynamoDbRepository<TId, T>
    {
        protected readonly IDynamoDBClientFactory _clientFactory;
        protected readonly ILogger _logger;

        protected DynamoDbRepositoryBase(
            IDynamoDBClientFactory clientFactory,
            ILogger<DynamoDbRepositoryBase<TId, T>> logger)
        {
            _clientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        } // end method
        
        public abstract Task<T> CreateAsync(TId id, CancellationToken token = default);
        public abstract Task DeleteAsync(T item, CancellationToken token = default);
        public abstract Task<T?> GetAsync(TId id, CancellationToken token = default);
        public abstract Task<T> UpdateAsync(TId id, T item, CancellationToken token = default);
    } // end class
} // end namespace