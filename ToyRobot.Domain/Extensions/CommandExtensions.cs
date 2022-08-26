using ToyRobot.Domain.Models;

namespace ToyRobot.Domain.Extensions
{
    public static class CommandExtensions
    {
        public static string GetParameters(this Command command, string commandString)
        {
            var placeCommandLength = command.ToString().Count();

            return commandString.Trim().Substring(placeCommandLength);
        }
    }
}
