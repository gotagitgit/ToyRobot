using ToyRobot.Domain.Models;

namespace ToyRobot.Domain.Factories
{
    public interface ICommandPayloadFactory
    {
        CommandPayload Create(Table table, Command command, string commandString);
    }
}