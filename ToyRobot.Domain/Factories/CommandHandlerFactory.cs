using ToyRobot.Domain.Commands;
using ToyRobot.Domain.Models;

namespace ToyRobot.Domain.Factories
{
    public sealed class CommandHandlerFactory : ICommandHandlerFactory
    {
        private readonly Dictionary<Command, ICommand> _commandHandlers;

        public CommandHandlerFactory(IEnumerable<ICommand> commandHandlers)
        {
            _commandHandlers = commandHandlers.ToDictionary(x => x.Command, x => x);
        }

        public ICommand Create(Command command)
        {
            if (_commandHandlers.TryGetValue(command, out var handler))
                return handler;

            throw new ArgumentException($"{command} is not yet implemented.");
        }
    }
}
