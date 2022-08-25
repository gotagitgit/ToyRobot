using ToyRobot.Domain.Commands;
using ToyRobot.Domain.Models;

namespace ToyRobot.Domain.Factories
{
    public interface ICommandFactory
    {
        ICommand Create(Command command);
    }
}