using ToyRobot.Domain.Extensions;
using ToyRobot.Domain.Models;
using ToyRobot.Domain.Specifications;
using ToyRobot.Domain.Specifications.PlaceCommandSpecifications;

namespace ToyRobot.Domain.Factories
{
    public class PlaceCommandPayloadFactory : IParameterizeCommandPayloadFactory
    {
        public Command Command => Command.Place;

        public CommandPayload Create(Table table, Command command, string commandString)
        {
            var parameters = GetParameters(commandString);

            if (!IsPlaceCommandSpecificationsSatisfied(parameters, commandString, out var errorMessage))
                throw new ArgumentException(errorMessage);

            _ = int.TryParse(parameters[0], out var xAxis);

            _ = int.TryParse(parameters[1], out var yAxis);

            _ = Enum.TryParse<Direction>(parameters[2], true, out var direction);

            var coordinate = new Coordinate(xAxis, yAxis, direction);

            return new PlaceCommandPayload(coordinate, table, command);
        }

        private List<string> GetParameters(string commandString)
        {
            var placeCommandLength = Command.ToString().Length;

            var parameterString = Command.GetParameters(commandString);

            var parameters = parameterString.Split(',', placeCommandLength, StringSplitOptions.TrimEntries);

            return parameters.ToList();
        }

        private static bool IsPlaceCommandSpecificationsSatisfied(List<string> parameters, string commandString, out string? errorMessage)
        {
            var placeCommandSpecification = new PlaceCommandSpecification(commandString, parameters);
            
            var specification = CreateSpecification();

            var isValid = specification.IsSatisfiedBy(placeCommandSpecification);

            errorMessage = specification.ExceptionMessages.FirstOrDefault();

            return isValid;
        }

        private static ISpecification<PlaceCommandSpecification> CreateSpecification()
        {
            var parameterCountSpecification = new ParameterCountSpecification();

            var parameterFormatSpecifiation = new ParameterFormatSpecification();

            return parameterCountSpecification.And(parameterFormatSpecifiation);
        }
    }
}
