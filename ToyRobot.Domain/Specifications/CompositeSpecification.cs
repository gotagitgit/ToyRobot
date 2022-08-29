namespace ToyRobot.Domain.Specifications
{
    public abstract class CompositeSpecification<T> : ISpecification<T>
    {
        public List<string> ExceptionMessages { get; } = new List<string>();

        public abstract bool IsSatisfiedBy(T category);

        public ISpecification<T> And(ISpecification<T> specification)
        {
            return new AndSpecification<T>(this, specification);
        }

        public ISpecification<T> Or(ISpecification<T> specification)
        {
            return new OrSpecification<T>(this, specification);
        }        

        public ISpecification<T> Not(ISpecification<T> specification)
        {
            return new NotSpecification<T>(specification);
        }
    }
}
