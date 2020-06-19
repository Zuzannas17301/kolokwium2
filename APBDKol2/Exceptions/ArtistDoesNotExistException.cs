using System;

namespace APBDKol2.Exceptions
{
    public class ArtistDoesNotExistException : Exception
    {
        public ArtistDoesNotExistException(string message) : base(message)
        {
        }

        public ArtistDoesNotExistException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ArtistDoesNotExistException()
        {
        }
    }
}
