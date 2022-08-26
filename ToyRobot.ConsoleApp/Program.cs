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

            //var commands = GetCommands();

            var commands = new string[]
            {                
                "PLACE 0,0,EAST",
                "MOVE",
                "MOVE",
                "REPORT"
            };

            ExecuteCommands(commands, serviceCollection);
        }

        private static string[] GetCommands()
        {
            Console.Write("Commands file path : ");
            var filePath = Console.ReadLine();

            return FileService.GetCommands(filePath).ToArray();
        }

        private static void ExecuteCommands(string[] commands, IServiceCollection serviceCollection)
        {    
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var toyRobotService = serviceProvider.GetService<IToyRobotService>();

            _ = toyRobotService?.ProcessCommand(commands);
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IReportService, ReportService>();

            DiToyRobot.Configure(services);
        }
    }
}