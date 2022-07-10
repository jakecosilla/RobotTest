using Robot.Core.Interfaces;
using Robot.Core.Models;
using Robot.Core.Utils;

namespace Robot.Core.Services
{
    public class Surface : ISurface
    {
        public SurfaceDimension InitializeSurface(int width, int length)
        {
            var surface = new SurfaceDimension
            {
                Width = width,
                Length = length,
                MaxTopMovement = length / Constants.DIMENSION_CENTER_DIVISOR,
                MaxRightMovement = width / Constants.DIMENSION_CENTER_DIVISOR,
                MaxBottomMovement = (length / Constants.DIMENSION_CENTER_DIVISOR) * Constants.NEGATIVE_AXIS,
                MaxLeftMovement = (width / Constants.DIMENSION_CENTER_DIVISOR) * Constants.NEGATIVE_AXIS
            };

            return surface;
        }
    }
}