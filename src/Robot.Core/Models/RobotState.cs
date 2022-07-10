namespace Robot.Core.Models
{
    public class RobotState
    {
        public Location Location { get; set; } = null!;
        public SurfaceDimension SurfaceDimension { get; set; } = null!;
        public bool IsPlaced { get; set; }
    }
}