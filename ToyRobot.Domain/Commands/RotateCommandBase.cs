using ToyRobot.Domain.Models;

namespace ToyRobot.Domain.Commands
{
    public abstract class RotateCommandBase
    {
        protected Table Rotate(Table table)
        {
            var robot = table.Robot;

            var coordinate = robot.Coordinate;

            var rotateValue = ComputeRotation(coordinate.Direction);

            var direction = (Direction)rotateValue;

            var updatedCoordinate = coordinate.WithDirection(direction);

            var updatedRobot = robot.WithCoordinate(updatedCoordinate);

            return table.WithRobot(updatedRobot);
        }

        protected abstract int ComputeRotation(Direction direction);        
    }
}
