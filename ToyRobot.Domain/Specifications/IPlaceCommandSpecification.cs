namespace ToyRobot.Domain.Specifications
{
    public interface IPlaceCommandSpecification
    {
        string ExceptionMessage { get; }

        bool IsSatisfiedBy(List<string> parameters, string commandString);
    }
}
