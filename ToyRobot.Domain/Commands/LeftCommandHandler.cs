using ToyRobot.Domain.Models;

namespace ToyRobot.Domain.Commands
{
    public sealed class LeftCommandHandler : RotateCommandBase, ICommandHandler
    {
        public Command Command => Command.Left;

        public Table Handle(CommandPayload payload)
        {
            return Rotate(payload.Table);
        }

        protected override int ComputeRotation(Direction direction)
        {
            var rotateValue = (int)direction + 90;

            if (rotateValue >= 360)
                rotateValue = 0;

            return rotateValue;
        }
    }
}
