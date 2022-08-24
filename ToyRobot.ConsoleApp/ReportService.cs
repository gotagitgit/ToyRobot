using ToyRobot.Domain.Services;

namespace ToyRobot.ConsoleApp
{
    internal class ReportService : IReportService
    {
        public void Report(string message)
        {
            Console.WriteLine(message);
        }
    }
}
