using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTOs
{
    public class UserDTO
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("user_name")]
        public string UserName { get; set; }
        [JsonProperty("primary_color_hex")]
        public string PrimaryColorHex { get; set; }
        [JsonProperty("profile_picture")]
        public string ProfilePicture { get; set; }
    }
}
