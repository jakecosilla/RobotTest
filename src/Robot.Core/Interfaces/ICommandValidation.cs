using Robot.Core.Models;

namespace Robot.Core.Interfaces
{
    public interface ICommandValidation
    {
        /// <summary>
        /// Returns the boolean.
        /// Validates the command.
        /// </summary>
        bool IsValid(string[] args, RobotState robotState);
    }
}