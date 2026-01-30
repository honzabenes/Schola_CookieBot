namespace CookieBot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("program.txt"))
            {
                var parser = new RobotProgramParser(reader);

                World world = parser.ParseInitialWorld();
                var robot = new Robot(world);

                List<CustomAction> definedActions = parser.ParseCustomActions();

                List<CustomAction> program = parser.ParseProgram(definedActions);


                if (parser.Errors.Count > 0)
                {
                    foreach (string error in parser.Errors)
                    {
                        Console.WriteLine(error);
                    }

                    return;
                }



                try
                {
                    RobotProgramExecutor.Run(robot, program);
                }
                catch (RobotOutOfBoundsApplicationException)
                {
                    Console.WriteLine("ROBOT OUT OF BOUNDS");
                    return;
                }
                catch (NoCookiesApplicationException)
                {
                    Console.WriteLine("NO COOKIE");
                    return;
                }


                foreach (Tile tile in robot.World.Tiles)
                {
                    Console.Write(tile.CookiesCount);
                }

                Console.WriteLine(robot.Position);
                Console.WriteLine(robot.CookiesPicked);
            }
        }

    }
}
