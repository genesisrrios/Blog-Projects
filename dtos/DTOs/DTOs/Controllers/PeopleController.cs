using API.DTO;
using DOMAIN.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly PeopleInformationService peopleService;
        public PeopleController(PeopleInformationService service)
        {
            peopleService = service;
        }
        [Route("getperson")]
        public async Task<PersonDTO> GetPerson()
        {
            var person = await peopleService.GetPerson();

            return new PersonDTO
            {
                LastName = person.LastName,
                Name = person.Name
            };
        }
        [Route("getpeople")]
        public async Task<List<PersonDTO>> GetPeople()
        {
            var personList = await peopleService.GetPeopleList();
            var mappedPersonList = new List<PersonDTO>();
            
            foreach(var person in personList)
            {
                mappedPersonList.Add(new PersonDTO
                {
                    LastName = person.LastName,
                    Name = person.Name
                });
            }
            return mappedPersonList;
        }
    }
}
