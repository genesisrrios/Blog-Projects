using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string PrimaryColorHex { get; set; }
        public string ProfilePicture { get; set; }
    }
}
