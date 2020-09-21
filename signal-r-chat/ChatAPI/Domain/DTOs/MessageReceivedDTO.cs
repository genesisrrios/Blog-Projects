using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTOs
{
    public class MessageReceivedDTO
    {
        [JsonProperty("from")]
        public Guid From { get; set; }

        [JsonProperty("to")]
        public Guid To { get; set; }
    }
}
