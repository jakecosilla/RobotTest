using Robot.Core.Models;

namespace Robot.Core.Interfaces
{
    public interface ICommandRunner
    {
        /// <summary>
        /// Returns the RobotState.
        /// Maps and execute the command.
        /// </summary>
        /// <param name="commandLineArgs">Array of strings from the command</param>
        /// <param name="robotState">Robot state that will be updated</param>
        RobotState Execute(string[] commandLineArgs, RobotState robotState);
    }
}