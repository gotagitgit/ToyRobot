namespace ToyRobot.Domain.Models
{
    public sealed class Robot
    {
        public Robot(Coordinate coordinate)
        {
            Coordinate = coordinate;
        }

        //public Robot(int xPosition, int yPosition, Direction direction)
        //{
        //    Coordinate = new Coordinate(xPosition, yPosition, direction);
        //}

        public Coordinate Coordinate { get; }

        public static Robot Empty() => new Robot(Coordinate.Origin);

        public Robot WithCoordinate(Coordinate coordinate)
        {
            return new Robot(coordinate);
        }
    }
}
