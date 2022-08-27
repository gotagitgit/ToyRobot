using ToyRobot.Domain.Models;
using ToyRobot.Domain.Services;

namespace ToyRobot.Domain.Tests
{
    public class MockReportService : IMockReportService
    {
        public Coordinate? Coordinate { get; private set; }

        public void Report(Coordinate coordinate)
        {
            Coordinate = coordinate;
        }
    }

    public interface IMockReportService : IReportService
    {
        Coordinate? Coordinate { get; }
    }
}
