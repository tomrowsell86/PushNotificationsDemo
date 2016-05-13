using System.Collections.Generic;
using PushNotificationsHandler.Repositories.Interface;

namespace PushNotificationsHandler.Models.Services
{
    public class MessageModelService : IMessageModelService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageModelService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public IList<IMessageModel> GetMessages()
        {
            return _messageRepository.SelectAll();
        }
    }
}