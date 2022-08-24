using ToyRobot.Domain.Models;

namespace ToyRobot.Domain.Factories
{
    internal interface ICommandPayloadFactory
    {
        CommandPayload Create(Table table, Command command, string commandString);
    }
}