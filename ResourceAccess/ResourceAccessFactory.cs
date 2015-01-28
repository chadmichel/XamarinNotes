using System;

namespace ResourceAccess
{
    public class ResourceAccessFactory
    {
        public ResourceAccessFactory()
        {
        }

        public T Create<T>() where T : class
        {
            if (typeof(T).Name == typeof(INoteAccessor).Name)
            {
                return new NoteAccessor() as T;
            }

            throw new InvalidOperationException("No accessor configured for " + typeof(T).Name + ".");
        }
    }
}

