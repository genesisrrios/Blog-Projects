using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ContactId { get; set; }
    }
}
