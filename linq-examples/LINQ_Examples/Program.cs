using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace LINQ_Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 1, 0, 2, 3, 0, 4, 5, 0 };

            for(var i = 0; i < arr.Length; i++)
            {
                if(arr[i] == 0)
                {
                    for(var i2 = i; i2 < arr.Length - 1; i2++)
                    {
                        Console.WriteLine(arr[i2]);
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
