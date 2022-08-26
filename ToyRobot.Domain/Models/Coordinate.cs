namespace ToyRobot.Domain.Models
{
    public class Coordinate
    {
        public Coordinate(int x, int y, Direction direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }

        public int X { get; }
        public int Y { get; }
        public Direction Direction { get; }

        public static Coordinate Origin => new Coordinate(0, 0, Direction.North);

        public Coordinate WithXCoordinate(int x)
        {
            return new Coordinate(x, Y, Direction);
        }

        public Coordinate WithYCoordinate(int y)
        {
            return new Coordinate(X, y, Direction);
        }

        public Coordinate WithDirection(Direction direction)
        {
            return new Coordinate(X, Y, direction);
        }
    }
}
