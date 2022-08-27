using ToyRobot.Domain.Models;

namespace ToyRobot.Domain.Specifications
{
    public sealed class PlaceCommandCountSpecification : ISpecification<PlaceCommandSpecification>
    {
        public string ExceptionMessage { get; private set; } = String.Empty;      

        public bool IsSatisfiedBy(PlaceCommandSpecification category)
        {
            if (category.Parameters.Count > 3)
            {
                ExceptionMessage = ($"{category.CommandString} has more than the allowed number of parameters");

                return false;
            }

            return true;
        }
    }
}
