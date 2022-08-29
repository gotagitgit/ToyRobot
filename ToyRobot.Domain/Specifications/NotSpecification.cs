namespace ToyRobot.Domain.Specifications
{
    public sealed class NotSpecification<T> : CompositeSpecification<T>
    {
        private readonly ISpecification<T> _specification;

        public NotSpecification(ISpecification<T> specification)
        {
            _specification = specification;
        }

        public override bool IsSatisfiedBy(T category)
        {
            var isSatisfied = !_specification.IsSatisfiedBy(category);

            ExceptionMessages.AddRange(_specification.ExceptionMessages);

            return isSatisfied;
        }
    }
}
