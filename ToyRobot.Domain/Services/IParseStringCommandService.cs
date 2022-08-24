using ToyRobot.Domain.Models;

namespace ToyRobot.Domain.Services
{
    public interface IParseStringCommandService
    {
        CommandPayload Parse(string commandString, Table table);
    }
}