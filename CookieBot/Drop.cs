namespace CookieBot
{
    internal class Drop : IAction
    {
        public void Execute(Robot robot)
        {
            if (robot.CookiesCount == 0)
            {
                throw new NoCookiesApplicationException();
            }

            robot.CookiesCount -= 1;
            robot.World.Tiles[robot.Position].CookiesCount += 1;
        }
    }
}
