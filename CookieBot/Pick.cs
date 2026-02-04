namespace CookieBot
{
    internal class Pick : IAction
    {
        public void Execute(Robot robot)
        {
            Tile currentTile = robot.World.Tiles[robot.Position];

            if (currentTile.CookiesCount > 0)
            {
                robot.CookiesCount++;
                currentTile.CookiesCount--;
            }

            else
            {
                throw new NoCookiesApplicationException();
            }
        }
    }
}
