using Robot.Core.Exceptions;
using Robot.Core.Interfaces;
using Robot.Core.Models;
using Robot.Core.Utils;

namespace Robot.Core.Validations
{
    public class CommandValidation : ICommandValidation
    {
        private readonly IPlaceValidation _placeValidation;
        private readonly IMoveValidation _moveValidation;
        public CommandValidation(IPlaceValidation placeValidation, IMoveValidation moveValidation)
        {
            _placeValidation = placeValidation;
            _moveValidation = moveValidation;
        }
        public bool IsValid(string[] args, RobotState robotState)
        {
            bool valid = true;
            var commandList = new List<string>() 
            {
                Constants.PLACE_COMMAND,
                Constants.MOVE_COMMAND,
                Constants.LEFT_COMMAND,
                Constants.RIGHT_COMMAND,
                Constants.REPORT_COMMAND
            };

            if (args.Length == 0)
                throw new InvalidCommandException(Constants.MESSAGE_NO_COMMAND_EXECUTED);

            var command = args[0];

            if (!commandList.Contains(command.ToLower()))
                throw new InvalidCommandException($"'{command}' {Constants.MESSAGE_NOT_VALID_COMMAND}");
            if (command != Constants.PLACE_COMMAND && !robotState.IsPlaced)
                throw new PlaceRequiredException($" {command}. {Constants.MESSAGE_PLACE_COMMAND_REQUIRED}");
            if(command == Constants.PLACE_COMMAND)
                valid = _placeValidation.IsValid(args, robotState);
            if (command == Constants.MOVE_COMMAND)
                valid = _moveValidation.IsValid(args, robotState);
            
            return valid;
        }
    }
}
