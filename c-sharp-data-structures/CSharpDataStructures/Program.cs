using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CSharpDataStructures
{
    class Program
    {
        static void Main(string[] args)
        {

            //FIFO !
            var queue = new Queue();
            queue.Enqueue(new Artist { GenreId ="Pop", Name= "GONOSOS", RecordId = 12343 });
            queue.Enqueue(new Artist { GenreId = "Rock", Name = "GONOSOS", RecordId = 45433 });
            queue.Enqueue(new Artist { GenreId = "Indie", Name = "GONOSOS", RecordId = 34565 });

            var artistType = typeof(Artist);
            PropertyInfo[] props = artistType.GetProperties();
            var artisInfoList = new List<string>();
            foreach (var artist in queue)
            {
                var artistInfo = new StringBuilder();
                foreach (var property in props)
                {
                    artistInfo.Append(property.Name + " " + property.GetValue(artist) + ", ");
                }
                artistInfo.Length --; artistInfo.Length--;
                artisInfoList.Add(artistInfo.ToString());
                artistInfo.Clear();
            }
            foreach (var artist in artisInfoList)
            {
                Console.WriteLine(artist);
            }
            Console.Read();
        }
    }
}