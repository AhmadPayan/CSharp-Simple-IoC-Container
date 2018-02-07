using Simple_IoC_Container.Communicator.Interfaces;
using Simple_IoC_Container.Services.Interfaces;

namespace Simple_IoC_Container.Communicator
{
    /// <summary>
    /// Email Communicator Class, Sending message via Email
    /// </summary>
    public class EmailCommunicator : ICommunicator
    {
        ILogger _logger;
        public EmailCommunicator(ILogger logger)
        {
            _logger = logger;
        }

        public void SendMessage(string body)
        {
            _logger.Log("Email sent successfully!\n{0}\n\n", body);
        }
    }
}
