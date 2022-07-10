using System.ComponentModel;

namespace Robot.Core.Exceptions
{
    public class InvalidParamatersException: WarningException
    {
        public InvalidParamatersException(string message) : base(message)
        {
        }
    }
}
