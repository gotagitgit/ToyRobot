using ToyRobot.Domain.Models;

namespace ToyRobot.Domain.Services
{
    public interface IToyRobotService
    {
        Table ProcessCommand(string[] commandStrings);
    }
}