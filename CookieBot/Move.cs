namespace CookieBot
{
    public enum Direction
    {
        Left, Right
    }

    internal class Move : IAction
    {
        public Direction Direction { get; init; }

        public Move(Direction direction)
        {
            Direction = direction;
        }

        public void Execute(Robot robot)
        {
            int moveVector = Direction switch
            {
                Direction.Left => -1,
                Direction.Right => 1,
                _ => throw new NotImplementedException(),
            };

            if (Direction == Direction.Left && robot.Position <= 0)
            {
                throw new RobotOutOfBoundsApplicationException();
            }

            if (Direction == Direction.Right && robot.Position >= robot.World.Tiles.Length - 1)
            {
                throw new RobotOutOfBoundsApplicationException();
            }

            robot.Position += moveVector;
        }
    }
}
