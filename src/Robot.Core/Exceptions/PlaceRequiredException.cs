using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot.Core.Exceptions
{
    public class PlaceRequiredException: WarningException
    {
        public PlaceRequiredException(string message) : base(message)
        {
        }
    }
}
