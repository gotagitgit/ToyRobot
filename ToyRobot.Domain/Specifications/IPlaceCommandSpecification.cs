namespace ToyRobot.Domain.Specifications
{
    public interface IPlaceCommandSpecification
    {
        List<string> ExceptionMessages { get; }

        bool IsSatisfiedBy(List<string> parameters, string commandString);
    }
}
