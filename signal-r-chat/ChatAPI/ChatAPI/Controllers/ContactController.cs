using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatAPI.ReturnObjects;
using Domain.DTOs;
using Domain.Models;
using Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ChatAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ContactService _contactService;
        private readonly UserService _userService;
        public ContactController(ContactService contactService, UserService userService)
        {
            _contactService = contactService;
            _userService = userService;
        }
        [HttpGet("getContacts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetContacts([FromQuery] Guid user_id)
        {
            var results = new GenericReturnObject<List<ContactInformationDTO>>();
            try
            {
                if (user_id == Guid.Empty)
                {
                    results.Message = "Invalid userid";
                    results.Success = false;
                    return BadRequest(results);
                }
                results.Values = await _contactService.GetUserContacts(user_id);
            }
            catch (Exception ex)
            {
                results.Success = false;
                results.Message = ex.Message;
            }
            return Ok(JsonConvert.SerializeObject(results));
        }
        [HttpPost("addContact")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AddContact([FromBody] Contact contact)
        {
            var results = new GenericReturnObject();
            try
            {
                if (contact.ContactId == Guid.Empty)
                {
                    results.Success = false;
                    results.Message = "Empty Contact ID";
                    return BadRequest(JsonConvert.SerializeObject(results));
                };
                if (contact.UserId == Guid.Empty)
                {
                    results.Success = false;
                    results.Message = "Empty UserId";
                    return BadRequest(JsonConvert.SerializeObject(results));
                };

                var userRequestingToAddContact = await _userService.GetUser(contact.UserId);
                if (userRequestingToAddContact == default)
                {
                    results.Success = false;
                    results.Message = "User doesn't exist";
                    return BadRequest(JsonConvert.SerializeObject(results));
                }

                var contactToAdd = await _userService.GetUser(contact.ContactId);
                if (contactToAdd == default)
                {
                    results.Success = false;
                    results.Message = "Contact doesn't exist";
                    return BadRequest(JsonConvert.SerializeObject(results));
                }
                var addContactResults = await _contactService.AddContact(contact);
                if (!addContactResults.Item1)
                {
                    results.Success = false;
                    results.Message = addContactResults.Item2; //Fix later with more legible code
                    return BadRequest(JsonConvert.SerializeObject(results));
                }
            }
            catch (Exception ex)
            {
                results.Success = false;
                results.Message = ex.Message;
            }
            results.Success = true;
            return Ok(JsonConvert.SerializeObject(results));
        }
    }
}
