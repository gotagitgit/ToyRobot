using FluentAssertions;
using ToyRobot.Domain.Models;
using Xunit;

namespace ToyRobot.Domain.Tests
{
    public class ToyRobotServiceTests : TestBase
    {
        public ToyRobotServiceTests(TestFixture fixture) : base(fixture)
        {
        }

        [Theory]
        [InlineData(Direction.North, 2, 4)]
        [InlineData(Direction.East, 4, 2)]
        [InlineData(Direction.West, 0, 2)]
        [InlineData(Direction.South, 2, 0)]
        public void Robot_should_not_fall_into_destruction(Direction direction, int xAxis, int yAxis)
        {
            // Arrange
            var commands = new string[] { $"PLACE 2,2,{direction}", "MOVE", "MOVE", "MOVE", "MOVE", "MOVE", "MOVE", "MOVE" };

            // Act
            var result = ToyRobotService.ProcessCommand(commands);

            // Assert
            var coordinate = result.Robot.Coordinate;
            coordinate.Should().BeEquivalentTo(new Coordinate(xAxis, yAxis, direction));
        }

        [Fact]
        public void Should_ignore_commands_until_place_command_is_executed()
        {
            // Arrange
            var commands = new string[] { "MOVE", "MOVE", "MOVE", "MOVE", "MOVE", $"PLACE 2,2,NORTH", "MOVE", "MOVE" };

            // Act
            var result = ToyRobotService.ProcessCommand(commands);

            // Assert
            var coordinate = result.Robot.Coordinate;
            coordinate.Should().BeEquivalentTo(new Coordinate(2, 4, Direction.North));
        }

        [Theory]
        [InlineData("LEFT", 0, 4, Direction.West)]
        [InlineData("RIGHT", 4, 4, Direction.East)]
        public void Robot_should_be_able_to_change_direction(string command, int xAxis, int yAxis, Direction direction)
        {
            // Arrange
            var commands = new string[] { $"PLACE 2,2,NORTH", "MOVE", "MOVE", command, "MOVE", "MOVE" };

            // Act
            var result = ToyRobotService.ProcessCommand(commands);

            // Assert
            var coordinate = result.Robot.Coordinate;
            coordinate.Should().BeEquivalentTo(new Coordinate(xAxis, yAxis, direction));
        }

        [Theory]
        [InlineData("LEFT", Direction.North)]
        [InlineData("RIGHT", Direction.North)]
        public void Robot_can_do_360_rotation(string command, Direction direction)
        {
            // Arrange
            var commands = new string[] { $"PLACE 2,2,NORTH", command, command, command, command };

            // Act
            var result = ToyRobotService.ProcessCommand(commands);

            // Assert
            var coordinate = result.Robot.Coordinate;
            coordinate.Should().BeEquivalentTo(new Coordinate(2, 2, direction));
        }

        [Fact]
        public void Should_ignore_empty_string_commands()
        {
            // Arrange
            var commands = new string[] { $"PLACE 2,2,NORTH", "MOVE", "", "MOVE", "", "MOVE",  "", "MOVE" };

            // Act
            var result = ToyRobotService.ProcessCommand(commands);

            // Assert
            var coordinate = result.Robot.Coordinate;
            coordinate.Should().BeEquivalentTo(new Coordinate(2, 4, Direction.North));
        }

        [Fact]
        public void Should_throw_when_command_is_invalid()
        {
            // Arrange
            var invalidCommand = "Invalid Command";
            var commands = new string[] { $"PLACE 2,2,NORTH", "MOVE", invalidCommand, "MOVE", "", "MOVE",  "", "MOVE" };

            // Act
            var ex = Assert.Throws<InvalidOperationException>(() => ToyRobotService.ProcessCommand(commands));

            // Assert
            ex.Message.Should().Be($"{invalidCommand} is not a valid command");
        }

        [Fact]
        public void Should_throw_when_place_is_out_of_bounds()
        {
            // Arrange
            var commands = new string[] { $"PLACE 100,100,NORTH", "MOVE", "", "MOVE", "", "MOVE",  "", "MOVE" };

            // Act
            var ex = Assert.Throws<InvalidOperationException>(() => ToyRobotService.ProcessCommand(commands));

            // Assert
            ex.Message.Should().Be("The command x and y coordinates are out of bounds");
        }
    }
}