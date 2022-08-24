using ToyRobot.Domain.Models;

namespace ToyRobot.Domain.Factories
{
    public interface IParameterizeCommandPayloadFactory
    {
        Command Command { get; }

        CommandPayload Create(Table table, Command command, string commandString);
    }
}