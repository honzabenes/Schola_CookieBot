namespace CookieBot
{
    internal class CustomAction : IAction
    {
        public string Name { get; init; }
        private IAction[] CommandSequence;

        public CustomAction(string name, IAction[] commandSequence)
        {
            Name = name;
            CommandSequence = commandSequence;
        }


        public void Execute(Robot robot)
        {
            foreach (IAction action in CommandSequence)
            {
                action.Execute(robot);
            }
        }
    }
}
