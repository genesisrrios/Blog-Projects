using DOMAIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.Services
{
    public class PeopleInformationService
    {
        private List<Person> peopleList = new List<Person>();
        public PeopleInformationService() => peopleList.Add(new Person
        {
            Id = Guid.NewGuid(),
            LastName = "Rivera",
            Name = "Genesis",
            SocialSecurityNumber = 444-444-444
        });

        public async Task<List<Person>> GetPeopleList()
        {
            return peopleList;
        }
        public async Task<Person> GetPerson()
        {
            return peopleList.First();
        }
    }
}
