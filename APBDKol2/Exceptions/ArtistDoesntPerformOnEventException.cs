using System;

namespace APBDKol2.Exceptions
{
    public class ArtistDoesntPerformOnEventException : Exception
    {
        public ArtistDoesntPerformOnEventException(string message) : base(message)
        {
        }

        public ArtistDoesntPerformOnEventException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ArtistDoesntPerformOnEventException()
        {
        }
    }
}