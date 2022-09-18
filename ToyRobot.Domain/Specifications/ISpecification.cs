namespace ToyRobot.Domain.Specifications
{
    public interface ISpecification<T>
    {
        List<string> ExceptionMessages { get; }

        bool IsSatisfiedBy(T category);
    }
}
