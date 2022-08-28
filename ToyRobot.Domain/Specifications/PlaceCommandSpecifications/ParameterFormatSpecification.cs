using System.Text.RegularExpressions;
using ToyRobot.Domain.Extensions;
using ToyRobot.Domain.Models;

namespace ToyRobot.Domain.Specifications.PlaceCommandSpecifications
{
    internal class ParameterFormatSpecification : CompositeSpecification<PlaceCommandSpecification>
    {
        public override bool IsSatisfiedBy(PlaceCommandSpecification category)
        {
            if (!IsValidParameterPattern(category.CommandString))
            {
                var exceptionMessage = ($"{category.CommandString} has invalid parameter format");

                SetExceptionMessage(exceptionMessage);

                return false;
            }

            return true;
        }

        private static bool IsValidParameterPattern(string commandString)
        {
            var parameterString = Command.Place.GetParameters(commandString);

            var parameter = parameterString.Replace(" ", "");

            const string parameterPattern = @"^[0-9]+,[0-9]+,+\b(north|south|east|west)\b";

            var match = Regex.Match(parameter, parameterPattern, RegexOptions.IgnoreCase);

            return match.Success;
        }
    }
}
