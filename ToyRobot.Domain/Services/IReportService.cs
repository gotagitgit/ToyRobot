using ToyRobot.Domain.Models;

namespace ToyRobot.Domain.Services
{
    public interface IReportService
    {
        void Report(Coordinate coordinate);
    }
}
