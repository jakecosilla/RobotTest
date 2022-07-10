using FluentAssertions;
using FluentAssertions.Execution;
using Robot.Core.Models;
using Robot.Core.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace Robot.Tests.Services
{
    public class CommandTest
    {
        private RobotState _robotState;
        private Command _command;
        private readonly int _xaxis = 1;
        private readonly int _yaxis = 2;
        private List<string> _commandPlace;
        public CommandTest()
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
            _command = new Command();
            _commandPlace = new List<string>() { "place", _xaxis.ToString(), _yaxis.ToString() };
        }

        [Fact]
        public void PlaceCommand_ShouldReturnRobotStateWithCorrectLocation()
        {
            //Arrange
            var xaxis = 1;
            var yaxis = 2;
            _commandPlace.Add("east");
            var commandArray = _commandPlace.ToArray();

            //Act
            var actual = _command.Place(commandArray, _robotState);

            //Assert
            using (new AssertionScope())
            {
                actual.Location.XAxis.Should().Be(xaxis);
                actual.Location.YAxis.Should().Be(yaxis);
                actual.Location.Direction.Should().Be(Enum.Parse<DirectionEnum>(commandArray[3], true));
            }
        }
        [Fact]
        public void PlaceCommand_ShouldReturnRobotStateWithIsPlaced_True()
        {
            //Arrange
            _commandPlace.Add("north");
            var commandArray = _commandPlace.ToArray();

            //Act
            var actual = _command.Place(commandArray, _robotState);

            //Assert
            actual.IsPlaced.Should().BeTrue();
        }

        [Fact]
        public void MoveCommand_ShouldUpdate_YAxis_GoingNorth()
        {
            //Arrange
            _commandPlace.Add("north");
            var commandPlace = _commandPlace.ToArray();

            //Act
            var robotState = _command.Place(commandPlace, _robotState);
            var actual = _command.Move(robotState);

            //Assert
            actual.Location.YAxis.Should().Be(_yaxis + 1);
        }

        [Fact]
        public void MoveCommand_ShouldUpdate_YAxis_GoingSouth()
        {
            //Arrange
            _commandPlace.Add("south");
            var commandPlace = _commandPlace.ToArray();

            //Act
            var robotState = _command.Place(commandPlace, _robotState);
            var actual = _command.Move(robotState);

            //Assert
            actual.Location.YAxis.Should().Be(_yaxis - 1);
        }

        [Fact]
        public void MoveCommand_ShouldUpdate_XAxis_GoingEast()
        {
            //Arrange
            _commandPlace.Add("east");
            var commandPlace = _commandPlace.ToArray();

            //Act
            var robotState = _command.Place(commandPlace, _robotState);
            var actual = _command.Move(robotState);

            //Assert
            actual.Location.XAxis.Should().Be(_xaxis + 1);
        }

        [Fact]
        public void MoveCommand_ShouldUpdate_XAxis_GoingWest()
        {
            //Arrange
            _commandPlace.Add("west");
            var commandPlace = _commandPlace.ToArray();

            //Act
            var robotState = _command.Place(commandPlace, _robotState);
            var actual = _command.Move(robotState);

            //Assert
            actual.Location.XAxis.Should().Be(_xaxis - 1);
        }

        [Fact]
        public void LeftCommand_ShouldUpdate_Direction()
        {
            //Arrange
            _commandPlace.Add("north");
            var commandPlace = _commandPlace.ToArray();

            //Act
            var robotState = _command.Place(commandPlace, _robotState);
            robotState = _command.Left(robotState);
            var northToWest = robotState.Location.Direction;
            robotState = _command.Left(robotState);
            var westToSouth = robotState.Location.Direction;
            robotState = _command.Left(robotState);
            var southToEast = robotState.Location.Direction;
            robotState = _command.Left(robotState);
            var eastToNorth = robotState.Location.Direction;

            //Assert
            using (new AssertionScope())
            {
                northToWest.Should().Be(DirectionEnum.West);
                westToSouth.Should().Be(DirectionEnum.South);
                southToEast.Should().Be(DirectionEnum.East);
                eastToNorth.Should().Be(DirectionEnum.North);
            }
        }

        [Fact]
        public void RightCommand_ShouldUpdate_Direction()
        {
            //Arrange
            _commandPlace.Add("north");
            var commandPlace = _commandPlace.ToArray();

            //Act
            var robotState = _command.Place(commandPlace, _robotState);
            robotState = _command.Right(robotState);
            var northToEast = robotState.Location.Direction;
            robotState = _command.Right(robotState);
            var eastToSouth = robotState.Location.Direction;
            robotState = _command.Right(robotState);
            var southToWest = robotState.Location.Direction;
            robotState = _command.Right(robotState);
            var westToNorth = robotState.Location.Direction;

            //Assert
            using (new AssertionScope())
            {
                northToEast.Should().Be(DirectionEnum.East);
                eastToSouth.Should().Be(DirectionEnum.South);
                southToWest.Should().Be(DirectionEnum.West);
                westToNorth.Should().Be(DirectionEnum.North);
            }
        }
    }
}
