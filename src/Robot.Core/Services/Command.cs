using Robot.Core.Interfaces;
using Robot.Core.Models;
using Robot.Core.Utils;

namespace Robot.Core.Services
{
    public class Command : ICommand
    {
        public RobotState Place(string[] args, RobotState robotState)
        {
            robotState.Location = new Location
            {
                XAxis = Convert.ToInt32(args[1]),
                YAxis = Convert.ToInt32(args[2]),
                Direction = Enum.Parse<DirectionEnum>(args[3], true)
            };
            robotState.IsPlaced = true;
            return robotState;
        }
        public RobotState Move(RobotState robotState)
        {
            switch (robotState.Location.Direction)
            {
                case DirectionEnum.North:
                    robotState.Location.YAxis += Constants.MOVE_VALUE;
                    break;
                case DirectionEnum.South:
                    robotState.Location.YAxis -= Constants.MOVE_VALUE;
                    break;
                case DirectionEnum.East:
                    robotState.Location.XAxis += Constants.MOVE_VALUE;
                    break;
                case DirectionEnum.West:
                    robotState.Location.XAxis -= Constants.MOVE_VALUE;
                    break;
            }

            return robotState;
        }
        public RobotState Left(RobotState robotState)
        {
            var currentDirectionIndex = ((int)robotState.Location.Direction);
            var directionIndex = currentDirectionIndex - Constants.DIRECTION_ROTATE;
            robotState.Location.Direction = directionIndex != 0 ? (DirectionEnum)directionIndex
                : (DirectionEnum)(directionIndex + Constants.DIRECTION_QUARTER_VALUE);
            return robotState;
        }
        public RobotState Right(RobotState robotState)
        {
            var currentDirectionIndex = ((int)robotState.Location.Direction);
            var directionIndex = currentDirectionIndex + Constants.DIRECTION_ROTATE;
            robotState.Location.Direction = directionIndex <= Constants.DIRECTION_QUARTER_VALUE ? (DirectionEnum)directionIndex
                : (DirectionEnum)(directionIndex % Constants.DIRECTION_QUARTER_VALUE);
            return robotState;
        }
        public void Report(RobotState robotState)
        {
            Console.WriteLine($"{Constants.REPORT_XAXIS_LABEL}: {robotState.Location.XAxis}\n" +
            $"{Constants.REPORT_YAXIS_LABEL}: {robotState.Location.YAxis}\n" +
            $"{Constants.REPORT_DIRECTION_LABEL}: {robotState.Location.Direction}");
        }
    }
}