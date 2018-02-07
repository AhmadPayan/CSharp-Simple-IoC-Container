using Simple_IoC_Container.Services.Interfaces;
using System;

namespace Simple_IoC_Container.Services
{
    public class Logger : ILogger
    {
        public void Log(string value)
        {
            Console.WriteLine(value);
        }

        public void Log(string format, object arg0)
        {
            Console.WriteLine(format, arg0);
        }
    }
}
