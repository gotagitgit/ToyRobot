using ToyRobot.Domain.Factories;
using ToyRobot.Domain.Models;

namespace ToyRobot.Domain.Services
{
    public sealed class ToyRobotService : IToyRobotService
    {
        private readonly IParseStringCommandService _parseStringCommandService;
        private readonly ICommandHandlerFactory _commandHandlerFactory;
        private Table _table;

        public ToyRobotService(
            IParseStringCommandService parseStringCommandService,
            ICommandHandlerFactory commandHandlerFactory)
        {
            _parseStringCommandService = parseStringCommandService;
            _commandHandlerFactory = commandHandlerFactory;
        }

        public void CreateTable(int length, int width)
        {
            _table = new Table(length, width);
        }

        public void ProcessCommand(string[] commandStrings)
        {
            var table = _table;
            if (table == null)
                table = Table.Default();

            foreach (var commandString in commandStrings)
            {
                if (string.IsNullOrEmpty(commandString))
                    continue;

                var commandPayload = _parseStringCommandService.Parse(commandString, table);

                var commandHandler = _commandHandlerFactory.Create(commandPayload.Command);

                table = commandHandler.Handle(commandPayload);
            }
        }
    }
}
