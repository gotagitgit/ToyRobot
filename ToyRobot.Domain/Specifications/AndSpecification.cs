namespace ToyRobot.Domain.Specifications
{
    public sealed class AndSpecification<T> : CompositeSpecification<T>
    {
        private readonly ISpecification<T> _leftSpecification;
        private readonly ISpecification<T> _rightSpecification;

        public AndSpecification(ISpecification<T> leftSpecification, ISpecification<T> rightSpecification)
        {
            _leftSpecification = leftSpecification;
            _rightSpecification = rightSpecification;
        }

        public override bool IsSatisfiedBy(T category)
        {
            var isSatisfied = _leftSpecification.IsSatisfiedBy(category) && _rightSpecification.IsSatisfiedBy(category);

            ExceptionMessages.AddRange(_leftSpecification.ExceptionMessages);

            ExceptionMessages.AddRange(_rightSpecification.ExceptionMessages);

            return isSatisfied;
        }
    }
}
