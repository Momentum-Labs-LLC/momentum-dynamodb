using Microsoft.Extensions.Logging;
using Momentum.DynamoDb.Client.Interfaces;
using Momentum.DynamoDb.Repositories.Interfaces;

namespace Momentum.DynamoDb.Repositories
{
    public abstract class DynamoDbSearchRepositoryBase<T, TSearchRequest, TSearchResponse, TConfig> :
            IDynamoDbSearchRepository<T, TSearchRequest, TSearchResponse>
        where TSearchRequest : IDynamoDbSearchRequest
        where TSearchResponse : IDynamoDbSearchResponse<T>
        where TConfig : IDynamoDbRepositoryConfiguration
    {
        protected readonly IDynamoDBClientFactory _clientFactory;
        protected readonly TConfig _configuration;
        protected readonly ILogger _logger;

        protected DynamoDbSearchRepositoryBase(
            IDynamoDBClientFactory clientFactory,
            TConfig configuration,
            ILogger<DynamoDbSearchRepositoryBase<T, TSearchRequest, TSearchResponse, TConfig>> logger)
        {
            _clientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        } // end method

        public abstract Task<TSearchResponse> SearchAsync(TSearchRequest request, CancellationToken token = default);
    } // end class
} // end namespace