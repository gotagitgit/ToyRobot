using ToyRobot.Domain.Models;

namespace ToyRobot.Domain.Commands
{
    public sealed class PlaceCommand : ICommand, IPrimaryCommand
    {
        public Command Command => Command.Place;

        public bool IsPrimaryCommnd => true;

        public Table Execute(CommandPayload payload)
        {
            var table = payload.Table;

            if (payload is PlaceCommandPayload placeCommandPayload)
            {
                var payloadCoordinate = placeCommandPayload.Coordinate;
                var xAxis = payloadCoordinate.X;
                var yAxis = payloadCoordinate.Y;

                var coordinate = new Coordinate(xAxis, yAxis, payloadCoordinate.Direction);

                var robot = new Robot(coordinate);

                if (table.IsRobotFalling(xAxis, yAxis))
                    return table;

                return table.SetRobotInPlace()
                            .WithRobot(robot);
            }

            return table;
        }
    }
}
