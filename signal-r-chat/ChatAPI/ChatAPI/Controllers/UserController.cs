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
                    Icon = user.ProfilePicture,
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
    }
}
