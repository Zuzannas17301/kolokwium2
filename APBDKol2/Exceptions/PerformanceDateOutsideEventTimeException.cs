using System;

namespace APBDKol2.Exceptions
{
    public class PerformanceDateOutsideEventTimeException : Exception
    {
        
        public PerformanceDateOutsideEventTimeException(string message) : base(message)
        {
        }

        public PerformanceDateOutsideEventTimeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public PerformanceDateOutsideEventTimeException()
        {
        }
        
    }
}