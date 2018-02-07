using Simple_IoC_Container.IoCContainer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Simple_IoC_Container.IoCContainer
{
    /// <summary>
    /// Simple IoC Container based on constructor injection.
    /// Just created for learning purpose.
    /// </summary>
    public class SimpleIoC : ISimpleIoC, IFromMapper, IToMapper
    {
        Dictionary<Type, Type> registeredTypes =
            new Dictionary<Type, Type>();

        Dictionary<Type, object> instances =
            new Dictionary<Type, object>();

        Type tmp;
        bool isSingletonMode;

        /// <summary>
        /// Create an instance of the IoC Container
        /// </summary>
        /// <returns></returns>
        public static SimpleIoC CreateInstance() => new SimpleIoC();

        public T Resolve<T>() where T : class
        {
            if (!registeredTypes.Any())
                throw new Exception("No entity has been registered yet.");

            T s = (T)ResolveParameter(typeof(T));

            if (isSingletonMode && !instances.ContainsKey(typeof(T)))
                instances.Add(typeof(T), s);

            return s;
        }

        private object ResolveParameter(Type type)
        {
            try
            {
                Type resolved = null;

                if (isSingletonMode && instances.ContainsKey(type))
                {
                    return instances.First(f => f.Key == type).Value;
                }
                else
                    resolved = registeredTypes[type];

                var cnstr = resolved.GetConstructors().First();
                var cnstrParams = cnstr.GetParameters().Where(w => w.GetType().IsClass);

                // If constructor hasn't parameter, Create an instance of object
                if (!cnstrParams.Any())
                    return Activator.CreateInstance(resolved);

                var paramLst = new List<object>(cnstrParams.Count());

                // Iterate through parameters and resolve each parameter
                for (int i = 0; i < cnstrParams.Count(); i++)
                {
                    var paramType = cnstrParams.ElementAt(i).ParameterType;
                    var resolvedParam = ResolveParameter(paramType);
                    paramLst.Add(resolvedParam);
                }

                return cnstr.Invoke(paramLst.ToArray());
            }
            catch (Exception)
            {
                var err = string.Format("'{0}' Cannot be resolved. Check your registered types", type.FullName);
                throw new Exception(err);
            }

        }

        /// <summary>
        /// When this type needed
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IToMapper For<Tfrom>()
        {
            tmp = typeof(Tfrom);
            return this;
        }

        /// <summary>
        /// This type should be injected into the parameter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IFromMapper Inject<TTo>()
        {
            // If Already added, Just update the injection type
            if (registeredTypes.ContainsKey(tmp))
                registeredTypes[tmp] = typeof(TTo);
            else
            {
                registeredTypes.Add(tmp, typeof(TTo));
                tmp = null;
            }

            return this;
        }

        /// <summary>
        /// Register types
        /// </summary>
        /// <typeparam name="Tfrom">From type</typeparam>
        /// <typeparam name="TTo">Call this implementation</typeparam>
        /// <returns>returns the IoC container</returns>
        public IFromMapper Register<Tfrom, TTo>() where TTo : Tfrom
        {
            return For<Tfrom>().Inject<TTo>();
        }
        /// <summary>
        /// Use singleton for instantiating?
        /// </summary>
        /// <returns></returns>
        public IFromMapper UseSingleton()
        {
            isSingletonMode = true;
            return this;
        }

        /// <summary>
        /// Get all of the registered types for this container
        /// </summary>
        /// <returns></returns>
        public Dictionary<Type, Type> GetAllRegisteredTypes()
        {
            return registeredTypes;
        }

        /// <summary>
        /// Returns true if specified type were registered
        /// </summary>
        /// <typeparam name="Type">The type that you want to check if is registered in the container</typeparam>
        /// <returns>True/False</returns>
        public bool IsRegistered<Type>()
        {
            return registeredTypes.Any(a => a.Key == typeof(Type));
        }

    }
}
