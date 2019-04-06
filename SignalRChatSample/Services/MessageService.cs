using Microsoft.EntityFrameworkCore;
using SignalRChatSample.Data;
using SignalRChatSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChatSample.Services
{
    public interface IMessageService
    {
        Task<List<Message>> GetMessagesAsync();
        Task<List<Message>> GetMessagesForChatRoomAsync(Guid roomId);
        Task<bool> AddMessageToRoomAsync(Guid roomId, Message message);
    }

    public class MessageService : IMessageService
    {
        private readonly ApplicationDbContext _context;

        public MessageService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddMessageToRoomAsync(Guid roomId, Message message)
        {
            message.Id = Guid.NewGuid();
            message.RoomId = roomId;
            message.PostedAt = DateTimeOffset.Now;

            _context.Messages.Add(message);

            return await _context.SaveChangesAsync() != 0;
        }

        public async Task<List<Message>> GetMessagesAsync()
        {
            return await _context.Messages.ToListAsync();
        }

        public async Task<List<Message>> GetMessagesForChatRoomAsync(Guid roomId)
        {
            return await _context.Messages.Where(m => m.RoomId == roomId).ToListAsync();
        }
    }
}
