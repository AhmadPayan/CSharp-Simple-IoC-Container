using Simple_IoC_Container.Communicator.Interfaces;
using Simple_IoC_Container.Services.Interfaces;

namespace Simple_IoC_Container.Communicator
{
    /// <summary>
    /// Sms Communicator Class, Sending message via Sms
    /// </summary>
    public class SmsCommunicator : ICommunicator
    {
        ILogger _logger;
        public SmsCommunicator(ILogger logger)
        {
            _logger = logger;
        }

        public void SendMessage(string body)
        {
            _logger.Log("Sms sent successfully!\n{0}\n\n", body);
        }
    }
}
