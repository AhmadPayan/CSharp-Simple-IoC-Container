using System;
using System.Collections.Generic;

namespace Simple_IoC_Container.IoCContainer.Interfaces
{
    public interface ISimpleIoC
    {
        T Resolve<T>() where T : class;
        IFromMapper UseSingleton();
        Dictionary<Type, Type> GetAllRegisteredTypes();
        bool IsRegistered<Type>();
    }
}