using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatAPI.Hubs;
using ChatAPI.ReturnObjects;
using Domain.DTOs;
using Domain.Models;
using Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ChatAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly MessageService _messageService;
        private readonly IHubContext<MessageHub> _messageClient;

        public MessageController(MessageService messageService, IHubContext<MessageHub> messageHub)
        {
            _messageService = messageService;
            _messageClient = messageHub;
        }
        [HttpPost("writemessage")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> WriteMessage([FromBody] Message message)
        {
            var results = new GenericReturnObject();
            try
            {
                if (String.IsNullOrEmpty(message.Content))
                {
                    results.Message = "Message has no content";
                    results.Success = false;
                    return BadRequest();
                }
                else
                {
                    message.TimeSent = DateTimeOffset.Now;
                    results.Success = await _messageService.SendMessage(message);
                    if (results.Success)
                        await _messageClient.Clients.All.SendAsync("ReceiveMessage", new MessageReceivedDTO
                        {
                            From = message.From,
                            To = message.To
                        });
                }
            }
            catch (Exception ex)
            {
                results.Success = false;
                results.Message = ex.Message;
            }
            return Ok(results);
        }
    }
}
