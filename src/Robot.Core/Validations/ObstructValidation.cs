using Robot.Core.Exceptions;
using Robot.Core.Interfaces;
using Robot.Core.Models;
using Robot.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot.Core.Validations
{
    public class ObstructValidation : IObstructValidation
    {
        public bool IsValid(string[] args, RobotState robotState)
        {
            var isValid = true;
            if (args.Length < 4)
                throw new InvalidParamatersException(Constants.MESSAGE_OBSTRUCT_INCOMPLETE_ARGUMENTS);
            if (String.IsNullOrEmpty(args[1]) || String.IsNullOrEmpty(args[2]))
                throw new InvalidParamatersException(Constants.MESSAGE_OBSTRUCT_REQUIRED_PARAMS);

            return isValid;
        }
    }
}
