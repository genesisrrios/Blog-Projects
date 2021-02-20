using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreVueJs.Models
{
    public record User
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
    public record IndexViewModel
    {
        public User User { get; set; }

        public List<User> FriendList { get; set; }
    }
}
