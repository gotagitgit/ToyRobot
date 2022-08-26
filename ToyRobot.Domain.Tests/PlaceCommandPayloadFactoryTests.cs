using FluentAssertions;
using ToyRobot.Domain.Factories;
using ToyRobot.Domain.Models;
using Xunit;

namespace ToyRobot.Domain.Tests
{
    public class PlaceCommandPayloadFactoryTests
    {
        public PlaceCommandPayloadFactoryTests()
        {
            Sut = new PlaceCommandPayloadFactory();
        }

        public PlaceCommandPayloadFactory Sut { get; }

        [Theory]
        [InlineData("PLACE 0,0,NORTH")]
        [InlineData("place 0,0,NORTH")]
        [InlineData("PlaCE 0,0,NORTH")]
        [InlineData(" PLACE 0,0,NORTH ")]
        [InlineData("PLACE 0, 0,  NORTH")]
        public void Can_create_place_command_payload(string commandString)
        {
            // Arrange            
            var table = Table.Default();
            var command = Command.Place;
            var expected = new PlaceCommandPayload(0, 0, Direction.North, table, command);

            // Act 
            var result = Sut.Create(table, command, commandString);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

    }
}
