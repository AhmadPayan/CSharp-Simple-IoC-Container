# CSharp-Simple-IoC-Container
A very small IoC container in C#.NET which created for learning purpose.

This is a simple C# Console Application that shows how you can create your own custom IoC Container in an easiest way.

**WARNING: Please do not use this as your project IoC Container,  It lacks many features and functionality.**

Register your types like as follows:

    var container = SimpleIoC.CreateInstance();
    container
    .For<IMessageService>().Inject<MessageService>();

Or even simpler use Register method:

    .Register<ILogger, Logger>();
           
And then resolve and get your instance of the type like as follow:

    var resolvedService = container.Resolve<IMessageService>();
    resolvedService.SendMessage("This is a simple IoC Container!");
    
You can use Singleton in order to prevent instantiating classes more than once. To do so, add the **UseSingleton()** into your container:

    var container = SimpleIoC.CreateInstance();
    container.UseSingleton();

By doing this, All of the objects just creating once.
