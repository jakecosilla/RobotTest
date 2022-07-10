using Robot.Core.Models;

namespace Robot.Core.Interfaces
{
    public interface ICommand
    {
        /// <summary>
        /// Returns the RobotState.
        /// Required before running other commands.
        /// </summary>
        /// <param name="args">args[1] x-axis, args[2] y-axis, args[3] direction.
        /// X and Y are integers that indicate a location on the tabletop. 
        /// DIRECTION is a string indicating which direction the robot should face.
        /// It it one of the four cardinal directions: NORTH, EAST, SOUTH or WEST.
        /// </param>
        /// <param name="robotState">Robot state that will be updated</param>
        RobotState Place(string[] args, RobotState robotState);
        /// <summary>
        /// Returns the RobotState.
        /// Instructs the robot to move 1 square in the direction it is facing.
        /// </summary>
        /// <param name="robotState">Robot state that will be updated</param>
        RobotState Move(RobotState robotState);
        /// <summary>
        /// Returns the RobotState.
        /// Instructs the robot to rotate 90° anticlockwise/counterclockwise.
        /// </summary>
        /// <param name="robotState">Robot state that will be updated</param>
        RobotState Left(RobotState robotState);
        /// <summary>
        /// Returns the RobotState.
        /// Instructs the robot to rotate 90° clockwise.
        /// </summary>
        /// <param name="robotState">Robot state that will be updated</param>
        RobotState Right(RobotState robotState);
        /// <summary>
        /// Returns the RobotState.
        /// Outputs the robot's current location on the tabletop and the direction it is facing.
        /// </summary>
        /// <param name="robotState">Robot state that will be updated</param>
        void Report(RobotState robotState);
    }
}