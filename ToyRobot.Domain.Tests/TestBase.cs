using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using ToyRobot.Domain.Models;
using ToyRobot.Domain.Services;
using Xunit;

namespace ToyRobot.Domain.Tests
{
    public class TestBase : IClassFixture<TestFixture>
    {
        public TestBase(TestFixture fixture)
        {
            var services = fixture.Services;

            ToyRobotService = services.GetRequiredService<IToyRobotService>();

            ReportService = (IMockReportService)services.GetRequiredService<IReportService>();
        }

        protected IToyRobotService ToyRobotService { get; }

        protected IMockReportService ReportService { get; }

        protected void ShouldMatchCoordinate(int x, int y, Direction direction)
        {
            var coordinate = new Coordinate(x, y, direction);

            ReportService.Coordinate.Should().BeEquivalentTo(coordinate);
        }
    }
}
