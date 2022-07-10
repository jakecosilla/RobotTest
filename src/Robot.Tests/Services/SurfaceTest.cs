using FluentAssertions;
using Robot.Core.Models;
using Robot.Core.Services;
using Xunit;

namespace Robot.Tests.Services
{
    public class SurfaceTest
    {
        private Surface _surface;
        public SurfaceTest()
        {
            _surface = new Surface();
        }

        [Fact]
        public void Should_Calculate_Surface()
        {
            //Arrage
            var surfaceDimension = new SurfaceDimension()
            {
                Width = 5,
                Length = 5,
                MaxTopMovement = 2,
                MaxBottomMovement = -2,
                MaxRightMovement = 2,
                MaxLeftMovement = -2,

            };

            //Act
            var actual = _surface.InitializeSurface(surfaceDimension.Width, surfaceDimension.Length);

            //
            actual.Should().BeEquivalentTo(surfaceDimension);
        }
    }
}
