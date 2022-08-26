using FluentAssertions;
using Moq;
using ToyRobot.Domain.Factories;
using ToyRobot.Domain.Models;
using ToyRobot.Domain.Services;
using Xunit;

namespace ToyRobot.Domain.Tests
{
    public class ParseStringCommandServiceTests
    {
        public ParseStringCommandServiceTests()
        {
            Context = new TestContext();

            Sut = new ParseStringCommandService(Context.CommandPayloadFactory.Object);
        }

        public TestContext Context { get; }

        public ParseStringCommandService Sut { get; }

        [Theory]
        [InlineData("PLACE 1,2,North", Command.Place)]
        [InlineData("place 1,2,North", Command.Place)]
        [InlineData("Move", Command.Move)]
        [InlineData("left", Command.Left)]
        [InlineData("Right", Command.Right)]
        [InlineData("Report", Command.Report)]
        public void Should_parse_command(string commandString, Command command)
        {
            // Arrange
            var table = Table.Default();

            // Act
            _ = Sut.Parse(commandString, table);

            // Assert
            Context.CommandPayloadFactory.Verify(x => x.Create(
                It.Is<Table>(x => x.Equals(table)),
                It.Is<Command>(x => x.Equals(command)),
                It.Is<string>(x => x.Equals(commandString))));
        }

        [Theory]
        [InlineData("InvalidCommand")]
        [InlineData("Parse1,2,North")]
        [InlineData("")]
        public void Should_throw_when_command_is_invalid(string commandString)
        {
            // Arrange
            var table = Table.Default();

            // Act
            var ex = Assert.Throws<InvalidOperationException>( () => Sut.Parse(commandString, table));

            // Assert
            ex.Message.Should().Be($"{commandString} is not a valid command");
        }

        public class TestContext
        {
            public Mock<ICommandPayloadFactory> CommandPayloadFactory = new();
        }
    }
}
