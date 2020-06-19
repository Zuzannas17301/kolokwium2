using System;

namespace APBDKol2.Exceptions
{
    public class EventAlreadyStartedException : Exception
    {
        public EventAlreadyStartedException(string message) : base(message)
        {
        }

        public EventAlreadyStartedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public EventAlreadyStartedException()
        {
        }
    }
}