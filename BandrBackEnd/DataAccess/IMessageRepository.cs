using BandrBackEnd.Models;

namespace BandrBackEnd.DataAccess
{
    public interface IMessageRepository
    {
        public List<Message> GetMessagesByPartId(int participantId);
        public Message GetMessageById(int id);
        public void createMessage(Message message);
        public void updateMessage(Message message);
        public void deleteMessage(int id);
    }
}
