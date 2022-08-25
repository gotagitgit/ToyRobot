using ToyRobot.Domain.Models;

namespace ToyRobot.Domain.Factories
{
    public class CommandPayloadFactory : ICommandPayloadFactory
    {
        private readonly Dictionary<Command, IParameterizeCommandPayloadFactory> _parameterizeCommandPayloadFactory;

        public CommandPayloadFactory(IEnumerable<IParameterizeCommandPayloadFactory> parameterizeCommandPayloadFactories)
        {
            _parameterizeCommandPayloadFactory = parameterizeCommandPayloadFactories.ToDictionary(x => x.Command, x => x);
        }

        public CommandPayload Create(Table table, Command command, string commandString)
        {
            var isParameterizeCommandPayload = _parameterizeCommandPayloadFactory.TryGetValue(command, out var parameterizeCommandPayloadFactory);

            if (isParameterizeCommandPayload)
                return parameterizeCommandPayloadFactory.Create(table, command, commandString);

            return new CommandPayload(table, command);
        }
    }
}
