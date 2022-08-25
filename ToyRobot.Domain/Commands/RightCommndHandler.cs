using ToyRobot.Domain.Models;

namespace ToyRobot.Domain.Commands
{
    public sealed class RightCommndHandler : RotateCommandBase, ICommandHandler
    {
        public Command Command => Command.Right;        

        public Table Handle(CommandPayload payload)
        {
            return Rotate(payload.Table);
        }

        protected override int ComputeRotation(Direction direction)
        {
            var rotateValue = (int)direction - 90;

            if (rotateValue < 0)
                rotateValue = 270;

            return rotateValue;
        }
    }
}
