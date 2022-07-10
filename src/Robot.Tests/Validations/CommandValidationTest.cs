using Moq;
using Robot.Core.Exceptions;
using Robot.Core.Interfaces;
using Robot.Core.Models;
using Robot.Core.Utils;
using Robot.Core.Validations;
using Xunit;

namespace Robot.Tests.Validations
{
    public class CommandValidationTest
    {
        private RobotState _robotState;
        private CommandValidation _commandValidation;
        private Mock<IPlaceValidation> _mockPlaceValidation;
        private Mock<IMoveValidation> _mockMoveValidation;

        public CommandValidationTest()
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
            
            _mockPlaceValidation = new Mock<IPlaceValidation>();
            _mockPlaceValidation.Setup(_ => _.IsValid(It.IsAny<string[]>(), It.IsAny<RobotState>())).Returns(true);
            _mockMoveValidation = new Mock<IMoveValidation>();
            _mockMoveValidation.Setup(_ => _.IsValid(It.IsAny<string[]>(), It.IsAny<RobotState>())).Returns(true);
            _commandValidation = new CommandValidation(_mockPlaceValidation.Object, _mockMoveValidation.Object);
        }

        [Fact]
        public void Should_Not_Allow_No_Command()
        {
            //Arrange
            var commandLineArgs = new string[] {};

            //Act
            void isValidAction() => _commandValidation.IsValid(commandLineArgs, _robotState);

            //Assert
            InvalidCommandException invalidCommandException = Assert.Throws<InvalidCommandException>(isValidAction);
            Assert.Equal(Constants.MESSAGE_NO_COMMAND_EXECUTED, invalidCommandException.Message);
        }

        [Theory]
        [InlineData("fake")]
        [InlineData("wrong command")]
        public void Should_Not_Allow_Invalid_Command(string command)
        {
            //Arrange
            var commandLineArgs = new string[] { command };

            //Act
            void isValidAction() => _commandValidation.IsValid(commandLineArgs, _robotState);

            //Assert
            InvalidCommandException invalidCommandException = Assert.Throws<InvalidCommandException>(isValidAction);
            Assert.Equal($"'{command}' {Constants.MESSAGE_NOT_VALID_COMMAND}", invalidCommandException.Message);
        }

        [Theory]
        [InlineData("move")]
        [InlineData("left")]
        [InlineData("right")]
        [InlineData("report")]
        public void Should_Not_Allow_Other_Commands_When_Not_Yet_Placed(string command)
        {
            //Arrange
            var commandLineArgs = new string[] { command };

            //Act
            void isValidAction() => _commandValidation.IsValid(commandLineArgs, _robotState);

            //Assert
            PlaceRequiredException placeRequiredException = Assert.Throws<PlaceRequiredException>(isValidAction);
            Assert.Equal($" {command}. {Constants.MESSAGE_PLACE_COMMAND_REQUIRED}", placeRequiredException.Message);
        }
    }
}