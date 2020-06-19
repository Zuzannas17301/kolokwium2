using System;

namespace APBDKol2.Exceptions
{
    public class EventDoesNotExistException : Exception
    {
        public EventDoesNotExistException(string message) : base(message)
        {
        }

        public EventDoesNotExistException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public EventDoesNotExistException()
        {
        }
    }
}