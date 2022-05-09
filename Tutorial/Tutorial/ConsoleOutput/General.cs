

namespace Tutorial.ConsoleOutput
{
    public class General
    {
        public static void Run()
        {
            TutorialUtilities.StartSection();
            TutorialUtilities.WriteTitle(@"Open the 'General' script file in the 'Tutorials' folder:");
            TutorialUtilities.WaitForKey();
            TutorialUtilities.CloseSection();

            TutorialUtilities.StartSection();
            TutorialUtilities.WriteTitle(@"Take a look at the comments and example variables in the 'General' class");
            TutorialUtilities.WriteTitle(@"Namespaces act as scopes");
            TutorialUtilities.WriteCodeResult(@"example1 variable: Since we're already in the 'Tutorial.Tutorials' namespace, we just need to add in 'Example.' in front");
            TutorialUtilities.WriteCodeResult(@"example2 variable: Since this is a completely different namespace we need to write all its parts in front");
            TutorialUtilities.WriteCodeResult(@"example3 variable: This will be coming from the 'Namespace.Example2' as we specified that we're 'using' it at the top (line 1) of this script file.");
            TutorialUtilities.WaitForKey();
            TutorialUtilities.CloseSection();
        }

        public static string NamespaceExamle = "I am within Tutorial.ConsoleOutput namespace";
    }
}
