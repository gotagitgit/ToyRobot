using ToyRobot.Domain.Models;
using ToyRobot.Domain.Services;

namespace ToyRobot.Domain.Tests
{
    public class MockReportService : IReportService
    {
        public void Report(Coordinate coordinate)
        {
            // Do nothing
        }
    }
}
