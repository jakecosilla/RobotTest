using Robot.Core.Exceptions;
using Robot.Core.Interfaces;
using Robot.Core.Models;
using Robot.Core.Utils;

namespace Robot.Core.Validations
{
    public class PlaceValidation : IPlaceValidation
    {
        public bool IsValid(string[] args, RobotState robotState)
        {
            bool valid = true;
            var directionList = new List<string>()
            {
                Constants.NORTH_DIRECTION,
                Constants.SOUTH_DIRECTION,
                Constants.EAST_DIRECTION,
                Constants.WEST_DIRECTION
            };

            if (args.Length < 4)
                throw new InvalidParamatersException(Constants.MESSAGE_PLACE_INCOMPLETE_ARGUMENTS);
            if (String.IsNullOrEmpty(args[1]) || String.IsNullOrEmpty(args[2]) || String.IsNullOrEmpty(args[3]))
                throw new InvalidParamatersException(Constants.MESSAGE_PLACE_REQUIRED_PARAMS);

            var xaxis = Convert.ToInt32(args[1]);
            var yaxis = Convert.ToInt32(args[2]);
            var direction = args[3];

            if (xaxis > robotState.SurfaceDimension.MaxRightMovement || xaxis < robotState.SurfaceDimension.MaxLeftMovement)
                throw new InvalidParamatersException(Constants.MESSAGE_PLACE_INVALID_XAXIS);
            if (yaxis > robotState.SurfaceDimension.MaxTopMovement || yaxis < robotState.SurfaceDimension.MaxBottomMovement)
                throw new InvalidParamatersException(Constants.MESSAGE_PLACE_INVALID_YAXIS);
            if (!directionList.Contains(direction))
                throw new InvalidParamatersException(Constants.MESSAGE_INVALID_DIRECTION);

            return valid;
        }
    }
}