using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Momentum.DynamoDb.Attributes;

namespace Momentum.DynamoDb.Examples
{
    public class MyDto
    {
        //[DynamodDbAttribute("id")]
        public string Id { get; set; }
    } // end class
} // end namespace