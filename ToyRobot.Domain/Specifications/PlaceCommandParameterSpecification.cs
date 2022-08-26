using System.Text.RegularExpressions;
using ToyRobot.Domain.Extensions;
using ToyRobot.Domain.Models;

namespace ToyRobot.Domain.Specifications
{
    public class PlaceCommandParameterSpecification : IPlaceCommandSpecification
    {
        public List<string> ExceptionMessages { get; } = new List<string>();

        public bool IsSatisfiedBy(List<string> parameters, string commandString)
        {
            if (!IsValidateParameterPattern(commandString))
            {
                ExceptionMessages.Add($"{commandString} has invalid parameter format");

                return false;
            }

            return true;
        }

        private static bool IsValidateParameterPattern(string commandString)
        {
            var parameterString = Command.Place.GetParameters(commandString);

            var parameter = parameterString.Replace(" ", "");

            const string parameterPattern = @"^[0-9]+,[0-9]+,+\b(north|south|east|west)\b";

            var match = Regex.Match(parameter, parameterPattern, RegexOptions.IgnoreCase);

            return match.Success;
        }
    }
}
