namespace ToyRobot.Domain.Models
{
    public class CommandPayload
    {
        public CommandPayload(Table table, Command command)
        {
            Table = table;
            Command = command;
        }

        public Table Table { get; }
        public Command Command { get; }
    }
}
