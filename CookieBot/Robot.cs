namespace CookieBot
{
    internal class Robot
    {
        public World World { get; init; }
        public int Position = 0;
        public int CookiesCount = 0;

        public Robot(World world)
        {
            World = world;
        }
    }
}
