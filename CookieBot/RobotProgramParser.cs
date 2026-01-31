namespace CookieBot
{
    internal class RobotProgramParser
    {
        private TextReader Reader;
        private int CurrentLine = 0;
        public List<string> Errors = new List<string>();

        public RobotProgramParser(TextReader reader)
        {
            Reader = reader; 
        }


        public World ParseInitialWorld()
        {
            string line = ReadLine();

            var tiles = new Tile[line.Length];

            for (int i = 0; i < line.Length; i++)
            {
                char ch = line[i];
                tiles[i] = new Tile(ch - '0');
            }

            return new World(tiles);
        }


        public List<CustomAction> ParseCustomActions()
        {
            var actions = new List<CustomAction>();

            string line;

            while ((line = ReadLine()).Split()[0] == "ACTION")
            {
                var commandSequence = new List<IAction>();

                string name = line.Split()[1];

                while ((line = ReadLine()) != "END")
                {
                    string[] command = line.Split();
                    string commandName = command[0];

                    switch (commandName)
                    {
                        case "pick":
                            commandSequence.Add(new Pick());
                            break;
                        case "left":
                            HandleCommandMove(Direction.Left, command, commandSequence);
                            break;
                        case "right":
                            HandleCommandMove(Direction.Right, command, commandSequence);
                            break;
                        default:
                            Errors.Add($"{CurrentLine}: INVALID COMMAND {commandName}");
                            break;
                    }
                }

                actions.Add(new CustomAction(name, commandSequence.ToArray()));
            }

            return actions;
        }


        public List<CustomAction> ParseProgram(List<CustomAction> definedActions)
        {
            var program = new List<CustomAction>();

            string name;

            while (((name = ReadLine()) is not null))
            {
                bool isDefined = false;

                foreach (var action in definedActions)
                {
                    if (action.Name == name)
                    {
                        isDefined = true;
                        program.Add(action);
                        break; 
                    }
                }

                if (!isDefined)
                {
                    Errors.Add($"{CurrentLine}: INVALID ACTION {name}");
                }
            }

            return program;
        }


        private void HandleCommandMove(Direction direction, string[] command, List<IAction> commandSequence)
        {
            string commandName = command[0];
            string commandArgument = command[1];

            if (int.TryParse(commandArgument, out int count))
            {
                for (int i = 0; i < count; i++)
                {
                    commandSequence.Add(new Move(direction));
                }
            }
            else
            {
                Errors.Add($"{CurrentLine}: INVALID ARGUMENT {commandArgument} FOR {commandName}");
            }
        }


        private string? ReadLine()
        {
            CurrentLine++;
            return Reader.ReadLine();
        }
    }
}
