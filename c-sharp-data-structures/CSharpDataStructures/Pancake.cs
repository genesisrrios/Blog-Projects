using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpDataStructures
{
    public class Pancake
    {
        public enum SizeEnum
        {
            TooSmall,
            StillTooSmall,
            HugeAndPerfect
        }
        public string Name { get; set; }
        public string Syrup { get; set; }
        public SizeEnum Size { get; set; }
    }
}
