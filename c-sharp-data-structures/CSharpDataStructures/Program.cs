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
            var queue = new Queue<Artist>();
            queue.Enqueue(new Artist
            {
                GenreId = "Neue Deutsche Härte",
                Name = "Rammstein",
                RecordId = 1
            });
            queue.Enqueue(new Artist
            {
                GenreId = "Neue Deutsche Härte",
                Name = "OOMPH!",
                RecordId = 2
            });
            queue.Enqueue(new Artist
            {
                GenreId = "Neue Deutsche Härte",
                Name = "Eisbrecher",
                RecordId = 3
            });
            queue.Peek();
            queue.Dequeue();
            foreach (var artist in queue)
            {
                Console.WriteLine($"Name: {artist.Name}, Genre: {artist.GenreId}");
            }
            Console.Read();
        }
    }
}