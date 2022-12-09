using System;

namespace Chess.Exceptions
{
    public class ChessCoordinateNotValidException : Exception
    {
        public ChessCoordinateNotValidException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}