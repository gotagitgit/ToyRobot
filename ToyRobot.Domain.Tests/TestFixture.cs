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

            Services = serviceCollection.BuildServiceProvider();
        }

        public ServiceProvider Services { get; }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IReportService, MockReportService>();

            DiToyRobot.Configure(services);
        }
    }
}
