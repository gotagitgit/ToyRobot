namespace ToyRobot.Domain.Models
{
    public sealed class PlaceCommandPayload : CommandPayload
    {
        public PlaceCommandPayload(int x, int y, Direction direction, Table table, Command command) : base(table, command)
        {
            X = x;
            Y = y;
            Direction = direction;
        }

        public int X { get; }
        public int Y { get; }
        public Direction Direction { get; }
    }
}
