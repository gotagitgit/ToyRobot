namespace ToyRobot.Domain.Specifications
{
    public sealed class PlaceCommandSpecification : IPlaceCommandSpecification
    {
        public string ExceptionMessage { get; private set; } = String.Empty;

        public bool IsSatisfiedBy(List<string> parameters, string commandString)
        {
            if (parameters.Count > 3)
            {
                ExceptionMessage = ($"{commandString} has more than the allowed number of parameters");

                return false;
            }

            return true;
        }
    }
}
