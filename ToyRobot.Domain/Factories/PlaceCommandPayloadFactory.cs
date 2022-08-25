using ToyRobot.Domain.Models;

namespace ToyRobot.Domain.Factories
{
    public class PlaceCommandPayloadFactory : IParameterizeCommandPayloadFactory
    {
        public Command Command => Command.Place;

        public CommandPayload Create(Table table, Command command, string commandString)
        {
            var commandArgs = commandString.Split(' ').ToList();

            if (commandArgs.Count < 2)
                throw new ArgumentException($"{commandString} is missing parameters.");

            var parameters = commandArgs[1].Split(',', StringSplitOptions.TrimEntries).ToList();

            if (!(parameters.Count == 3))
                throw new ArgumentException($"{commandString} has missing parameter arguments");

            var xAxis = ToInt(parameters[0]);
            var yAxis = ToInt(parameters[1]);

            var isValidDirectionParameter = Enum.TryParse<Direction>(parameters[2], true, out var direction);

            if (!isValidDirectionParameter)
                throw new ArgumentException($"{commandString} direction parameter is invalid.");

            return new PlaceCommandPayload(xAxis, yAxis, direction, table, command);
        }

        private static int ToInt(string value)
        {
            var isValidInteger = int.TryParse(value, out var integerValue);

            if (isValidInteger)
                return integerValue;

            throw new ArgumentException($"Can't parse the {value} from the parameter to integer.");
        }
    }
}
