namespace ToyRobot.Domain.Services
{
    public interface IToyRobotService
    {
        void ProcessCommand(string[] commandStrings);
    }
}