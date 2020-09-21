using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Contact
    {
        public Guid UserId { get; set; }
        public Guid ContactId { get; set; }
    }
}
