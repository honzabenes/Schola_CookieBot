namespace CookieBot
{
    internal static class RobotProgramExecutor
    {
        public static void Run(Robot robot, List<CustomAction> program)
        {
            foreach (CustomAction action in program)
            {
                action.Execute(robot);
            }
        }
    }
}
