namespace Momentum.DynamoDb
{
    public class DataType
    {
        public readonly DataTypeEnum Type;
        public readonly string Descriptor;

        protected DataType(DataTypeEnum type, string descriptor)
        {
            Type = type;
            Descriptor = descriptor;
        } // end method

        public static readonly DataType NULL = new DataType(DataTypeEnum.Null, DynamoDbConstants.NULL);
        public static readonly DataType String = new DataType(DataTypeEnum.String, DynamoDbConstants.STRING);
        public static readonly DataType Number = new DataType(DataTypeEnum.Number, DynamoDbConstants.NUMBER);
        public static readonly DataType Binary = new DataType(DataTypeEnum.Binary, DynamoDbConstants.BINARY);
        public static readonly DataType Map = new DataType(DataTypeEnum.Map, DynamoDbConstants.MAP);
        public static readonly DataType List = new DataType(DataTypeEnum.List, DynamoDbConstants.LIST);
        public static readonly DataType StringSet = new DataType(DataTypeEnum.StringSet, DynamoDbConstants.STRING_SET);
        public static readonly DataType NumberSet = new DataType(DataTypeEnum.NumberSet, DynamoDbConstants.NUMBER_SET);
        public static readonly DataType BinarySet = new DataType(DataTypeEnum.BinarySet, DynamoDbConstants.BINARY_SET);

        private static readonly List<DataType> _all = new List<DataType>()
        {
            NULL,
            String,
            Number,
            Binary,
            Map,
            List,
            StringSet,
            NumberSet,
            BinarySet
        };

        public static DataType? Find(string descriptor)
        {
            return _all.FirstOrDefault(x => x.Descriptor.Equals(descriptor));
        } // end method

        public static DataType? Find(DataTypeEnum type)
        {
            return _all.FirstOrDefault(x => x.Type == type);
        } // end method
    } // end class
} // end namespace