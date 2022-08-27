namespace ToyRobot.Domain.Commands
{
    public interface IPrimaryCommand : ICommand
    {
        bool IsPrimaryCommand { get; }
    }
}
