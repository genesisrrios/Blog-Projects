using System;
using System.Collections.Generic;
using System.Text;

namespace DOMAIN.Models
{
    public class Person
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public long SocialSecurityNumber { get; set; } //Obviamente esto nunca se guardaria asi pero lo hice por ejemplo
    }
}
