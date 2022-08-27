namespace ToyRobot.Domain.Specifications
{
    public interface ISpecification<T>
    {
        string ExceptionMessage { get; }

        bool IsSatisfiedBy(T category);
    }
}
