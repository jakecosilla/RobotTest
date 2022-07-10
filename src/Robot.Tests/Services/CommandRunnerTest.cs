using Moq;
using Robot.Core.Interfaces;
using Robot.Core.Models;
using Robot.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Robot.Tests.Services
{
    public class CommandRunnerTest
    {
        private CommandRunner _commandRunner;
        private RobotState _robotState;
        private Mock<ICommand> _mockCommand;
        private Mock<ICommandValidation> _mockCommandValidation;
        public CommandRunnerTest()
        {
            _mockCommandValidation = new Mock<ICommandValidation>();
            _mockCommandValidation.Setup(_ => _.IsValid(It.IsAny<string[]>(), It.IsAny<RobotState>())).Returns(true);
            _mockCommand = new Mock<ICommand>();
            _robotState = new RobotState();
            _commandRunner = new CommandRunner(_mockCommand.Object, _mockCommandValidation.Object);
        }

        [Fact]
        public void Should_Call_PlaceCommand()
        {
            //Arrage
            var commandLineArgs = new string[] { "place" };

            //Act
            _commandRunner.Execute(commandLineArgs, _robotState);

            //Assert
            _mockCommand.Verify(_ => _.Place(commandLineArgs, _robotState));
        }

        [Fact]
        public void Should_Call_MoveCommand()
        {
            //Arrage
            var commandLineArgs = new string[] { "move" };

            //Act
            _commandRunner.Execute(commandLineArgs, _robotState);

            //Assert
            _mockCommand.Verify(_ => _.Move(_robotState));
        }

        [Fact]
        public void Should_Call_LeftCommand()
        {
            //Arrage
            var commandLineArgs = new string[] { "left" };

            //Act
            _commandRunner.Execute(commandLineArgs, _robotState);

            //Assert
            _mockCommand.Verify(_ => _.Left(_robotState));
        }

        [Fact]
        public void Should_Call_RightCommand()
        {
            //Arrage
            var commandLineArgs = new string[] { "right" };

            //Act
            _commandRunner.Execute(commandLineArgs, _robotState);

            //Assert
            _mockCommand.Verify(_ => _.Right(_robotState));
        }

        [Fact]
        public void Should_Call_ReportCommand()
        {
            //Arrage
            var commandLineArgs = new string[] { "report" };

            //Act
            _commandRunner.Execute(commandLineArgs, _robotState);

            //Assert
            _mockCommand.Verify(_ => _.Report(_robotState));
        }
    }
}
