﻿using ToyRobot.Domain.Extensions;
using ToyRobot.Domain.Models;
using ToyRobot.Domain.Specifications;

namespace ToyRobot.Domain.Factories
{
    public class PlaceCommandPayloadFactory : IParameterizeCommandPayloadFactory
    {
        private readonly List<IPlaceCommandSpecification> _placeCommandSpecifications;

        public PlaceCommandPayloadFactory(IEnumerable<IPlaceCommandSpecification> placeCommandSpecification)
        {
            _placeCommandSpecifications = placeCommandSpecification.ToList();
        }

        public Command Command => Command.Place;

        public CommandPayload Create(Table table, Command command, string commandString)
        {
            var parameters = GetParameters(commandString);

            if (TryGetSpecificationException(parameters, commandString, out var errorMessages))
                throw new ArgumentException(errorMessages[0]);

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

        private bool TryGetSpecificationException(List<string> parameters, string commandString, out List<string> errorMessages)
        {
            var specifications = _placeCommandSpecifications.Select(x =>
                      (
                          IsSatisfied: x.IsSatisfiedBy(parameters, commandString), 
                          ErrorMessages: x.ExceptionMessages
                      )).ToList();

            errorMessages = specifications.Where(x => !x.IsSatisfied).SelectMany(x => x.ErrorMessages).ToList();

            return specifications.Any(x => !x.IsSatisfied);
        }
    }
}
