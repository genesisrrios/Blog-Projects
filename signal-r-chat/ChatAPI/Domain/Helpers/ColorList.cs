using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Helpers
{
    public class ColorList
    {
        public Dictionary<string,string> Colors { get; set; } = new Dictionary<string,string>();

        public ColorList()
        {
            Colors.Add("Brown","#77dd77");
            Colors.Add("Baby Blue","#89cff0");
            Colors.Add("Purple","#b39eb5");
            Colors.Add("Red","#ff6961");
            Colors.Add("Pink","#ff9899");
            Colors.Add("Dim Gray","#3B3638");
        }
        public (string, string) ReturnRandomColor()
        {
            var random = new Random();
            var colorListCount = Colors.Count;
            var colorListIndex = random.Next(0, colorListCount);
            var colorName = Colors.ElementAt(colorListIndex).Key;
            var colorHex = Colors.ElementAt(colorListIndex).Value;
            return (colorName, colorHex);
        }
    }
}
