using Robot.Core.Exceptions;
using Robot.Core.Interfaces;
using Robot.Core.Models;
using Robot.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot.Core.Services
{
    public class CommandRunner : ICommandRunner
    {
        private readonly ICommand _command;
        private readonly ICommandValidation _commandValidation;
        public CommandRunner(ICommand command, ICommandValidation commandValidation)
        {
            _command = command;
            _commandValidation = commandValidation;
        }

        public RobotState Execute(string[] commandLineArgs, RobotState robotState)
        {
            // Validate first before running commands
            _commandValidation.IsValid(commandLineArgs, robotState);

            var command = commandLineArgs[0];

            switch (command.ToLower())
            {
                case Constants.PLACE_COMMAND:
                    robotState = _command.Place(commandLineArgs, robotState);
                    break;
                case Constants.MOVE_COMMAND:
                    robotState = _command.Move(robotState);
                    break;
                case Constants.LEFT_COMMAND:
                    robotState = _command.Left(robotState);
                    break;
                case Constants.RIGHT_COMMAND:
                    robotState = _command.Right(robotState);
                    break;
                case Constants.REPORT_COMMAND:
                    _command.Report(robotState);
                    break;
            }
            return robotState;
        }
    }
}
