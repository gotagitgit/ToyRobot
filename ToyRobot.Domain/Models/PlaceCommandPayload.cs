namespace ToyRobot.Domain.Models
{
    public sealed class PlaceCommandPayload : CommandPayload
    {
        public PlaceCommandPayload(Coordinate coordinate, Table table, Command command) : base(table, command)
        {
            Coordinate = coordinate;
        }

        public Coordinate Coordinate { get; }

    }
}
