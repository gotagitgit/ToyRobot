using ToyRobot.Domain.Models;
using ToyRobot.Domain.Services;

namespace ToyRobot.Domain.Commands
{
    public class ReportCommandHandler : ICommandHandler
    {
        private readonly IReportService _reportService;

        public ReportCommandHandler(IReportService reportService)
        {
            _reportService = reportService;
        }

        public Command Command => Command.Report;

        public Table Handle(CommandPayload payload)
        {
            var coordinate = payload.Table.Robot.Coordinate;

            _reportService.Report($"Output: {coordinate.X}, {coordinate.Y}, {coordinate.Direction}");

            return payload.Table;
        }
    }
}
