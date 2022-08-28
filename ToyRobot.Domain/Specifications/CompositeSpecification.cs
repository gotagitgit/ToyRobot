namespace ToyRobot.Domain.Specifications
{
    public abstract class CompositeSpecification<T> : ISpecification<T>
    {
        private string _exceptionMessage = string.Empty;

        public string ExceptionMessage => _exceptionMessage;

        public abstract bool IsSatisfiedBy(T category);

        public ISpecification<T> And(ISpecification<T> specification)
        {
            return new AndSpecification<T>(this, specification);
        }

        public ISpecification<T> Or(ISpecification<T> specification)
        {
            return new OrSpecification<T>(this, specification);
        }

        protected void SetExceptionMessage(string exceptonMessage) => _exceptionMessage = exceptonMessage;
    }
}
