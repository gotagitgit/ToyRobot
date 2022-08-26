using System.Text.RegularExpressions;
using ToyRobot.Domain.Extensions;
using ToyRobot.Domain.Models;

namespace ToyRobot.Domain.Specifications
{
    public class PlaceCommandParameterSpecification : IPlaceCommandSpecification
    {
        public string ExceptionMessage { get; private set; } = String.Empty;

        public bool IsSatisfiedBy(List<string> parameters, string commandString)
        {
            if (!IsValidateParameterPattern(commandString))
            {
                ExceptionMessage = ($"{commandString} has invalid parameter format");

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
