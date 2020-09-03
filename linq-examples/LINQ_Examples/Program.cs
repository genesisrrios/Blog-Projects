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
            //First query example
            var customerList = new List<string>
            {
                "Cliente 1",
                "Cliente 2",
                "Cliente 3"
            };
            var firstCustomer = customerList.Where(x => x == "Mofongo").SingleOrDefault();

            var peopleList = new List<Person>
            {
                new Person
                {
                    Id = Guid.NewGuid(),
                    Name = "Genesis",
                    Age = 24
                },
                new Person
                {
                    Id = Guid.NewGuid(),
                    Name = "Luis",
                    Age = 22
                },
                new Person
                {
                    Id = Guid.NewGuid(),
                    Name = "Edibeth",
                    Age = 22
                }
            };

            //Method syntax example 
            var ageOfLuis = peopleList.Where(x => x.Name == "Luis").Select(x => x.Name).SingleOrDefault();

            //Query syntax example
            var ageOfGenesis = (from person in peopleList
                               where person.Age == 24
                               select person.Name
                               ).SingleOrDefault();

            //Reflection
            var genesis = (from person in peopleList
                          select new Person
                          {
                              Age = person.Age,
                              Name = person.Name,
                          }).FirstOrDefault();
            //Reflection
            var luis = peopleList.Select(x =>
                new Person
                {
                    Age = x.Age,
                    Name = x.Name
                }).LastOrDefault();

            //Ordering 
            var filteredPeopleList = peopleList.Where(x => x.Age > 23 && x.Name != "Luis").ToList();

            //Grouping

            var groupedPeopleList = (from person in peopleList
                                    group person
                                    by person.Age
                                    into grouped
                                    select new Person
                                    {
                                        Age = grouped.Key,
                                        Name = String.Join(",", grouped.Select(x => x.Name))
                                    }).ToList();

            //Ordering 
            var orderedPeopleByAgeAsclist = peopleList.OrderBy(x => x.Age).ToList();

            var orderedPeopleByNameDesclist = peopleList.OrderByDescending(x => x.Name).ToList();
        }
    }
}
