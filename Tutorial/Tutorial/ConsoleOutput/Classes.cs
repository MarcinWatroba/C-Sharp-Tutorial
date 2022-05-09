using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial.ConsoleOutput
{
    internal class Classes
    {
        public static void Run()
        {
            TutorialUtilities.StartSection();
            TutorialUtilities.WriteTitle(@"Open the 'Classes' script file in the 'Tutorials' folder:");
            TutorialUtilities.WriteTitle(@"For each method, look at the method itself and also on the classes it uses, remember you can use CTRL+LMB to automatically find them");
            TutorialUtilities.WaitForKey();
            TutorialUtilities.CloseSection();

            bool run = true;
            while (run)
                run = SectionMenu();
        }

        public static bool SectionMenu()
        {
            Console.WriteLine("Which option would you like to run? (input option number)");
            Console.WriteLine("0: Exit");
            Console.WriteLine("1: All");
            Console.WriteLine("2: Static Classes");
            Console.WriteLine("3: Non-Static Classes");
            Console.WriteLine("4: Inheritance");
            Console.WriteLine("5: Company Example");
            Console.WriteLine("6: References And Values");
            Console.WriteLine("7: Practical Examples");


            bool validInput;
            do
            {
                string? option = Console.ReadLine();
                Console.WriteLine();
                validInput = true;
                switch (option)
                {
                    case "0": return false;
                    case "1": RunAllSections(); break;
                    case "2": StaticClasses(); break;
                    case "3": NonStaticClasses(); break;
                    case "4": Inheritance(); break;
                    case "5": CompanyExample(new WorkingPerson()
                        {
                            FirstName = "Bob",
                            LastName = "The Builder",
                            Age = 35,
                            JobName = "Builder",
                            Salary = 300000,
                            WorkingTool =  // Since this property is also an object of another class, we can initialise properties and variables of that object by nesting it like this
                            {
                                Name = "Hammer",
                                Price = 3.99
                            }
                        }); break;
                    case "6": ReferencesAndValues(); break;
                    case "7": PracticalExamples(); break;
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

        public static void RunAllSections(bool outputMessage = false)
        {
            if (outputMessage)
            {
                TutorialUtilities.StartSection();
                TutorialUtilities.WriteTitle(@"Open the 'Methods' script file in the 'Tutorials' folder:");
                TutorialUtilities.WaitForKey();
                TutorialUtilities.CloseSection();
            }

            StaticClasses();
            NonStaticClasses();
            WorkingPerson bob = Inheritance();
            CompanyExample(bob);
            Structs();
            ReferencesAndValues();
            PracticalExamples();
        }

        private static void StaticClasses()
        {
            // Classes can be static, in this case you use class name to call methods on it, e.g:
            TutorialUtilities.StartSection();
            TutorialUtilities.WriteTitle(@"Look at the 'StaticClasses' method, here you can learn about static classes, for more information also go to the actual classes and look at their structure and notes within them");
            TutorialUtilities.WriteCodeResult(@"Calculator's 'Multiply' and 'Divide' methods call 'Message' method so expect some logs to the console");
            TutorialUtilities.WaitForKey();

            double result = Calculator.Multiply(2, 2);
            Calculator.OutputMessage = false;
            result = Calculator.Multiply(2, 2);
            result = Calculator.Divide(4, 2);

            TutorialUtilities.WriteCodeResult(@"Data from StaticHuman.GetDetails(): " + StaticHuman.GetDetails());

            StaticHuman.FirstName = "Bob";
            StaticHuman.LastName = "Lazar";
            StaticHuman.Age = 55;

            TutorialUtilities.WriteCodeResult(@"Data from StaticHuman.GetDetails() after modifying its properties: " + StaticHuman.GetDetails());

            StaticHuman.FirstName = "Dave";
            StaticHuman._nationality = "Polish";

            TutorialUtilities.WriteCodeResult(@"Data from StaticHuman.GetDetails() after modifying its properties again: " + StaticHuman.GetDetails());

            TutorialUtilities.WaitForKey();
            TutorialUtilities.CloseSection();
        }

        private static void NonStaticClasses()
        {

            TutorialUtilities.StartSection();
            TutorialUtilities.WriteTitle(@"Look at the 'NonStaticClasses' method, here you can learn about static classes, for more information also go to the actual classes and look at their structure and notes within them");
            TutorialUtilities.WaitForKey();

            // Classes can be non static, in this case you need to instantiate them before running their non-static methods
            // Instantiation is done through constructor, when instatiating you can pass arguments to constructor if it has any parameters,
            // you can also do what's shown below to initialise member variable values, as long as their access modifier allows you to access them
            TutorialUtilities.WriteTitle(@"First we're creating three objects of 'Person' class - ben, dave and alice");
            TutorialUtilities.WaitForKey();

            Person ben = new()
            {
                FirstName = "Ben",
                LastName = "King",
                Age = 24,
                _nationality = "English"
            };

            Person dave = new()
            {
                FirstName = "Dave",
                LastName = "Knight"
            };

            Person alice = new("Alice", "Pink", 40);

            TutorialUtilities.WriteTitle(@"Once objects are created we have access to any of their public fields, variables, and methods as seen below");
            TutorialUtilities.WriteCodeResult(@"Data from Person properties: " + $"{ben.FirstName} {ben.LastName} of age {ben.Age}");
            TutorialUtilities.WriteCodeResult(@"Data from Person static parameter 'Species': " + Person.Species);
            TutorialUtilities.WriteCodeResult(@"Running speak method: ");
            Person.Speak();

            TutorialUtilities.WaitForKey();
            
            TutorialUtilities.WriteTitle("As you can see below each Peson object stores its own individual data\n");

            TutorialUtilities.WriteTitle(@"Ben details: ");
            Dictionary<string, string> details = ben.GetAllDetails();
            foreach (KeyValuePair<string, string> detail in details)
                TutorialUtilities.WriteCodeResult($"{detail.Key}: {detail.Value}");

            TutorialUtilities.WriteTitle(@"Dave details: ");
            details = dave.GetAllDetails();
            foreach (KeyValuePair<string, string> detail in details)
                TutorialUtilities.WriteCodeResult($"{detail.Key}: {detail.Value}");

            TutorialUtilities.WriteTitle(@"Alice details: ");
            details = alice.GetAllDetails();
            foreach (KeyValuePair<string, string> detail in details)
                TutorialUtilities.WriteCodeResult($"{detail.Key}: {detail.Value}");

            TutorialUtilities.WaitForKey();
            TutorialUtilities.CloseSection();
        }

        private static WorkingPerson Inheritance()
        {
            TutorialUtilities.StartSection();
            TutorialUtilities.WriteTitle(@"Look at the 'Inheritance' method, here you can learn about parent and child classes, for more information also go to the actual classes and look at their structure and notes within them");
            TutorialUtilities.WaitForKey();

            TutorialUtilities.WriteTitle(@"First we're creating object of WorkingPerson class - ben, note how you can initialise properties of the parent class through it. You can also see how we can initialise object type properties through it");
            TutorialUtilities.WaitForKey();

            // Note that since WorkingPerson is a child class of Person it has both its own properties as well as parent class properties
            WorkingPerson bob = new()
            {
                FirstName = "Bob",
                LastName = "The Builder",
                Age = 35,
                JobName = "Builder",
                Salary = 300000,
                WorkingTool =  // Since this property is also an object of another class, we can initialise properties and variables of that object by nesting it like this
                {
                    Name = "Hammer",
                    Price = 3.99
                }
            };

            TutorialUtilities.WriteTitle("Then we're calling parent and child methods on the 'bob' object, we've got access to both, expect some console logs out of these called methods");
            TutorialUtilities.WaitForKey();
            // We can call both parent methods and child methods on this bob object (instance)
            bob.Introduce();
            bob.WorkingPersonSpeak();


            TutorialUtilities.WriteTitle("Finally we're calling the overridden GetAllDetails method:");
            // See how this is calling the 'override' child method and returns worker data too
            Dictionary<string, string> details = bob.GetAllDetails();
            foreach (KeyValuePair<string, string> detail in details)
                TutorialUtilities.WriteCodeResult($"{detail.Key}: {detail.Value}");

            TutorialUtilities.WaitForKey();
            TutorialUtilities.CloseSection();

            return bob;
        }

        private static void CompanyExample(WorkingPerson employee)
        {
            TutorialUtilities.StartSection();
            TutorialUtilities.WriteTitle(@"Look at the 'CompanyExample' method, here you can learn more about object initialisation and relations, for more information also go to the actual classes and look at their structure and notes within them");
            TutorialUtilities.WaitForKey();

            Company buildersCompany = new()
            {
                CompanyName = "Builders Inc.",
                FoundedYear = 1967,
                Employees =
                {
                    { employee },
                    { new()
                        {
                            FirstName = "Garry",
                            LastName = "Smith",
                            Age = 24,
                            JobName = "Forklift driver",
                            Salary = 20000,
                            WorkingTool =
                            {
                                Name = "Forklift",
                                Price = 30000.00
                            }
                        }
                    }
                }
            };

            TutorialUtilities.WriteTitle("Classes can have class type parameters and variables, they can be nested with no* limits:");
            // We can do this to retrieve properties, methods, variables of objects defined in the class,
            // This can be nested with no limits, if another class has another object and another and so on
            TutorialUtilities.WriteCodeResult("Getting tool name through company object: " + buildersCompany.Employees[0].WorkingTool.Name);
            buildersCompany.CompanyListEmployeers();

            TutorialUtilities.WaitForKey();
            TutorialUtilities.CloseSection();
        }

        private static void Structs()
        {
            TutorialUtilities.StartSection();
            TutorialUtilities.WriteTitle(@"Look at the 'Structs' method, here you can learn about structs, for more information also go to the actual structs and look at their structure and notes within them");
            TutorialUtilities.WaitForKey();
            TutorialUtilities.CloseSection();

            // Structs are very similar to classes, in fact they can look exactly like classes but there's some internal differences between them
            // Structs are typically used to create a new 'datatype' they usually don't have a lot of methods and logic in them:
            Coords coords = new()
            {
                X = 123,
                Y = 111
            };

            Date date = new(12, 3, 2022);
        }

        private static void ReferencesAndValues()
        {
            TutorialUtilities.StartSection();
            TutorialUtilities.WriteTitle(@"Look at the 'ReferencesAndValues' method, here you can learn about reference and value types, read through method's comments before continuing");
            TutorialUtilities.WaitForKey();
            // Variables can be passed or assigned by value or reference


            TutorialUtilities.WriteTitle(@"Results of value types:");
            // Value types like struct, int, string, double etc. are passed by value, so only their value is passed as an argument or provided when assigning one variable to another
            // Therefore if you modify one variable, then the other one is not modified
            int number = 5;
            PassValue(number);  // This method increments parameter by 5
            TutorialUtilities.WriteCodeResult($"number: {number}"); // You can see that value of the variable in this calling method didn't change, since it was passed by value
            
            Coords pos = new()
            {
                X = 5,
                Y = 5
            };

            PassValue(pos); // This method increments X value by 5
            TutorialUtilities.WriteCodeResult($"pos x: {pos.X}"); // You can see that value of the variable in this calling method didn't change, since it was passed by value
            TutorialUtilities.WaitForKey();

            TutorialUtilities.WriteTitle(@"Results of reference types:");
            // Reference types like class objects are passed by reference, so only a reference to their location in memory is passed as an argument or provided when
            // one object is assigned to another one
            // This means that if you modify parameter or field of one object that's been assigned to other variables, all other variables holding this object will also change
            Person steve = new("Steve", "Jobs", 5);
            PassReference(steve); // This method increments parameter age by 5
            TutorialUtilities.WriteCodeResult("steve age: " + steve.Age); // You can see that value of this object variable did change since it was passed by reference


            Person steve2 = steve;  // Assignment is also done by reference in case of objects
            steve2.Age += 10;    // This will update age in both steve, and steve2 object variables
            TutorialUtilities.WriteCodeResult("steve age: " + steve.Age);

            Person steve3 = new();  // To avoid this you need to create a new() object, this will have a new reference so it will be separate
            steve3.Age = steve.Age; // Since Age is of int type it will be assigned by value
            steve.Age += 10; // Updating steve object age will update steve2 object age but won't update steve3 since steve3 was created as new()
            TutorialUtilities.WriteCodeResult("steve 2 age: " + steve2.Age);
            TutorialUtilities.WriteCodeResult("steve 3 age: " + steve3.Age);
            TutorialUtilities.WaitForKey();
            TutorialUtilities.CloseSection();
        }

        private static void PracticalExamples()
        {
            TutorialUtilities.StartSection();
            TutorialUtilities.WriteTitle(@"Finally look at 'PracticalExamples' method, here you will find practical examples");
            TutorialUtilities.WaitForKey();

            // Note that almost everything in C# is either a class or a struct:
            String text = new("string is also a class");
            string text2 = text; // Can see they're the same

            // There are structs called Int32, Double, etc. that are used by value types like int, double

            // This is a class too, it uses properties just like the Person example, which are public and assignable in the same way
            // It isn't static so we instantiate objects out of it
            HttpRequestMessage message = new()
            {
                Method = HttpMethod.Get,                            // Public property of HttpMethod (class) type
                RequestUri = new Uri("https://www.google.com/"),    // Public property of Uri (class) type
                Headers =                                           // Public property of HttpRequestMessage (class) type
                {
                    {
                        "cache-control", "no-cache"
                    },
                    {
                        "origin", "https://www.google.com/"
                    }
                }
            };

            // This is also a class, but it has no public constructor, however, HttpRequestMessage has a property that allows you to pass in headers as seen above
            HttpRequestHeaders headers;

            HttpClient client = new(); // This is another class, it isn't static, so just like in the case of Person class we can instantiate objects out of it
            int version = client.DefaultRequestVersion.Minor; // It has properties and member variables too like our Person class
            HttpResponseMessage response = client.Send(message); // Just like person class it also has methods that can be called, they can also return things

            TutorialUtilities.WriteCodeResult("Response status from Google is success: " + response.IsSuccessStatusCode); // Just like person class you can get information out of the object
            TutorialUtilities.WaitForKey();
            TutorialUtilities.CloseSection();
        }

        private static void PassValue(int value)
        {
            value += 10;
        }

        private static void PassValue(Coords coords)
        {
            coords.X += 10;
        }

        private static void PassReference(Person someone)
        {
            someone.Age += 10;
        }
    }

    public struct Coords
    {
        public double X;
        public double Y;
    }

    public struct Date
    {
        public uint Day { get; set; }
        public uint Month { get; set; }
        public uint Year { get; set; }

        public Date(uint day, uint month, uint year)
        {
            Day = day;
            Month = month;
            Year = year;
        }

        public string GetWholeDate()
        {
            return $"{Day}/{Month}/{Year}";
        }
    }

    /// <summary>
    /// Static class is a class that cannot be instantiated, therefore all its methods and member variables need to be static too
    /// Because they cannot be instantiated, they can't have multiple implementations across program
    /// Therefore if variable is modified it is globally modified 
    /// </summary>
    public static class Calculator
    {
        // Member variables are just variables stored in a class, fields is another name for these variables
        // There can also be proprties, which act very similarly to fields, in most cases you won't spot a difference when using them
        // Fields, properties and methods can be either private, protected, or public in a class:
        // private means that it's available only within the class scope
        // protected means that it's available within the class and any children classes - more on inheritance later
        // public means that it's available to the whole program as long as it uses the same namespace

        // This is a field, it is a variable like any other, but it is accessible only to the Calculator class as it's within its scope and it's private
        private const string CALCULATOR_NAME = "Robo Calculator";

        // This is a property, it can be used almost exactly like a field,
        // the advantage is that you can set individually what access you give for getting it and setting it,
        // by default access level for each, 'get', and 'set', is equal to the access modifier of the property itself,
        // Another advantage is that you can write a method for both 'get' and 'set' - e.g. 'public string Text { get { Console.Write("get") }; {set { Console.Write("set"); }; }'
        // The disadvantage of these is that you cannot use them as 'ref' (not covered in the tutorial) or 'out' parameter
        // There are few other differences but this does not matter here
        public static bool OutputMessage { private get; set; }



        // All classes can have a static constructor, however, it cannot have an access modifier, this is because it is not used by programmer
        // It is called automatically by program before the class is used in any way
        static Calculator()
        {
            OutputMessage = true;
        }

        // Since this is a private method it cannot be called from outside of this class
        private static void Message(string calculation)
        {
            // Classes can also have objects of other classes within them, Random is a built-in class that allows to get random values
            Random randomiser = new();
            // Will get a random number between 0 an 100
            int randomInt = randomiser.Next(0, 100);

            // OutputMessage is set to private get - so it can only be read within this class
            if (OutputMessage)
            {
                TutorialUtilities.WriteCodeResult($"{CALCULATOR_NAME} is calculating: {calculation}");
            }
            else if (randomInt == 1)
            {
                TutorialUtilities.WriteCodeResult($"{CALCULATOR_NAME} wants to output a message");

            }
        }

        // Since this is a public method it can be referenced anywhere as long as the same namespace is used
        // As you can see it calls the private 'Message' method, so even though private methods cannot be accessed directly, they can be ran indirectly
        public static double Multiply(double num1, double num2)
        {
            Message($"{num1} * {num2}");
            return num1 * num2;
        }

        public static double Divide(double num1, double num2)
        {
            Message($"{num1} / {num2}");
            return num1 / num2;
        }
    }

    /// <summary>
    /// If we have static class "Human" it can hold data only about one person across the runtime since we can't create objects
    /// </summary>
    public static class StaticHuman
    {
        public static string FirstName { get; set; } = "N/A";
        public static string LastName { get; set; } = "N/A";
        public static int Age { get; set; } = -1;

        public static string _nationality = "N/A";

        public static string GetDetails()
        {
            return $"{FirstName} {LastName}, {Age}, {_nationality}";
        }
    }

    /// <summary>
    /// Non static classes can be instantiated, so member variables and methods can be static too
    /// Because they can be instantiated, we can create objects, each object can have different values for its variables
    /// If we have non-static class "Person" we can create objects of this class, so each "Person" object can store different information
    /// So we can have Person bob, Person rob, Person dave
    /// </summary>
    public class Person
    {
        // Any member variables and properties can be initialised outside of constructor, this will be initialised before static constructor is ran
        public string FirstName { get; set; } = "N/A";
        public string LastName { get; set; } = "N/A";
        public int Age { get; set; } = -1;

        public string _nationality = "N/A";

        // protected variable or method means that it is only accessible to this class and any children classes
        protected uint IDNumber { get; private set; }

        // There can be static methods, fields and parameters in classes, this means these cannot be different per object
        // in fact you cannot even retrieve them through an object, you need to use class name to retrieve them as in static classes case
        // Within the class itself they can be accessed like any other variable, but keep in mind that modifying them in one instance, affects all since there's no copy per instance
        // Not including set; in this case means that this is a constant
        public static string Species { get; } = "Human";
        public static uint Population { get; private set; } = 0;

        //Non static classes need to have a constructor, if you won't add any constructor into a non-static class, C# will automatically add one in under the hood
        public Person()
        {
            IDNumber = ++Population;
        }

        //There can be multiple constructors just as there can be multiple methods of the same name, as long as parameters are different
        public Person(string firstName, string lastName, int age = -1)
        {
            IDNumber = ++Population;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        // This method is not static so it is called on an object (instance of the class)
        // It is also 'virtual' which means that it can be overridden by a child class by creating a method with exact same declaration in it (return type, name, params)
        public virtual Dictionary<string, string> GetAllDetails()
        {
            // This is a local variable so it cannot be used outside of this method
            string ageOutput = Age < 0 ? "N/A" : Age.ToString();

            // Since dictionary is sort of a List of KeyValuePairs class objects, similarly to how you can initialise variables of the class without a constructor
            // Each of the below initialises a new KeyValuePair object held in the dictionary
            return new()
            {
                { "First Name", FirstName },
                { "Last Name", LastName },
                { "Age", ageOutput },
                { "Nationality", _nationality },
                { "Species", Species },
            };
        }

        public void Introduce()
        {
            TutorialUtilities.WriteCodeResult($"Hello I am {FirstName} {LastName}, nice to meet you");
        }


        // There can be static methods too just like static variables and properties.
        // Again, this means that this method is called on class name, not object,
        // Static method cannot use any non-static member variables
        public static void Speak()
        {
            TutorialUtilities.WriteCodeResult($"Hello, my species is {Species}");
        }
    }

    /// <summary>
    /// You define a child class by adding its parent class after colon
    /// Child class has access to all public and protected member variables and methods of parent class
    /// They can be used as if they belong to this class, basically when you inherit all parent class variables and methods are copied over to this class
    /// So that they can be used here in the same way
    /// </summary>
    public class WorkingPerson : Person
    {
        public string JobName { get; set; } = "N/A";
        public int Salary { get; set; } = -1;
        public Tool WorkingTool { get; set; } = new();

        // This method uses 'override' keyword so it overrides parent virtual class
        public override Dictionary<string, string> GetAllDetails()
        {
            // We can call parent version of this method by using base. in front of the method name
            Dictionary<string, string> personDetails = base.GetAllDetails();

            personDetails.Add("Job name", JobName);
            personDetails.Add("Salary", Salary == -1 ? "N/A" : Salary.ToString());

            return personDetails;
        }

        // Note this method is not static like the Speak() method of the parent class
        // This is because if it was static we wouldn't have access to non-static member variables such as FirstName or JobName
        public void WorkingPersonSpeak()
        {
            // Since this is a child class that inherits everything public and protected of the parent class
            // We can use these accessible methods and variables as if they were belonging to this child class
            // We can also access properties of Employer object property like we do normally with objects
            Speak();
            TutorialUtilities.WriteCodeResult($"My name is {FirstName}, my id is {IDNumber}, and I'm a {JobName} using my trusty {WorkingTool.Name}");
        }

    }

    public class Company
    {
        public string CompanyName { get; set; } = "N/A";
        public uint FoundedYear { get; set; }

        // Classes can also have objects of other classes as member variables and properties
        public List<WorkingPerson> Employees { get; set; } = new();


        public void OutputCompanyCatchphrase()
        {
            TutorialUtilities.WriteCodeResult("60 hour weeks just with us");
        }

        public void CompanyListEmployeers()
        {
            TutorialUtilities.WriteCodeResult($"{CompanyName} company, founded in {FoundedYear}, has following employees:");
            Employees.ForEach(employee => TutorialUtilities.WriteCodeResult($"{employee.FirstName} {employee.LastName} - role: {employee.JobName}, salary: {employee.Salary}"));
        }
    }

    public class Tool
    {
        public string Name { get; set; } = "N/A";
        public double Price { get; set; }
    }
}
