using ToyRobot.Domain.Services;
using Xunit;

namespace ToyRobot.Domain.Tests
{
    public class TestBase : IClassFixture<TestFixture>
    {
        public TestBase(TestFixture fixture)
        {
            ToyRobotService = fixture.ToyRobotService;
        }

        protected IToyRobotService ToyRobotService { get; }
    }
}
