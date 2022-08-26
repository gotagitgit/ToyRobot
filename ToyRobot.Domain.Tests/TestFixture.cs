using Microsoft.Extensions.DependencyInjection;
using ToyRobot.Domain.Services;

namespace ToyRobot.Domain.Tests
{
    public class TestFixture
    {
        public TestFixture()
        {
            var serviceCollection = new ServiceCollection();

            RegisterServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            ToyRobotService = serviceProvider.GetService<IToyRobotService>();
        }

        public IToyRobotService ToyRobotService { get; set; }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IReportService, MockReportService>();

            DiToyRobot.Configure(services);
        }
    }
}
