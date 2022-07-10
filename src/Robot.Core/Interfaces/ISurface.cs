using Robot.Core.Models;

namespace Robot.Core.Interfaces
{
    /// <summary>
    /// Returns the SurfaceDimension.
    /// Sets initial values of the surface.
    /// </summary>
    public interface ISurface
    {
        SurfaceDimension InitializeSurface(int width, int length);
    }
}