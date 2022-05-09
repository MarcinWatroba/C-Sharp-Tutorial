using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial.ConsoleOutput
{
    public static class Methods
    {
        public static void Run()
        {
            TutorialUtilities.StartSection();
            TutorialUtilities.WriteTitle(@"Open the 'Methods' script file in the 'Tutorials' folder:");
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
            Console.WriteLine("2: Prologue");
            Console.WriteLine("3: No Params Method");
            Console.WriteLine("4: Return Method");
            Console.WriteLine("5: Params Method");
            Console.WriteLine("6: Add Up Method");
            Console.WriteLine("7: Optional Params Method");
            Console.WriteLine("8: Out Params Method");
            Console.WriteLine("9: Lambda Expressions");
            Console.WriteLine("10: Polymorphic Methods");

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
                    case "2": Prologue(); break;
                    case "3": NoParamsMethod(); break;
                    case "4": ReturnMethod(); break;
                    case "5": ParamsMethod("Method ran"); break;
                    case "6": AddUp(2, 3); break;
                    case "7": OptionalParams("The sum is:", 5, 5); break;
                    case "8": OutParams(51, out string uniMessage); break;
                    case "9": LambdaExpressions(); break;
                    case "10": PolymorphicMethods(); break;
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

            Prologue();
            NoParamsMethod();
            string message = ReturnMethod();
            ParamsMethod(message);
            AddUp(2, 3);
            OptionalParams("The sum is:", 5, 5);
            bool passedExam = OutParams(51, out string uniMessage);
            LambdaExpressions();
            PolymorphicMethods();
        }

        private static void Prologue()
        {
            TutorialUtilities.StartSection();
            TutorialUtilities.WriteTitle(@"Methods consist of access modifier (private, protected, public), return type (void - return nothing, int, List<string> etc.), name (can be anything), and 'parameters' (names listed in function's definition, within brackets - 'arguments' are actual values that are assigned to these parameters). They can also use a 'static' keyword");
            TutorialUtilities.WriteTitle(@"For each method, first look at where it's called in the 'RunMethods' method, then look at the method itself");
            TutorialUtilities.WaitForKey();
            TutorialUtilities.CloseSection();
        }

        private static void NoParamsMethod()
        {
            TutorialUtilities.StartSection();
            TutorialUtilities.WriteTitle(@"Some methods don't return anything ('void' for data type) and don't have any parameters (therefore they can't take any arguments) - see 'NoParamsMethod()'");
            TutorialUtilities.WaitForKey();
            TutorialUtilities.CloseSection();
        }

        private static string ReturnMethod()
        {
            TutorialUtilities.StartSection();
            TutorialUtilities.WriteTitle(@"Some methods return something but don't have any parameters (therefore they can't take any parameters) - see 'ReturnMethod()'");
            TutorialUtilities.WriteCodeResult("The 'ReturnMethod()' returns a string containing this value: \"Method ran\"");
            TutorialUtilities.WaitForKey();
            TutorialUtilities.CloseSection();
            return "Method ran";
        }

        private static void ParamsMethod(string text)
        {
            TutorialUtilities.StartSection();
            TutorialUtilities.WriteTitle(@"Some methods don't return anything ('void' for data type) but have parameters to which values (arguments) can be assigned - see 'ParamsMethod()'");
            TutorialUtilities.WriteCodeResult($"The 'ParamsMethod(message)' takes in a string argument that it then outputs into console - it is: \"{text}\"");
            TutorialUtilities.WaitForKey();
            TutorialUtilities.CloseSection();
        }

        private static int AddUp(int number1, int number2)
        {
            TutorialUtilities.StartSection();
            TutorialUtilities.WriteTitle(@"Note - Methods can be passed into other methods as arguments, the outer method will be executed using the return (result) of inner method as its argument");
            TutorialUtilities.WriteTitle(@"Some methods have parameters and return something - see 'AddUp()'");
            TutorialUtilities.WriteCodeResult($"'AddUp(2, 3)' takes in two integers and returns a sum of them: \"{number1 + number2}\"");
            TutorialUtilities.WaitForKey();
            TutorialUtilities.CloseSection();
            return number1 + number2;
        }

        private static void OptionalParams(string message, int num1, int num2 = 0, int num3 = 0)
        {
            TutorialUtilities.StartSection();
            TutorialUtilities.WriteTitle(@"Some methods have optional parameters with default values - see 'OptionalParams()'");
            TutorialUtilities.WriteTitle(@"In this tutorial last param is not passed in so the default value will be used instead");
            TutorialUtilities.WriteCodeResult($"'OptionalParams(\"The sum is:\", 5, 5)' outputs a sum of all int parameters concatenated with the string message: \"{message} {num1 + num2 + num3}\"");
            TutorialUtilities.WaitForKey();
            TutorialUtilities.CloseSection();
        }

        private static bool OutParams(int grade, out string message)
        {
            TutorialUtilities.StartSection();
            bool passedExam = grade > 50;
            message = passedExam ? "Congratulations, you passed" : "Sorry, you failed";
            TutorialUtilities.WriteTitle(@"Some methods have 'out' parameters, these are parameters that will be outputted into passed in variable (basically another return) - see 'OutParams()'");
            TutorialUtilities.WriteCodeResult($"The 'bool OutParams(int grade, out string message)' returns a boolean and outputs a message as the out parameter : return - {passedExam} out - \"{message}\"");
            TutorialUtilities.WaitForKey();
            TutorialUtilities.CloseSection();
            return passedExam;
        }

        private static void LambdaExpressions()
        {
            TutorialUtilities.StartSection();
            TutorialUtilities.WriteTitle(@"Look at the 'LambdaExpressions' method");
            TutorialUtilities.WriteTitle(@"You might have notices var => Console.WriteLine(var) in previous examples, these are lambda expressions, they are inline methods");
            TutorialUtilities.WaitForKey();


            // You might have notices var => Console.WriteLine(var) in previous examples, these are lambda expressions, they are inline methods:
            List<int> numbers = new() { 1, 2, 2, 3, 3, 3 };

            TutorialUtilities.WriteTitle(@"ForEach uses a lambda expression, ForEach provides a parameter which can be named as anything, I named it as number
            - On the left side of the arrow are any params provided; you can find out what method provide what params through documentation
            - On the right side is the function to be executed using the params passed from the left side
            - Remember, since there are params they are just temporary, so modifying them in here will not cause parent object to have updated elements");

            // Here's a lambda expression, ForEach provides a parameter which can be named as anything, I named it as number
            // On the left side of the arrow are any params provided; you can find out what method provide what params through documentation
            // On the right side is the function to be executed using the params passed from the left side
            // Remember, since there are params they are just temporary, so modifying them in here will not cause parent object to have updated elements
            string allNumbers = "";
            numbers.ForEach(number => allNumbers += $"{number} ");
            TutorialUtilities.WriteCodeResult("'numbers.ForEach(number => Console.Write(number + \" \"));' outputs every number in the numbers list: " + allNumbers);
            TutorialUtilities.WaitForKey();

            TutorialUtilities.WriteTitle(@"This doesn't need to be all in one line, if you want to have multiple line code on the right side of the arrow use curly brackets:");
            string allMessages = "";
            // This doesn't need to be all in one line, if you want to have multiple line code on the right side of the arrow use curly brackets:
            numbers.ForEach(number =>
            {
                string message = $"I didn't modify the temporary number: {number}";
                if (number > 2)
                {
                    message = $"I modified the temporary number: {number *= 2}";
                }
                allMessages += $"\n{message}";
            });
            TutorialUtilities.WriteCodeResult("The result of the second ForEach loop in 'LambdaExpressions' method is: " + allMessages);
            TutorialUtilities.WaitForKey();


            TutorialUtilities.WriteTitle(@"Since whatever is on the right handside is essentialy a function you can also use an actual function instead. View second to last command line in 'LambdaExpressions' method for an example");
            // Since whatever is on the right handside is essentialy a function you can also use an actual function instead
            numbers.ForEach(value => ExampleMethod(value));

            TutorialUtilities.WaitForKey();

            TutorialUtilities.WriteTitle(@"Some methods also return a value, for example aggregate one, if you stick to one line with no curly brackets you don't have to do anything, just write the line to be executed. If you use curly brackets or an actual method then use 'return' keyword to return the result of the method");
            
            // Some methods also return a value, for example aggregate one,
            // If you stick to one line with no curly brackets you don't have to do anything, just write the line to be executed
            // If you use curly brackets or an actual method then use 'return' keyword to return the result of the method
            int sum = numbers.Aggregate(0, (sum, next) => ExampleReturnMethod(sum, next));
            TutorialUtilities.WriteCodeResult($"The result of last command line in 'LambdaExpressions' method is: {sum}");
            TutorialUtilities.WaitForKey();
            TutorialUtilities.CloseSection();
        }

        private static void ExampleMethod(int number)
        {
            TutorialUtilities.WriteCodeResult("'ExampleMethod' called in ForEach loop output - This is the initial number: " + number);
            number += 10;
            TutorialUtilities.WriteCodeResult("'ExampleMethod' called in ForEach loop output - This is the updated temporary number: " + number);
        }

        private static int ExampleReturnMethod(int sum, int next)
        {
            if (sum < 10)
            {
                return sum += next;
            } else
            {
                return 10;
            }
        }

        private static void PolymorphicMethods()
        {
            // As you can see you can have multiple methods with the same name as long as their parameters are different
            // There are 'polymorphic' methods, a lot of methods have multiple implementations
            // when you write a line of code to call a method you might see 1 of n pop up appearing, this means that the method is polymorphic
            int sum = Add(2, 2);
            int sum2 = Add(2, 2, 2);
            float sum3 = Add(2.2f, 2.3f);
            TutorialUtilities.OutputToConsole(false, new Dictionary<string, float>
            {
                { "Add method taking two integers returned      == ", sum },
                { "Add method taking three integers returned    == ", sum2 },
                { "Add method taking 2 floats returned          == ", sum3 },
            }, "Take a look at 'PolymorphicMethods' method, here we are calling multiple polymorphic methods of the same name:");
        }

        private static int Add(int num1, int num2)
        {
            return num1 + num2;
        }

        private static int Add(int num1, int num2, int num3)
        {
            return num1 + num2 + num3;
        }

        private static float Add(float num1, float num2)
        {
            return num1 + num2;
        }
    }
}
