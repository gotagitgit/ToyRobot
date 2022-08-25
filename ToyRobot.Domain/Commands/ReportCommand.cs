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
            _reportService.Report(payload.Table.Robot.Coordinate);

            return payload.Table;
        }
    }
}
