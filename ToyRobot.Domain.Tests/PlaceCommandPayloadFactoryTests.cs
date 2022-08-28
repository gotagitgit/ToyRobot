using FluentAssertions;
using ToyRobot.Domain.Factories;
using ToyRobot.Domain.Models;
using ToyRobot.Domain.Specifications;
using Xunit;

namespace ToyRobot.Domain.Tests
{
    public class PlaceCommandPayloadFactoryTests
    {
        public PlaceCommandPayloadFactory Sut { get; } = new();

        [Theory]
        [InlineData("PLACE 0,0,NORTH")]
        [InlineData("place 0,0,north")]
        [InlineData("PlaCE 0,0,NORTH")]
        [InlineData(" PLACE 0,0,NORTH ")]
        [InlineData("PLACE 0, 0,  NORTH")]      
        public void Can_create_place_command_payload(string commandString)
        {
            // Arrange            
            var table = Table.Default();
            var command = Command.Place;
            var coordinate = new Coordinate(0, 0, Direction.North);
            var expected = new PlaceCommandPayload(coordinate, table, command);

            // Act 
            var result = Sut.Create(table, command, commandString);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData("PLACE")]
        [InlineData("PLACE 0")]
        [InlineData("PLACE 0,0")]
        [InlineData("PLACE 0,0,0")]
        [InlineData("PLACE 0,,North")]
        [InlineData("PLACE ,0,North")]
        [InlineData("PLACE 0,0,NorthWest")]
        [InlineData("PLACE north,south,North")]
        [InlineData("PLACE -1,-1,North")]
        [InlineData("PLACE 1.2,2,North")]
        [InlineData("PLACE 1,2.5,North")]
        public void Should_throw_when_parameter_format_is_invalid(string commandString)
        {
            // Arrange            
            var table = Table.Default();
            var command = Command.Place;           

            // Act 
            var ex  = Assert.Throws<ArgumentException>(() => Sut.Create(table, command, commandString));

            // Assert
            ex.Message.Should().BeEquivalentTo($"{commandString} has invalid parameter format");
        }

        [Fact]
        public void Should_throw_when_parameter_count_is_more_than_expected()
        {
            // Arrange            
            var table = Table.Default();
            var command = Command.Place;
            var commandString = "PLACE 1,2,North,ExtraParam";

            // Act 
            var ex = Assert.Throws<ArgumentException>(() => Sut.Create(table, command, commandString));

            // Assert
            ex.Message.Should().BeEquivalentTo($"{commandString} has more than the allowed number of parameters");
        }
    }
}
