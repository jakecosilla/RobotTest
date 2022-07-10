namespace Robot.Core.Models
{
    public class SurfaceDimension
    {
        public int Length { get; set; }
        public int Width { get; set; }
        public int MaxTopMovement { get; set; }
        public int MaxBottomMovement { get; set; }
        public int MaxLeftMovement { get; set; }
        public int MaxRightMovement { get; set; }
    }
}