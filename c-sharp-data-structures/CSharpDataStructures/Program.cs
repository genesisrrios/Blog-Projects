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
            //////////////////////////////QUEUE///////////////////////////////////
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
                //Console.WriteLine($"Name: {artist.Name}, Genre: {artist.GenreId}");
            }
            //Console.ReadKey();

            ///////////////////////////////ARRAY/////////////////////////////////

            var artistArray = new Artist[4];

            artistArray[0] = new Artist
            {
                Name = "Hayley kioko",
                GenreId = "Pop",
                RecordId = 4
            };

            artistArray[1] = new Artist
            {
                Name = "Glass animals",
                GenreId = "Vaporwave idk",
                RecordId = 5
            };
            //Error line
            //artistArray[5] = new Artist
            //{
            //    Name = "Error",
            //    GenreId = "This shouldn't work",
            //    RecordId = 5
            //};
            foreach (var artist in artistArray)
            {
                if (artist == default) continue;
                //Console.WriteLine(artist?.Name);
            }

            var hayleyKioko = artistArray[0];
            //Console.WriteLine(hayleyKioko.Name);

            //Console.ReadKey();

            /////////////////////LIST///////////////
            var artistList = new List<Artist>();
            artistList.AddRange(artistArray);
            //artistList.ForEach(x => Console.WriteLine(x?.Name));
            //Console.ReadKey();
            var halestorm = new Artist
            {
                Name = "Halestorm",
                GenreId = "Rock",
                RecordId = 6
            };
            artistList.Add(halestorm);
            Console.WriteLine($"Artist list count: {artistList.Count}");
            Console.WriteLine($"Does the list contain halestorm? : {artistList.Contains(halestorm)}");
            Console.WriteLine($"Find by RecordId : {artistList.Find(x=> x?.RecordId == 6).Name}");
            Console.ReadLine();


            var stack = new Stack<Pancake>();
            stack.Push(new Pancake
            {
                Name ="Chocolate chips",
                Size = Pancake.SizeEnum.TooSmall,
                Syrup = "Maple Syrup"
            });
            stack.Pop();
            stack.Peek();
            
        }
    }
}