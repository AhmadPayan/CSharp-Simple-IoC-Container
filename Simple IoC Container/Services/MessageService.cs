using Simple_IoC_Container.Communicator.Interfaces;
using Simple_IoC_Container.Services.Interfaces;

namespace Simple_IoC_Container.Services
{

    public class MessageService : IMessageService
    {
        ICommunicator _messageSender;
        ILogger _logger;
        int counter;
        public MessageService(ICommunicator sender, ILogger logger)
        {
            counter = 0;
            _messageSender = sender;
            _logger = logger;
        }

        public void SendMessage(string message)
        {
            _logger.Log("Service is sending message...");
            _messageSender.SendMessage(message);

            counter++;
        }

        public int GetSentCount()
        {
            return counter;
        }
    }
}
