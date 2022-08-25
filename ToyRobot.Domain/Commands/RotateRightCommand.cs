using ToyRobot.Domain.Models;

namespace ToyRobot.Domain.Commands
{
    public sealed class RotateRightCommand : RotateBase, ICommand
    {
        public Command Command => Command.Right;        

        public Table Execute(CommandPayload payload)
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
