using Namespace.Example2;

// namespaces act as scopes, anything that's within a namespace can only be accessed in that namespace, if you'd like to use something from within this namespace externally,
// you'll either need to add using *name of the scope* as can be seen at the top here, or add scope name inline in code, in front of something that you want to access
// This makes sure that if two or more classes/methods/variables have the same name, you can still identify the correct one using the namespace
namespace Tutorial.Tutorials
{
    public class General
    {
        // Since we're already in the 'Tutorial.Tutorials' namespace, we just need to add in 'Example'
        string example1 = Example.NameSpaceExample.Example;

        // Since this is a completely different namespace we need to write all its parts
        string example2 = Namespace.Example.NameSpaceExample.Example;
        
        // This will be coming from the 'Namespace.Example2' as we specified that we're 'using' it at the top of this script file.
        string example3 = NameSpaceExample.Example;

    }
}

namespace Tutorial.Tutorials.Example
{
    public class NameSpaceExample
    {
        public static string Example = "I am within Tutorial.Tutorials.Example namespace";
    }
}

namespace Namespace.Example
{
    public class NameSpaceExample
    {
        public static string Example = "I am within Namespace.Example namespace";
    }
}

namespace Namespace.Example2
{
    public class NameSpaceExample
    {
        public static string Example = "I am within Namespace.Example namespace";
    }
}