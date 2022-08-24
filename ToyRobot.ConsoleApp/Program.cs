using Microsoft.Extensions.DependencyInjection;
using ToyRobot.Domain;
using ToyRobot.Domain.Services;

namespace ToyRobot.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();

            RegisterServices(serviceCollection);

            DiToyRobot.Configure(serviceCollection);

            var commands = new string[]
            {
                "PLACE 0,0,WEST",
                "MOVE",
                "MOVE",
                "REPORT"
            };

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var toyRobotService = serviceProvider.GetService<IToyRobotService>();

            toyRobotService.ProcessCommand(commands);

            
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IReportService, ReportService>();
        }
    }
}