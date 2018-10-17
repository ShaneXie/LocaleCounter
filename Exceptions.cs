using System;

namespace ECounter
{
    public class CounterRangeException : Exception
    {
        public CounterRangeException()
        {
        }

        public CounterRangeException(string message)
            : base(message)
        {
        }

        public CounterRangeException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public class CounterCharNotSetException : Exception
    {
        public CounterCharNotSetException()
        {
        }

        public CounterCharNotSetException(string message)
            : base(message)
        {
        }

        public CounterCharNotSetException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}