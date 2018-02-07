namespace Simple_IoC_Container.Communicator.Interfaces
{
    public interface IMessageService
    {
        void SendMessage(string message);
        int GetSentCount();
    }
}