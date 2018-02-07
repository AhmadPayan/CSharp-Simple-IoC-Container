
namespace Simple_IoC_Container.Services.Interfaces
{
    public interface ILogger
    {
        void Log(string format, object arg0);
        void Log(string value);
    }
}
