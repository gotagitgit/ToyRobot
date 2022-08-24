using ToyRobot.Domain.Commands;
using ToyRobot.Domain.Models;

namespace ToyRobot.Domain.Factories
{
    public interface ICommandHandlerFactory
    {
        ICommandHandler Create(Command command);
    }
}