using Microsoft.EntityFrameworkCore;
using SignalRChatSample.Data;
using SignalRChatSample.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalRChatSample.Services
{
    public interface IChatRoomService
    {
        Task<List<ChatRoom>> GetChatRoomsAsync();
        Task<bool> AddChatRoomAsync(ChatRoom chatRoom);
    }

    public class ChatRoomService : IChatRoomService
    {
        private readonly ApplicationDbContext _context;

        public ChatRoomService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddChatRoomAsync(ChatRoom chatRoom)
        {
            chatRoom.Id = Guid.NewGuid();
            _context.ChatRooms.Add(chatRoom);
            return await _context.SaveChangesAsync() != 0;
        }

        public async Task<List<ChatRoom>> GetChatRoomsAsync()
        {
            return await _context.ChatRooms.ToListAsync();
        }
    }
}
