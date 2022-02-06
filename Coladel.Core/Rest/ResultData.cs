using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coladel.Core.Rest
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ResultData
    {
        public List<string> Messages { get; set; }
        public object Data { get; set; }
        public int? TotalCount { get; set; }
        public int? Pages { get; set; }
        public int? Count { get; set; }
        public int? Page { get; set; }
    }
}
