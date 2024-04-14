using Momentum.Repositories.Interfaces;

namespace Momentum.DynamoDb.Repositories.Interfaces
{
    public interface IDynamoDbSearchRepository<T, TRequest, TResponse> 
            : ISearchRepository<T, DynamoDbPage, TRequest, TResponse>
        where TRequest : IDynamoDbSearchRequest<T>
        where TResponse : IDynamoDbSearchResponse<T>
    {
    } // end interfce
} // end namespace