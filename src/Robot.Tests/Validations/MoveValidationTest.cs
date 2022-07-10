using Robot.Core.Exceptions;
using Robot.Core.Models;
using Robot.Core.Utils;
using Robot.Core.Validations;
using Xunit;

namespace Robot.Tests.Validations
{
    public class MoveValidationTest
    {
        private RobotState _robotState;
        private MoveValidation _moveValidation;
        public MoveValidationTest()
        {
            _robotState = new RobotState
            {
                SurfaceDimension = new SurfaceDimension()
                {
                    Width = 5,
                    Length = 5,
                    MaxTopMovement = 2,
                    MaxBottomMovement = -2,
                    MaxRightMovement = 2,
                    MaxLeftMovement = -2,

                }
            };
            _moveValidation = new MoveValidation();
        }

        [Theory]
        [InlineData(2, 2, DirectionEnum.North)]
        [InlineData(2, -2, DirectionEnum.South)]
        [InlineData(2, 2, DirectionEnum.East)]
        [InlineData(-2, 2, DirectionEnum.West)]
        public void Should_Not_Allow_When_Moving_BeyondMaxMovement(int xaxis, int yaxis, DirectionEnum direction)
        {
            //Arrange
            _robotState.Location = new Location()
            {
                Direction = direction,
                XAxis = xaxis,
                YAxis = yaxis
            };
            var commandLineArgs = new string[] { "move" };

            //Act
            void isValidAction() => _moveValidation.IsValid(commandLineArgs, _robotState);

            //Assert
            InvalidCommandException invalidCommandException = Assert.Throws<InvalidCommandException>(isValidAction);
            Assert.Equal(Constants.MESSAGE_CANNOT_MOVE, invalidCommandException.Message);
        }
    }
}
