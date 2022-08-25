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
                var robot = new Robot(placeCommandPayload.X, placeCommandPayload.Y, placeCommandPayload.Direction);

                return table.WithRobot(robot);
            }

            return table;
        }
    }
}
