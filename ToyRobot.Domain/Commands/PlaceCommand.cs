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

                return table.SetRobotInPlace()
                            .WithRobot(robot);
            }

            return table;
        }
    }
}
