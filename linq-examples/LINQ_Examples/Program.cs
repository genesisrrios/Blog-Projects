using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            //First query example
            var customerList = new List<string>
            {
                "Cliente 1",
                "Cliente 2",
                "Cliente 3"
            };
            var firstCustomer = customerList.Where(x => x == "Mofongo").SingleOrDefault();
        }
    }
}
