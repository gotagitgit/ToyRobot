namespace ToyRobot.Domain.Models
{
    public sealed class Table
    {        
        private readonly int _length;
        private readonly int _width;

        public Table(int length, int width) : this(length, width, Robot.Empty(), false)
        {}

        private Table(int length, int width, Robot robot, bool isRobotInPlace)
        {
            _length = length;
            _width = width;
            Robot = robot;
            IsRobotInPlace = isRobotInPlace;
        }

        public Robot Robot { get; }

        public bool IsRobotInPlace { get; }

        public Table WithRobot(Robot robot)
        {         
            return new Table(_length, _width, robot, IsRobotInPlace);
        }

        public Table SetRobotInPlace()
        {
            if (IsRobotInPlace)
                return new Table(_length, _width, Robot, true);

            return this;
        }

        public bool IsRobotFalling(int x, int y)
        {
            var isValidXAxis = x >= 0 && x < _length;

            var isValidYAxis = y >= 0 && y < _width;

            return !isValidXAxis || !isValidYAxis;
        }

        public static Table Default() => new Table(5, 5);
    }
}
