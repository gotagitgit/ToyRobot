using ToyRobot.Domain.Models;

namespace ToyRobot.Domain.Specifications.PlaceCommandSpecifications
{
    public sealed class ParameterCountSpecification : CompositeSpecification<PlaceCommandSpecification>
    {
        public override bool IsSatisfiedBy(PlaceCommandSpecification category)
        {
            if (category.Parameters.Count > 3)
            {
                var exceptionMessage = ($"{category.CommandString} has more than the allowed number of parameters");

                ExceptionMessages.Add(exceptionMessage);

                return false;
            }

            return true;
        }
    }
}
