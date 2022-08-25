using ToyRobot.Domain.Models;
using ToyRobot.Domain.Services;

namespace ToyRobot.ConsoleApp
{
    internal class ReportService : IReportService
    {
        public void Report(Coordinate coordinate)
        {
            Console.WriteLine($"Output: {coordinate.X}, {coordinate.Y}, {coordinate.Direction}");
        }
    }
}
