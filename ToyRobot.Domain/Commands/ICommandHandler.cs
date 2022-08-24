using ToyRobot.Domain.Models;

namespace ToyRobot.Domain.Commands
{
    public interface ICommandHandler
    {
        Command Command { get; }

        Table Handle(CommandPayload payload);
    }
}