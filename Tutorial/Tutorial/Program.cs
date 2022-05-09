using Tutorial.Tutorials;

namespace Tutorial
{
    public static class Tutorial
    {
        static void Main()
        {
            Console.WriteLine("static void/int/Task/Task<int> Main() is a special C# method");
            Console.WriteLine("Program always starts through this method if it's located in the startup project (highlighted in bold in VS solution explorer)\n");

            bool run = true;
            while (run)
                run = TutorialMenu();

            return;
            Console.WriteLine("This code will not be run since it's after return");
        }


        
        private static bool TutorialMenu()
        {
            Console.WriteLine("\n================================================================");
            Console.WriteLine("================================================================\n\n");

            Console.WriteLine("All tutorial files can be found in the 'Tutorials' folder");
            Console.WriteLine("When looking for methods and classes you can use CTRL+LMB on their names anywhere in the code to focus on them automatically");
            Console.WriteLine("What would you like to do? (input option number)");
            Console.WriteLine("0: Exit");
            Console.WriteLine("1: Run all tutorials");
            Console.WriteLine("2: Run 'General' tutorial");
            Console.WriteLine("3: Run 'Variables and Lists' tutorial");
            Console.WriteLine("4: Run 'Methods' tutorial");
            Console.WriteLine("5: Run 'Classes' tutorial");

            bool validInput;
            do
            {
                string? option = Console.ReadLine();
                Console.WriteLine();
                validInput = true;
                switch (option)
                {
                    case "0": return false;
                    case "1": RunAllTutorials(); break;
                    case "2": ConsoleOutput.General.Run(); break;
                    case "3": ConsoleOutput.VariablesAndLists.Run(); break;
                    case "4": ConsoleOutput.Methods.Run(); break;
                    case "5": ConsoleOutput.Classes.Run(); break;
                    default:
                        {
                            Console.WriteLine("Invalid option given, try again");
                            validInput = false;
                        }
                        break;
                }

            } while (!validInput);

            return true;
        }

        private static void RunAllTutorials()
        {
            ConsoleOutput.General.Run();
            ConsoleOutput.VariablesAndLists.RunAllSections(true);
            ConsoleOutput.Methods.RunAllSections(true);
            ConsoleOutput.Classes.RunAllSections();
        }
    }

    public static class TutorialUtilities
    {
        private static bool _continued = false;

        public static void OutputToConsole<T>(bool continueOutput, Dictionary<string, T> codeResults, string titleMessage = "")
        {
            if (!_continued)
                StartSection();

            _continued = continueOutput;

            WriteTitle(titleMessage);

            foreach (KeyValuePair<string, T> result in codeResults)
                WriteCodeResult($"{result.Key} {result.Value}");

            WaitForKey();

            if (!continueOutput)
            {
                CloseSection();
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void StartSection()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n================================================================");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void WriteTitle(string titleMessage)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"\n{titleMessage}");
        }

        public static void WriteCodeResult(string codeResult)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(codeResult);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void WaitForKey()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(true);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void CloseSection()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n================================================================\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
