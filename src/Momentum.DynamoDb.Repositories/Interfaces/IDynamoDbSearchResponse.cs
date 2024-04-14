using Momentum.Repositories.Interfaces;

namespace Momentum.DynamoDb.Repositories.Interfaces
{
    public interface IDynamoDbSearchResponse<T> : ISearchResponse<T, DynamoDbPage>
    {
        
    } // end interface
} // end namespace