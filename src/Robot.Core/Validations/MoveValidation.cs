using Robot.Core.Exceptions;
using Robot.Core.Interfaces;
using Robot.Core.Models;
using Robot.Core.Utils;

namespace Robot.Core.Validations
{
    public class MoveValidation : IMoveValidation
    {
        public bool IsValid(string[] args, RobotState robotState)
        {
            bool valid = true;

            switch (robotState.Location.Direction)
            {
                case DirectionEnum.North:
                    valid = robotState.Location.YAxis + Constants.MOVE_VALUE <= robotState.SurfaceDimension.MaxTopMovement;
                    break;
                case DirectionEnum.South:
                    valid = robotState.Location.YAxis - Constants.MOVE_VALUE >= robotState.SurfaceDimension.MaxBottomMovement;
                    break;
                case DirectionEnum.East:
                    valid = robotState.Location.XAxis + Constants.MOVE_VALUE <= robotState.SurfaceDimension.MaxRightMovement;
                    break;
                case DirectionEnum.West:
                    valid = robotState.Location.XAxis - Constants.MOVE_VALUE >= robotState.SurfaceDimension.MaxLeftMovement;
                    break;
            }

            if (!valid)
                throw new InvalidCommandException(Constants.MESSAGE_CANNOT_MOVE);

            return valid;
        }
    }
}
