using Amazon.DynamoDBv2.Model;

namespace Momentum.DynamoDb.Repositories
{
    public static class PutItemRequestExtensions
    {
        public static PutItemRequest PreventUpdate(this PutItemRequest request, string partitionKey, string? rangeKey = null)
        {
            if(string.IsNullOrWhiteSpace(partitionKey))
            {
                throw new ArgumentNullException(nameof(partitionKey));
            } // end if

            request.ExpressionAttributeNames = new Dictionary<string, string>()
            {
                { "#hash_key", "key" }
            };

            if(string.IsNullOrWhiteSpace(rangeKey))
            {
                request.ExpressionAttributeNames.Add("#range_key", rangeKey);
            } // end if

            request.ConditionExpression = "attribute_not_exists(#hash_key) AND attribute_not_exists(#range_key)";

            return request;
        } // end method

        public static PutItemRequest PreventInsert(this PutItemRequest request, string partitionKey, string? rangeKey = null)
        {
            if(string.IsNullOrWhiteSpace(partitionKey))
            {
                throw new ArgumentNullException(nameof(partitionKey));
            } // end if

            request.ExpressionAttributeNames = new Dictionary<string, string>()
            {
                { "#hash_key", "key" }
            };

            if(string.IsNullOrWhiteSpace(rangeKey))
            {
                request.ExpressionAttributeNames.Add("#range_key", rangeKey);
            } // end if

            request.ConditionExpression = "attribute_exists(#hash_key) AND attribute_exists(#range_key)";

            return request;
        } // end method
    } // end class
} // end namespace