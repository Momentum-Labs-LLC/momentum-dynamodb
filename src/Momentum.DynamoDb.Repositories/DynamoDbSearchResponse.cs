using Momentum.DynamoDb.Repositories.Interfaces;
using Momentum.Repositories;

namespace Momentum.DynamoDb.Repositories
{
    public record DynamoDbSearchResponse<T> : SearchResponse<T, DynamoDbPage>, IDynamoDbSearchResponse<T>
    {
        public DynamoDbSearchResponse(IEnumerable<T>? items) : base(items)
        {
        } // end method

        public DynamoDbSearchResponse(IEnumerable<T>? items, DynamoDbPage nextPage, bool hasMore) : base(items, nextPage, hasMore)
        {
        } // end method
    } // end class
} // end namespace