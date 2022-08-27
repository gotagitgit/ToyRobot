using ToyRobot.Domain.Extensions;
using ToyRobot.Domain.Models;
using ToyRobot.Domain.Specifications;

namespace ToyRobot.Domain.Factories
{
    public class PlaceCommandPayloadFactory : IParameterizeCommandPayloadFactory
    {
        private readonly List<ISpecification<PlaceCommandSpecification>> _placeCommandSpecifications;

        public PlaceCommandPayloadFactory(IEnumerable<ISpecification<PlaceCommandSpecification>> placeCommandSpecification)
        {
            _placeCommandSpecifications = placeCommandSpecification.ToList();
        }

        public Command Command => Command.Place;

        public CommandPayload Create(Table table, Command command, string commandString)
        {
            var parameters = GetParameters(commandString);

            if (TryGetSpecificationException(parameters, commandString, out var errorMessage))
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

        private bool TryGetSpecificationException(List<string> parameters, string commandString, out string? errorMessage)
        {
            var placeCommandSpecification = new PlaceCommandSpecification(commandString, parameters);

            var specifications = _placeCommandSpecifications.Select(x =>
                      (
                          IsSatisfied: x.IsSatisfiedBy(placeCommandSpecification), x.ExceptionMessage
                      )).ToList();

            errorMessage = specifications.Where(x => !x.IsSatisfied)
                                .Select(x => x.ExceptionMessage).FirstOrDefault();

            return specifications.Any(x => !x.IsSatisfied);
        }
    }
}
