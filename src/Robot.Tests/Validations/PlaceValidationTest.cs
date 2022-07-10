using Robot.Core.Exceptions;
using Robot.Core.Models;
using Robot.Core.Utils;
using Robot.Core.Validations;
using Xunit;

namespace Robot.Tests.Validations
{
    public class PlaceValidationTest
    {
        private RobotState _robotState;
        private PlaceValidation _placeValidation;
        public PlaceValidationTest()
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
            _placeValidation = new PlaceValidation();
        }

        [Fact]
        public void Should_Not_Allow_Incomplete_Arguments()
        {
            //Arrange
            var commandLineArgs = new string[] { "place" };

            //Act
            void isValidAction() => _placeValidation.IsValid(commandLineArgs, _robotState);

            //Assert
            InvalidParamatersException invalidParamatersException = Assert.Throws<InvalidParamatersException>(isValidAction);
            Assert.Equal(Constants.MESSAGE_PLACE_INCOMPLETE_ARGUMENTS, invalidParamatersException.Message);
        }

        [Theory]
        [InlineData("1", "2", "")]
        [InlineData("", "2", "east")]
        [InlineData("1", "", "east")]
        public void Should_Not_Allow_When_RequiredParamsAreMissing(string xaxis, string yaxis, string direction)
        {
            //Arrange
            var commandLineArgs = new string[] { "place", xaxis, yaxis, direction };

            //Act
            void isValidAction() => _placeValidation.IsValid(commandLineArgs, _robotState);

            //Assert
            InvalidParamatersException invalidParamatersException = Assert.Throws<InvalidParamatersException>(isValidAction);
            Assert.Equal(Constants.MESSAGE_PLACE_REQUIRED_PARAMS, invalidParamatersException.Message);
        }

        [Theory]
        [InlineData("1", "5", "north")]
        [InlineData("1", "-11", "south")]
        public void Should_Not_Allow_Beyond_MaxYAxis(string xaxis, string yaxis, string direction)
        {
            //Arrange
            var commandLineArgs = new string[] { "place", xaxis, yaxis, direction };

            //Act
            void isValidAction() => _placeValidation.IsValid(commandLineArgs, _robotState);

            //Assert
            InvalidParamatersException invalidParamatersException = Assert.Throws<InvalidParamatersException>(isValidAction);
            Assert.Equal(Constants.MESSAGE_PLACE_INVALID_YAXIS, invalidParamatersException.Message);
        }

        [Theory]
        [InlineData("10", "1", "east")]
        [InlineData("-7", "1", "west")]
        public void Should_Not_Allow_Beyond_MaxXAxis(string xaxis, string yaxis, string direction)
        {
            //Arrange
            var commandLineArgs = new string[] { "place", xaxis, yaxis, direction };

            //Act
            void isValidAction() => _placeValidation.IsValid(commandLineArgs, _robotState);

            //Assert
            InvalidParamatersException invalidParamatersException = Assert.Throws<InvalidParamatersException>(isValidAction);
            Assert.Equal(Constants.MESSAGE_PLACE_INVALID_XAXIS, invalidParamatersException.Message);
        }

        [Theory]
        [InlineData("1", "1", "fake")]
        [InlineData("1", "1", "wrong direction")]
        public void Should_Not_Allow_Invalid_Direction(string xaxis, string yaxis, string direction)
        {
            //Arrange
            var commandLineArgs = new string[] { "place", xaxis, yaxis, direction };

            //Act
            void isValidAction() => _placeValidation.IsValid(commandLineArgs, _robotState);

            //Assert
            InvalidParamatersException invalidParamatersException = Assert.Throws<InvalidParamatersException>(isValidAction);
            Assert.Equal(Constants.MESSAGE_INVALID_DIRECTION, invalidParamatersException.Message);
        }
    }
}
