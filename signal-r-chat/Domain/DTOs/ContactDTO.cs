using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTOs
{
    public class ContactDTO
    {
        [JsonProperty("user_id")]
        public Guid UserId { get; set; }
        [JsonProperty("contact_id")]
        public Guid ContactId { get; set; }
    }
}
