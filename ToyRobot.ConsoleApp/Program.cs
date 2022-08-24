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

            DiToyRobot.Configure(serviceCollection);

            var commands = new string[]
            {
                "PLACE 0,0,NORTH",
                "MOVE"
            };

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var toyRobotService = serviceProvider.GetService<IToyRobotService>();

            toyRobotService.ProcessCommand(commands);

            Console.WriteLine("Hello, World!");
        }
    }
}