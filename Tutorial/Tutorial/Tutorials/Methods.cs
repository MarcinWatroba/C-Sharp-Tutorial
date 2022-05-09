using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial.Tutorials
{
    public static class Methods
    {
        public static void RunMethods()
        {
            // Methods consist of access modifier (private, protected, public), return type (void - return nothing, int, List<string> etc.), 
            // name (can be anything), and 'parameters' (names listed in function's definition, within brackets - 'arguments' are actual values that are assigned to these parameters)
            // They can also use a 'static' keyword
            NoParamsMethod();
            string message = ReturnMethod();
            ParamsMethod(message);

            // Methods can be passed into other methods as can be seen here, the outer method will be executed using the return (result) of inner method as its argument
            int sum = AddUp(2, 3);

            // Last parameter is not passed in so the default value will be used instead
            OptionalParams("The sum is:", 5, 5);

            // we get a return and we get an 'out' variable, we need to pass in a variable that we want to save the 'out' value to
            // If variable is not declared before we call the method we can declare it within brackets of method, if it is declared before we just pass it without specifying type
            bool passedExam = OutParams(51, out string uniMessage);
            Console.WriteLine($"I've got returned boolean - {passedExam}, and updated uniMessage variable value - {uniMessage}");
            LambdaExpressions();
            PolymorphicMethods();


        }

        private static void NoParamsMethod()
        {
            Console.WriteLine("This is a method that doesn't have any parameters and does not return anything");
        }

        private static string ReturnMethod()
        {
            Console.WriteLine("This is a method that doesn't have any parameters but returns a string type variable");
            return "Method ran";
        }

        private static void ParamsMethod(string text)
        {
            Console.WriteLine("This is a method that has parameters but does not return anything");
            Console.WriteLine(text);
        }

        private static int AddUp(int number1, int number2)
        {
            Console.WriteLine("This method has parameters and returns an integer");
            return number1 + number2;
        }

        private static void OptionalParams(string message, int num1, int num2 = 0, int num3 = 0)
        {
            Console.WriteLine("This method has two optional parameters, you can make parameters optional by giving them a default value");
            Console.WriteLine($"{message} {num1 + num2 + num3}");
        }

        private static bool OutParams(int grade, out string message)
        {
            Console.WriteLine("This method returns a boolean and outputs value to an 'out' variable that can then be read through calling method\nthere can be multiple out variables");
            bool passedExam = grade > 50;
            message = passedExam ? "Congratulations, you passed" : "Sorry, you failed";
            return passedExam;
        }

        private static void LambdaExpressions()
        {
            // You might have notices var => Console.WriteLien(var) in previous examples, these are lambda expressions, they are inline methods:
            List<int> numbers = new() { 1, 2, 2, 3, 3, 3 };

            // Here's a lambda expression, ForEach provides a parameter which can be named as anything, I named it as number
            // On the left side of the arrow are any parameters provided, you can find out what method provide what parameters through documentation
            // On the right side is the function to be executed using the parameters passed from the left side
            // Remember, since there are parameters they are just temporary, so modifying them in here will not cause parent object to have updated elements
            numbers.ForEach(number => Console.Write(number + " "));

            // This doesn't need to be all in one line, if you want to have multiple line code on the right side of the arrow use curly brackets:
            numbers.ForEach(number =>
            {
                string message = $"I didn't modify the temporary number: {number}";
                if (number > 2)
                {
                    message = $"I modified the temporary number: {number *= 2}";
                }
                Console.WriteLine(message);
            });

            // Since whatever is on the right handside is essentialy a function you can also use an actual function instead
            numbers.ForEach(value => ExampleMethod(value));

            // Some methods also return a value, for example aggregate one,
            // If you stick to one line with no curly brackets you don't have to do anything, just write the line to be executed
            // If you use curly brackets or an actual method then use 'return' keyword to return the result of the method
            Console.WriteLine(numbers.Aggregate(0, (sum, next) => ExampleReturnMethod(sum, next)));
        }

        private static void ExampleMethod(int number)
        {
            Console.WriteLine("This is the initial number: " + number);
            number += 10;
            Console.WriteLine("This is the updated temporary number: " + number);
        }

        private static int ExampleReturnMethod(int sum, int next)
        {
            Console.WriteLine("I'm using multiple line method here in the Aggregate method");
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
            float sum3 = Add(2.0f, 2.0f);
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
