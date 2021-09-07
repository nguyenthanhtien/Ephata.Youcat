using System;


namespace Ephata.YouCat.DomainLayer.Exceptions
{
    public class UserFriendlyException : Exception
    {
        public UserFriendlyException(string message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
