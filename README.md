# CSharp-Simple-IoC-Container
A very small IoC container in C#.NET. Just created for learning purpose.

This is a simple C# Console Application that shows how you can create your own custom IoC Container in the easiest way.

**WARNING: Please do not use this as your project IoC Container,  It lacks many features and functionalities.**


**Usage**

It's simple, Here are the steps:
1. Define your types and implementations.
2. Call Resolve method of the container to get desired implementation.
3. Use it!

So let's get started!

**1. Register your types like as follows:**

       var container = SimpleIoC.CreateInstance();
       container.For<IMessageService>().Inject<MessageService>();

Or even simpler use Register method:

    container.Register<ILogger, Logger>();
           
**2. Then resolve and get your instance of the type like this:**

       var resolvedService = container.Resolve<IMessageService>();

**3. It's done! Enjoy it.**

       resolvedService.SendMessage("This is a simple IoC Container!");
    
You can use Singleton in order to prevent instantiating classes more than once. To do so, add the **UseSingleton()** into your container:

    var container = SimpleIoC.CreateInstance();
    container.UseSingleton();

By doing this, All of the objects just creating once.

