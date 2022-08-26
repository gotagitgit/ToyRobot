using System.Text.RegularExpressions;
using ToyRobot.Domain.Models;
using ToyRobot.Domain.Extensions;

namespace ToyRobot.Domain.Specifications
{
    public sealed class PlaceCommandSpecification : IPlaceCommandSpecification
    {
        public PlaceCommandSpecification()
        {
            ExceptionMessages = new List<string>();
        }

        public List<string> ExceptionMessages { get; }

        public bool IsSatisfiedBy(List<string> parameters, string commandString)
        {
            return ValidateParameterFormat(commandString) && 
                   ValidateParameterCount(parameters, commandString);

        }

        private bool ValidateParameterCount(List<string> parameters, string commandString)
        {
            if (parameters.Count > 3)
            {
                ExceptionMessages.Add($"{commandString} has more than the allowed number of parameters");

                return false;
            }

            return true;
        }

        private bool ValidateParameterFormat(string commandString)
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
