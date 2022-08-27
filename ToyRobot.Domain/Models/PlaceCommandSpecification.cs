namespace ToyRobot.Domain.Models
{
    public sealed class PlaceCommandSpecification
    {
        public PlaceCommandSpecification(string commandString, List<string> parameters)
        {
            CommandString = commandString;
            Parameters = parameters;
        }

        public string CommandString { get; }

        public List<string> Parameters { get; }
    }
}
