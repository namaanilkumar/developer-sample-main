using System;

namespace DeveloperSample.Container
{
    public class Container
    {
        // public void Bind(Type interfaceType, Type implementationType) => throw new NotImplementedException();
        //public T Get<T>() => throw new NotImplementedException();

       
        private Dictionary<Type, Type> bindings = new Dictionary<Type, Type>();
        private readonly Dictionary<Type, object> instances = new Dictionary<Type, object>();


        public void Bind(Type interfaceType, Type implementationType)
        {
            if (interfaceType == null)
            {
                throw new ArgumentNullException(nameof(interfaceType));
            }
            if (implementationType == null)
            {
                throw new ArgumentNullException(nameof(implementationType));
            }
            if (!interfaceType.IsInterface)
            {
                throw new ArgumentException($"{interfaceType} is not an interface.");
            }
            if (!interfaceType.IsAssignableFrom(implementationType))
            {
                throw new ArgumentException($"{implementationType} does not implement {interfaceType}.");
            }
            bindings[interfaceType] = implementationType;
        }
        public T Get<T>()
        {
            // Use the non-generic Get method, casting the result to the desired type
            return (T)Get(typeof(T));
        }

        // Non-generic Get method resolves and returns an instance of a specified type
        public object Get(Type type)
        {
            // Check if there's a mapping for the requested type
            if (!bindings.TryGetValue(type, out Type implementationType))
            {
                throw new InvalidOperationException($"No mapping found for {type}.");
            }

            // Check if an instance of the implementation type already exists
            if (!instances.TryGetValue(implementationType, out object instance))
            {
                // If not, create a new instance using reflection
                instance = Activator.CreateInstance(implementationType);

                // Cache the instance for future use
                instances[implementationType] = instance;
            }

            // Return the resolved instance
            return instance;
        }

    }
}