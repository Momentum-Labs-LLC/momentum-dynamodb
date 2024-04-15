using Momentum.DynamoDb.Repositories.Interfaces;
using Momentum.Repositories;

namespace Momentum.DynamoDb.Repositories
{
    public record DynamoDbSearchRequest : SearchRequest<DynamoDbPage>, IDynamoDbSearchRequest
    {
        public DynamoDbSearchRequest(int size) : base(size) {} // end method
        public DynamoDbSearchRequest(DynamoDbPage page, int size) : base(page, size)
        {
        } // end method
    } // end class
} // end namespace