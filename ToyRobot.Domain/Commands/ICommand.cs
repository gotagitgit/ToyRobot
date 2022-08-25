using ToyRobot.Domain.Models;

namespace ToyRobot.Domain.Commands
{
    public interface ICommand
    {
        Command Command { get; }

        Table Execute(CommandPayload payload);
    }
}