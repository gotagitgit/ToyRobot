using ToyRobot.Domain.Factories;
using ToyRobot.Domain.Models;

namespace ToyRobot.Domain.Services
{
    public sealed class ParseStringCommandService : IParseStringCommandService
    {
        private readonly ICommandPayloadFactory _commandPayloadFactory;

        public ParseStringCommandService(ICommandPayloadFactory commandPayloadFactory)
        {
            _commandPayloadFactory = commandPayloadFactory;
        }

        public CommandPayload Parse(string commandString, Table table)
        {
            var commandArgs = commandString.Split(' ');

            var commandValue = commandArgs[0];

            var isValidCommand = Enum.TryParse<Command>(commandValue, true, out var command);

            if (!isValidCommand)
                throw new ArgumentException($"{commandString} is not a valid command");

            return _commandPayloadFactory.Create(table, command, commandString);
        }
    }
}
