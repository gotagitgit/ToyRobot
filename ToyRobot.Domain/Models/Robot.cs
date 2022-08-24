namespace ToyRobot.Domain.Models
{
    public sealed class Robot
    {
        public Robot(int xPosition, int yPosition, Direction direction)
        {
            Coordinate = new Coordinate(xPosition, yPosition, direction);
        }

        public Coordinate Coordinate { get; }

        public static Robot Empty() => new Robot(0, 0, Direction.North);

        public Robot WithCoordinate(Coordinate coordinate)
        {
            return new Robot(coordinate.X, coordinate.Y, coordinate.Direction);
        }
    }
}
