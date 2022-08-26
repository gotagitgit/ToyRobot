namespace ToyRobot.Domain.Specifications
{
    public sealed class PlaceCommandSpecification : IPlaceCommandSpecification
    {
        public List<string> ExceptionMessages { get; } = new List<string>();

        public bool IsSatisfiedBy(List<string> parameters, string commandString)
        {
            if (parameters.Count > 3)
            {
                ExceptionMessages.Add($"{commandString} has more than the allowed number of parameters");

                return false;
            }

            return true;
        }
    }
}
