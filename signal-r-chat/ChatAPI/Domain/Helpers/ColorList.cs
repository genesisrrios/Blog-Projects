using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Helpers
{
    public class ColorList
    {
        private static Dictionary<string, string> Colors { get; set; } = new Dictionary<string, string>
        {
            {"Brown","#77dd77"},
            {"Baby Blue","#89cff0"},
            {"Purple","#b39eb5"},
            {"Red","#ff6961"},
            {"Pink","#ff9899"},
            {"Dim Gray","#3B3638"}
        };
        public static (string, string) ReturnRandomColor()
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
