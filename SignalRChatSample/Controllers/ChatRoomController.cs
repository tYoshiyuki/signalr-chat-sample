using Microsoft.AspNetCore.Mvc;
using SignalRChatSample.Models;
using SignalRChatSample.Services;
using System.Threading.Tasks;

namespace SignalRChatSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatRoomController : ControllerBase
    {
        private readonly IChatRoomService _chatRoomService;

        public ChatRoomController(IChatRoomService chatRoomService)
        {
            _chatRoomService = chatRoomService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var chatRooms = await _chatRoomService.GetChatRoomsAsync();
            return Ok(chatRooms);
        }

        [HttpPost]
        public async void Post([FromBody]ChatRoom chatRoom)
        {
            await _chatRoomService.AddChatRoomAsync(chatRoom);
        }

    }
}