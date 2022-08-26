using ToyRobot.Domain.Models;

namespace ToyRobot.Domain.Commands
{
    public sealed class PlaceCommand : ICommand
    {
        public Command Command => Command.Place;

        public Table Execute(CommandPayload payload)
        {
            var table = payload.Table;

            if (payload is PlaceCommandPayload placeCommandPayload)
            {
                var coordinate = new Coordinate(placeCommandPayload.X, placeCommandPayload.Y, placeCommandPayload.Direction);

                var robot = new Robot(coordinate);

                if (table.IsRobotFalling(placeCommandPayload.X, placeCommandPayload.Y))
                    throw new InvalidOperationException("The command x and y coordinates are out of bounds");

                return table.SetRobotInPlace()
                            .WithRobot(robot);
            }

            return table;
        }
    }
}
