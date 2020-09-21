using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatAPI.ReturnObjects
{
    public class GenericReturnObject<T> : GenericReturnObjectBase where T : class
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "values")]
        public T Values { get; set; }
    }
    public class GenericReturnObject : GenericReturnObjectBase
    {
        public GenericReturnObject() : base() { }
    }
    public class GenericReturnObjectBase
    {
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("success")]
        public bool Success { get; set; } = true;
    }
}
