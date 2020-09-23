using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public Guid From { get; set; }
        public Guid To { get; set; }
        public DateTimeOffset TimeSent { get; set; }
    }
}
