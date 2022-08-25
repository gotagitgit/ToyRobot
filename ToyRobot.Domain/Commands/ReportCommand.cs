using ToyRobot.Domain.Models;
using ToyRobot.Domain.Services;

namespace ToyRobot.Domain.Commands
{
    public class ReportCommand : ICommand
    {
        private readonly IReportService _reportService;

        public ReportCommand(IReportService reportService)
        {
            _reportService = reportService;
        }

        public Command Command => Command.Report;

        public Table Execute(CommandPayload payload)
        {
            var coordinate = payload.Table.Robot.Coordinate;

            _reportService.Report($"Output: {coordinate.X}, {coordinate.Y}, {coordinate.Direction}");

            return payload.Table;
        }
    }
}
