using Amazon.DynamoDBv2.Model;
using Microsoft.Extensions.Logging;
using Momentum.DynamoDb.Client.Interfaces;
using Momentum.DynamoDb.Repositories.Interfaces;

namespace Momentum.DynamoDb.Repositories
{
    public abstract class DynamoDbRepositoryBase<TId, T, TConfig> : IDynamoDbRepository<TId, T, TConfig>
        where TConfig : IDynamoDbRepositoryConfiguration
    {
        protected readonly IDynamoDBClientFactory _clientFactory;
        protected readonly TConfig _configuration;
        protected readonly ILogger _logger;

        protected DynamoDbRepositoryBase(
            IDynamoDBClientFactory clientFactory,
            TConfig configuration,
            ILogger<DynamoDbRepositoryBase<TId, T, TConfig>> logger)
        {
            _clientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        } // end method
        
        public virtual async Task<T> CreateAsync(T item, CancellationToken token = default)
        {
            var request = new PutItemRequest
            {
                TableName = _configuration.TableName,
                Item = await BuildDocumentAsync(item, token).ConfigureAwait(false),
            };

            if(!_configuration.AllowUpsert)
            {
                request.PreventUpdate(_configuration.PartitionKey, _configuration.RangeKey);
            } // end if

            var client = await _clientFactory.GetAsync(token).ConfigureAwait(false);
            await client.PutItemAsync(request, token).ConfigureAwait(false);

            return item;
        } // end method

        public virtual async Task DeleteAsync(T item, CancellationToken token = default)
        {
            var request = new DeleteItemRequest()
            {
                TableName = _configuration.TableName,
                Key = await BuildKeyAsync(item, token).ConfigureAwait(false)
            };            

            var client = await _clientFactory.GetAsync(token).ConfigureAwait(false);
            await client.DeleteItemAsync(request, token).ConfigureAwait(false);
        } // end method

        public virtual async Task<T?> GetAsync(TId id, CancellationToken token = default)
        {
            T result = default(T);
            var request = new GetItemRequest()
            {
                TableName = _configuration.TableName,
                Key = await BuildKeyAsync(id, token).ConfigureAwait(false)
            };

            var client = await _clientFactory.GetAsync(token).ConfigureAwait(false);
            var getItemResponse = await client.GetItemAsync(request, token).ConfigureAwait(false);
            if(getItemResponse.Item != null)
            {
                result = await ReadDocumentAysnc(getItemResponse.Item, token).ConfigureAwait(false);
            } // end if

            return result;
        } // end method

        public virtual async Task<T> UpdateAsync(T item, CancellationToken token = default)
        {
            var request = new PutItemRequest
            {
                TableName = _configuration.TableName,
                Item = await BuildDocumentAsync(item, token).ConfigureAwait(false),
            };

            if(!_configuration.AllowUpsert)
            {
                request.PreventInsert(_configuration.PartitionKey, _configuration.RangeKey);
            } // end if

            var client = await _clientFactory.GetAsync(token).ConfigureAwait(false);
            var putResponse = await client.PutItemAsync(request, token).ConfigureAwait(false);

            return item;
        } // end method
        protected abstract Task<Dictionary<string, AttributeValue>> BuildKeyAsync(TId id, CancellationToken token = default);
        protected abstract Task<Dictionary<string, AttributeValue>> BuildKeyAsync(T item, CancellationToken token = default);
        protected abstract Task<Dictionary<string, AttributeValue>> BuildDocumentAsync(T item, CancellationToken token = default);
        protected abstract Task<T> ReadDocumentAysnc(Dictionary<string, AttributeValue> document, CancellationToken token = default);
    } // end class
} // end namespace