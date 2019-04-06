using Microsoft.AspNetCore.Mvc;
using SignalRChatSample.Models;
using SignalRChatSample.Services;
using System;
using System.Threading.Tasks;

namespace SignalRChatSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var messagesForRoom = await _messageService.GetMessagesAsync();

            return Ok(messagesForRoom);
        }

        [HttpGet("{roomId}")]
        public async Task<IActionResult> Get(Guid roomId)
        {
            if (roomId == Guid.Empty)
            {
                return NotFound();
            }

            var messagesForRoom = await _messageService.GetMessagesForChatRoomAsync(roomId);

            return Ok(messagesForRoom);
        }

        [HttpPost]
        public async void Post([FromBody] Message message)
        {
            await _messageService.AddMessageToRoomAsync(message.RoomId, message);
        }

    }
}