using ToyRobot.Domain.Extensions;
using ToyRobot.Domain.Models;
using ToyRobot.Domain.Specifications;

namespace ToyRobot.Domain.Factories
{
    public class PlaceCommandPayloadFactory : IParameterizeCommandPayloadFactory
    {
        private readonly IPlaceCommandSpecification _placeCommandSpecification;

        public PlaceCommandPayloadFactory(IPlaceCommandSpecification placeCommandSpecification)
        {
            _placeCommandSpecification = placeCommandSpecification;
        }

        public Command Command => Command.Place;

        public CommandPayload Create(Table table, Command command, string commandString)
        {
            var parameters = GetParameters(commandString);

            if (!_placeCommandSpecification.IsSatisfiedBy(parameters, commandString))
                throw new ArgumentException(_placeCommandSpecification.ExceptionMessages[0]);

            _ = int.TryParse(parameters[0], out var xAxis);

            _ = int.TryParse(parameters[1], out var yAxis);

            _ = Enum.TryParse<Direction>(parameters[2], true, out var direction);

            return new PlaceCommandPayload(xAxis, yAxis, direction, table, command);
        }

        private List<string> GetParameters(string commandString)
        {
            var placeCommandLength = Command.ToString().Count();

            var parameterString = Command.GetParameters(commandString);

            var parameters = parameterString.Split(',', placeCommandLength, StringSplitOptions.TrimEntries);

            return parameters.ToList();
        }
    }
}
