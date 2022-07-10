using System.ComponentModel;

namespace Robot.Core.Exceptions
{
    public class InvalidCommandException: WarningException
    {
        public InvalidCommandException(string message) : base(message)
        {
        }
    }
}