using ToyRobot.Domain.Models;

namespace ToyRobot.Domain.Commands
{
    public sealed class MoveCommand : ICommand
    {
        private const int Move1Unit = 1;

        public Command Command => Command.Move;

        public Table Execute(CommandPayload payload)
        {
            var robot = payload.Table.Robot;            

            var updatedCoordinate = MoveCoordinateTo1Unit(robot.Coordinate);

            var table = payload.Table;

            var isRobotFalling = payload.Table.IsRobotFalling(updatedCoordinate.X, updatedCoordinate.Y);           

            if (isRobotFalling)
                return table;

            var updatedRobot = robot.WithCoordinate(updatedCoordinate);

            return table.WithRobot(updatedRobot);
        }

        private static Coordinate MoveCoordinateTo1Unit(Coordinate coordinate)
        {
            return coordinate.Direction switch
            {
                Direction.North => coordinate.WithYCoordinate(coordinate.Y + Move1Unit),
                Direction.East => coordinate.WithXCoordinate(coordinate.X + Move1Unit),
                Direction.West => coordinate.WithXCoordinate(coordinate.X - Move1Unit),
                Direction.South => coordinate.WithYCoordinate(coordinate.Y - Move1Unit),
                _ => coordinate,
            };
        }        
    }
}
