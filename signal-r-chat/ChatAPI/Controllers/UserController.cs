using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatAPI.ReturnObjects;
using Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.DTOs;
using Newtonsoft.Json;
using Domain.Models;
using Domain.Helpers;

namespace ChatAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getuser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetUser([FromQuery] Guid user_id)
        {
            var results = new GenericReturnObject<UserDTO>();
            try
            {
                if (user_id == Guid.Empty)
                {
                    results.Message = "Invalid userid";
                    results.Success = false;
                    return BadRequest(results);
                }
                var user = await _userService.GetUser(user_id);
                if (user == default)
                {
                    results.Message = "User doesn't exist";
                    results.Success = false;
                    return BadRequest(results);
                }
                //Normally we'd use automapper but let's keep it simple
                results.Values = new UserDTO
                {
                    Id = user.Id,
                    ProfilePicture = user.ProfilePicture,
                    PrimaryColorHex = user.PrimaryColorHex,
                    UserName = user.UserName
                };
            }
            catch (Exception ex)
            {
                results.Success = false;
                results.Message = ex.Message;
            }
            return Ok(JsonConvert.SerializeObject(results));
        }
        [HttpGet("getnewuser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetNewUser()
        {
            var results = new GenericReturnObject<UserDTO>();
            try
            {
                var userColor = ColorList.ReturnRandomColor();
                var userAnimal = AnimalList.ReturnAnimal();
                var profilePicture = Images.ReturnRandomImage();

                var userName = $"{ userColor.Item1} { userAnimal }";
                var newUser = new User
                {
                    Id = Guid.NewGuid(),
                    UserName = userName,
                    PrimaryColorHex = userColor.Item2,
                    ProfilePicture = profilePicture
                };
                var dbUser = _userService.GetUser(newUser.UserName);
                while (dbUser != default)
                {
                    var retryNewUser = new User
                    {
                        Id = Guid.NewGuid(),
                        UserName = userName,
                        PrimaryColorHex = userColor.Item2,
                    };
                    dbUser = _userService.GetUser(retryNewUser.UserName);
                }
                results.Success = await _userService.CreateUser(newUser);
                results.Values = new UserDTO
                {
                    UserName = newUser.UserName,
                    Id = newUser.Id,
                    PrimaryColorHex = userColor.Item2,
                    ProfilePicture = profilePicture
                };
            }
            catch (Exception ex)
            {
                results.Success = false;
                results.Message = ex.Message;
            }
            return Ok(JsonConvert.SerializeObject(results));
        }
        [HttpGet("searchContactByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> SearchContactByName([FromQuery] Guid user_id, [FromQuery] string contact_name)
        {
            var results = new GenericReturnObject<List<UserDTO>>();
            try
            {
                if (user_id == Guid.Empty || String.IsNullOrEmpty(contact_name))
                {
                    results.Success = false;
                    return BadRequest(results);
                }
                var userMakingRequest = await _userService.GetUser(user_id);
                if (userMakingRequest == default)
                {
                    results.Success = false;
                    return BadRequest(results);
                }
                var userList = await _userService.GetUserByName(contact_name, user_id);
                //TODO FIX MAPPING HERE
                results.Values = userList.Select(x => new UserDTO
                {
                    UserName = x.UserName,
                    Id = x.Id
                }).ToList();
            }
            catch (Exception ex)
            {
                results.Success = false;
                results.Message = ex.Message;
            }
            return Ok(JsonConvert.SerializeObject(results));
        }
    }
}
