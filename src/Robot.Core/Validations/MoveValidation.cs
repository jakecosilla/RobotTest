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
            bool canMove = true;
            bool hasObstruction = false;
            
            switch (robotState.Location.Direction)
            {
                case DirectionEnum.North:
                    canMove = robotState.Location.YAxis + Constants.MOVE_VALUE <= robotState.SurfaceDimension.MaxTopMovement;
                    hasObstruction = robotState.SurfaceDimension.Obstructions.Any(x => x.YAxis == (robotState.Location.YAxis + Constants.MOVE_VALUE));
                    break;
                case DirectionEnum.South:
                    canMove = robotState.Location.YAxis - Constants.MOVE_VALUE >= robotState.SurfaceDimension.MaxBottomMovement;
                     hasObstruction = robotState.SurfaceDimension.Obstructions.Any(x => x.YAxis == (robotState.Location.YAxis - Constants.MOVE_VALUE));
                    break;
                case DirectionEnum.East:
                    canMove = robotState.Location.XAxis + Constants.MOVE_VALUE <= robotState.SurfaceDimension.MaxRightMovement;
                    hasObstruction = robotState.SurfaceDimension.Obstructions.Any(x => x.XAxis == (robotState.Location.XAxis + Constants.MOVE_VALUE));
                    break;
                case DirectionEnum.West:
                    canMove = robotState.Location.XAxis - Constants.MOVE_VALUE >= robotState.SurfaceDimension.MaxLeftMovement;
                    hasObstruction = robotState.SurfaceDimension.Obstructions.Any(x => x.XAxis == (robotState.Location.XAxis - Constants.MOVE_VALUE));
                    break;
            }

            if (!canMove)
                throw new InvalidCommandException(Constants.MESSAGE_CANNOT_MOVE);
            if (hasObstruction)
                throw new InvalidCommandException(Constants.MESSAGE_CANNOT_MOVE_OBSTRUCT);

            return canMove && !hasObstruction;
        }
    }
}
