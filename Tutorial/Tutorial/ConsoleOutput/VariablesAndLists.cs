using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial.ConsoleOutput
{
    /// <summary>
    /// This is an example enum, you can see what number each option represents by hovering over the option,
    /// You can also override the numbers options represent by assigning a number to those options, e.g. Pen = 4765
    /// </summary>
    enum ExampleEnum
    {
        Apple,
        Pen,
        Pineapple
    }

    enum DataEnum
    {
        Record,
        TargetRecord,
        BadRecord
    }

    public static class VariablesAndLists
    {
        public static void Run()
        {
            TutorialUtilities.StartSection();
            TutorialUtilities.WriteTitle(@"Open the 'VariablesAndLists' script file in the 'Tutorials' folder:");
            TutorialUtilities.WaitForKey();
            TutorialUtilities.CloseSection();

            bool run = true;
            while (run)
                run = SectionMenu();
        }

        private static bool SectionMenu()
        {
            Console.WriteLine("Which option would you like to run? (input option number)");
            Console.WriteLine("0: Exit");
            Console.WriteLine("1: All");
            Console.WriteLine("2: Variables");
            Console.WriteLine("3: Variable Keywords");
            Console.WriteLine("4: Array Examples");
            Console.WriteLine("5: Array Alternatives");
            Console.WriteLine("6: Variable Operations");
            Console.WriteLine("7: Conditional Statements");
            Console.WriteLine("8: Enums");
            Console.WriteLine("9: Iteration");
            Console.WriteLine("10: List Operations");

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
                    case "2": VariableExamples(); break;
                    case "3": VariableKeywords(); break;
                    case "4": ArrayExamples(); break;
                    case "5": ArrayAlternatives(); break;
                    case "6": VariableOperations(); break;
                    case "7": ConditionalStatements(); break;
                    case "8": Enums(); break;
                    case "9": Iteration(); break;
                    case "10": ListOperations(); break;
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
                TutorialUtilities.WriteTitle(@"Open the 'VariablesAndLists' script file in the 'Tutorials' folder:");
                TutorialUtilities.WaitForKey();
                TutorialUtilities.CloseSection();
            }

            VariableExamples();
            VariableKeywords();
            ArrayExamples();
            ArrayAlternatives();
            VariableOperations();
            ConditionalStatements();
            Enums();
            Iteration();
            ListOperations();
        }

        private static void VariableExamples()
        {
            // In this method we're 'Declaring' (Creating) and 'Initialising' (adding initial value) variables of different types
            // This can also be named as 'Defining' a variable since the variable is both 'Declared' and 'Initialised'

            // variable consists of type (bool/int/object/etc.), name (whatever you like), and value (must match the type, so whole numbers for integers, single letters for chars etc.)

            // bool can be true or false
            bool exampleBool = true;

            // integers are whole numbers (no decimals)
            int exampleInt = 1;

            // Unsigned integers are any non-negative whole numbers, they need to haveu after the value to let C# know they're floats, u is not read as part of the value
            uint exampleUint = 2u;

            // float numbers need to have f after the value to let C# know they're floats, f is not read as part of the value
            float exampleFloat = 1.1f;

            // decimal numbers are same as floats, however, you don't need to use f and they're more precise, these can be used by default in our projects
            double exampleDouble = 1.1;

            // char can only hold a single character, including escaped characters and special ones like \' (escaped quote) or \\ (escaped backslash) or \0 (char representation of null)
            char exampleChar = '1';

            // strings can hold as many characters as you like, they can be empty, single letters, whole sentences or thousends lines of texts
            string exampleString = "1.1"; 

            // strings are arrays of characters, this will return '1' since that's the first character in the above string
            char exampleStringToChar = exampleString[0];



            // ==================================================================================================================
            // =====================================================END==========================================================
            // ==================================================================================================================

            TutorialUtilities.OutputToConsole(false, new Dictionary<string, string>
            {
                { "exampleBool          ==", $"{exampleBool}" },   
                { "exampleInt           ==", $"{exampleInt}" },
                { "exampleUint          ==", $"{exampleUint}" },
                { "exampleFloat         ==", $"{exampleFloat}" },
                { "exampleDouble        ==", $"{exampleDouble}" },
                { "exampleChar          ==", $"{exampleChar}" },
                { "exampleString        ==", $"{exampleString}" },
                { "exampleStringToChar  ==", $"{exampleStringToChar}" }
            }, "Take a look at the 'VariableExamples' method, here we can find variable examples of different types, read through comments to understand each type:");

        }

        private static void VariableKeywords()
        {
            // This is a normal variable as we seen in the previous method
            int exampleInt = 5;
            // it can be modified
            exampleInt = 10;

            // This is  a constant variable with const prefix
            const int exampleInt2 = 5;
            // it can't be modified cause it's a constant
            ///exampleInt2 = 10;

            // Below is an example of another keyword, however it will only work with classes and structs
            // This would mean that this can only be modified in a class constructor, it  will be covered in classes tutorial
            ///readonly int exampleInt3 = 5;

            // This is yet another keyword reserved for classes and structs, it will be covered in classes tutorial
            ///static int exampleInt4 = 5;

            // ==================================================================================================================
            // =====================================================END==========================================================
            // ==================================================================================================================
            TutorialUtilities.OutputToConsole(false, new Dictionary<string, int>
            {
                { "exampleInt is a normal variable, it can be modified      == ", exampleInt },
                { "exampleInt2 is a const variable, it cannot be modified   == ", exampleInt2 },
                { "There's also readonly and static variables, they will be discussed in classes tutorial. ", 0 },
            }, "Take a look at 'VariableKeywords' method, here we can find variables using keywords in front of their type, read through comments:");
        }

        private static void ArrayExamples()
        {
            // Defining arrays
            bool[] boolArray = new[] { true, false, false, true };

            int[] intArray = new[] { 1, 2, 3, 4 };

            string[] stringArray = new[] { "one", "two", "three" };


            // Retrieving array values, arrays indexes start with 0, so [0] will give first element and [2] will give third element

            // will be 'true' since that's the first value in the array
            bool exampleBool = boolArray[0];

            // will return 3 since that's the third value in the array;
            int exampleInt = intArray[2];

            // will return "two" since that's the second value in the array
            string exampleString = stringArray[1];

            // strings are arrays of characters, this will return '1' since that's the first character in the above string
            string anotherString = "1234";
            char exampleStringToChar = anotherString[0];

            // You can have multi-dimensional arrays, i.e. arrays in an array, here we define a 2 dimensional array
            string[][] multiDimensionalArray = new[] { stringArray, stringArray };

            // This will return 'two' since we're returning second value of the first array
            string yetAnotherString = multiDimensionalArray[0][1];

            // Since strings are arrays of chars you can see that we actually have 3 dimensions here
            // This will return 't' since it's the first character of the third value in the second array
            char charFromArray = multiDimensionalArray[1][2][0];


            // ==================================================================================================================
            // =====================================================END==========================================================
            // ==================================================================================================================

            TutorialUtilities.OutputToConsole(true, new Dictionary<string, string>
            {
                { "boolArray has following values       == ", String.Join(", ", boolArray) },
                { "intArray has following values        == ", String.Join(", ", intArray) },
                { "stringArray has following values     == ", String.Join(", ", stringArray) },
            }, "Take a look at three first lines of code in the 'ArrayExamples' method, these are three different arrays holding different data type variables:");

            TutorialUtilities.OutputToConsole(true, new Dictionary<string, string>
            {
                { "First element of exampleBool array at index [0]        == ", $"{boolArray[0]}" },
                { "Third element of exampleInt array at index [2]         == ", $"{intArray[2]}" },
                { "Second element of exampleString array at index [1]     == ", stringArray[1] },
            }, "Look at the next three lines of code, here you can see that you can retrieve their values through their index, indexes start with 0:");

            TutorialUtilities.OutputToConsole(true, new Dictionary<string, string>
            {
                { "Here's a string with following value     == ", anotherString },
                { "first letter of it at index [0] is       == ", $"{exampleStringToChar}" },
            }, "Looking at next two lines of code you can see that strings are also arrays of characters");

            TutorialUtilities.OutputToConsole(false, new Dictionary<string, string>
            {
                { "We can put stringArray arrays into a new array called multiDimensionalArray          == ", $"{multiDimensionalArray}" },
                { "We can retrieve second element of first stringArray multiDimensionalArray[0][1]      == ", yetAnotherString },
                { "Since strings are also arrays, we actually have a 3 dimensional array - example multiDimensionalArray[1][2][0] == ",  $"{charFromArray}"  },
            }, "Finally in the last two lines of code you can see that there's also multi-dimensional arrays, basically arrays in arrays");
        }

        private static void ArrayAlternatives()
        {
            // Arrays are the old way of holding multiple values, they still have some use cases but in our team we usually use alternatives, mainly Lists
            int[] exampleArray = new[] { 1, 2, 3, 4 };


            // Lists are what we use the most in RPA, they're basically arrays that give a lot more control in how you can access their values, modify them, and expand them
            List<int> exampleList = new() { 1, 2, 3, 4 };
            exampleList.Add(5);
            int aListValue = exampleList[2];


            // Stacks are alternatives that have some limitations, you can only retrieve top (last) value of stack, and to get next one you need to pop (remove) last one
            // This is refered to as LIFO (Last in, first out) you can imagine this as putting trays on a stack, you can only put them on top and take them out of top
            // You also initialise stack differently as seen below
            Stack<int> exampleStack = new(new[] { 1, 2, 3, 4 });
            exampleStack.Push(5);
            int aStackValue = exampleStack.Pop();


            // Queues are opposites of stacks, again their limitations are that you cannot retrieve anywhere from the middle but you 'dequeue'
            // They are refered to as FIFO (First in, first out), basically as their name suggests, in a queue whatever/whoever comes in first will be first one to leave
            Queue<int> exampleQueue = new(new[] { 1, 2, 3, 4 });
            exampleQueue.Enqueue(5);
            int aQueueValue = exampleQueue.Dequeue();


            // HashSets are again alternatives that have other limitations, they can only contain unique values, however, any read/write operations on HashSets are much faster
            // They also don't store values in any particular order so iterating through them might return various results
            // Any duplicate values in hashsets are merged into one
            HashSet<int> exampleHashSet = new() { 1, 2, 3, 4, 4 };
            exampleHashSet.Add(5);
            bool foundValue = exampleHashSet.TryGetValue(3, out int aHashValue);

            // Dictionaries are consisting of unique keys holding values, you can search for values by specifiyng their keys as shown in example below
            // Both keys and values can be of any type. You can use integers, strings, chars anything you like as a key
            // to store any type of value you like (including arrays, other dictionaries etc.)
            Dictionary<string, int> exampleDictionary = new()
            {
                { "first", 3 },
                { "second", 1 },
                { "third", 4 }
            };
            exampleDictionary.Add("fourth", 43);
            int aDictionaryValue = exampleDictionary["second"];

            // There's also lookup that's beyond the scope of this tutorial, but you can see it under array conversion
            // Lookup is immutable, so once you create it you can't add or remove elements but it can group various values under groups,
            // Basically in Dictionary one key has one value (that can also be an array), but in Lookup one key has many values, not useful in our projects right now


            // ======== ARRAY CONVERSION =========
            // ======== THIS IS BEYOND THE SCOPE OF THE TUTORIAL ========

            // This array can be converted to a list that we typically use:
            List<int> exampleConvertedList = exampleArray.ToList();

            // Or to HashSet (we don't use it currently)
            HashSet<int> exampleConvertedHash = exampleArray.ToHashSet();


            // You can convert array into a dictionary and lookup but that might be too complex at this stage
            Dictionary<string, int> exampleConvertedDict = exampleArray
                .Select((x, i) => new { Item = x, Index = ++i })
                .ToDictionary(element => $"Element number: {element.Index}", element => element.Item);

            foreach (KeyValuePair<string, int> element in exampleConvertedDict)
                Console.WriteLine($"{element.Key} {element.Value}");

            Console.WriteLine("=============================");

            Lookup<string, int> exampleConvertedLookup = (Lookup<string, int>)exampleArray
                .Select((x, i) => new { Item = x, Index = ++i })
                .ToLookup(element => element.Item <= exampleArray.Count() / 2 ? $"Element group 1" : $"Element group 2", element => element.Item);

            foreach (IGrouping<string, int> element in exampleConvertedLookup)
                Console.WriteLine($"{element.Key} {element.First()},{element.Last()}");


            // ==================================================================================================================
            // =====================================================END==========================================================
            // ==================================================================================================================

            TutorialUtilities.OutputToConsole(true, new Dictionary<string, string>
            {
                { "Lists are what we use the most, they are like arrays but with more functionalities - exampleList                                 == ", $"{String.Join(", ", exampleList)}" },
                { "You can add elements through .Add(), and just like in an array you can read any value by using index - exampleList[2]            == ", $"{exampleList[2]}" },
            }, "Take a look at the 'ArrayAlternatives' method. There's various alternatives to arrays, we'll just review some of them, looking at the List example first...:");

            TutorialUtilities.OutputToConsole(true, new Dictionary<string, string>
            {
                { "Stacks are similar to lists, but you can only add values to end and only read the last value - exampleStack                      == ", $"{String.Join(", ", exampleStack)}" },
                { "You add to a stack with the use of .Push() method, and read through .Pop(), it removes and returns last element                  == ",  $"{aStackValue}"  },
            }, "Next, there's a stack:");

            TutorialUtilities.OutputToConsole(true, new Dictionary<string, string>
            {
                { "Queues are opposites of stack, you can only push to the end and read the first element - exampleQueue                            == ", $"{String.Join(", ", exampleQueue)}" },
                { "You add to a queue with the use of .Enqueue() method, and read through .Dequeue(), it removes and returns last element           == ",  $"{aQueueValue}"  },
            }, "Next, there's a queue:");

            TutorialUtilities.OutputToConsole(true, new Dictionary<string, string>
            {
                { "HashSets are arrays with unique elements only, elements are not ordered so iterating might give varying results - exampleHashSet == ", $"{String.Join(", ", exampleHashSet)}" },
                { "You add to HashSet through .Add() method and read elements through .TryGetValue()                                                == ",  $"{aHashValue}"  },
            }, "Next, there's a hashset:");

            TutorialUtilities.OutputToConsole(false, new Dictionary<string, string>
            {
                { "There's also dictionaries that consist of key value pairs - exampleDictionary                                                    == ", $"{String.Join($", ", exampleDictionary.Values)}" },
                { "You add to dictionaries through .Add() and read by using key - exampleDictionary[\"second\"]                                       == ",  $"{aDictionaryValue}"  },
            }, "Finally, there's a dictionary, there's more types but we won't cover them all:");

        }

        private static void VariableOperations()
        {
            //Here's examples of various operations you can carry out on variables

            // multiplication uses *, division uses /, remainder of division uses %, then you have + and -
            int multiplication = 2 * 2;
            int division = 4 / 2;
            int remainder = 3 % 2;
            int addition = 2 + 2;
            int subtraction = 2 - 2;

            //You can use shorthand for calculations, each below pairs are the same
            int sum = 2;
            int number = 2;

            sum = sum * number;
            sum *= number;

            sum = sum / number;
            sum /= number;

            sum = sum % number;
            sum %= number;

            sum = sum + number;
            sum += number;

            sum = sum - number;
            sum -= number;

            int incrementNumber = 1;

            // Incrementing is basically a shorthand for variable += 1, it's used widely, especially in for loops you might often see i++
            // There's a different effect based on where ++ is located, if it's behind a variable then variable will be incremented before command gets executed
            // if it's after a variable then variable will be incremented after command is executed:
            incrementNumber++; // ++ is after variable, so variable will be written to the console before it's incremented, then it will be incremented to 2
            ++incrementNumber; // ++ is before variable, so variable will be incremented before it's written to the console, so it will already be 3 before it's written

            // There's also decrement, basically opposite of the above
            int decrementNumber = 3;
            decrementNumber--;
            --decrementNumber;

            // Relational operators, these are often used in conditional statements and loops
            bool isLarger = 2 > 3; // Will return false
            bool isSmaller = 2 < 3; // Will return true
            bool isEqual = 2 == 3; // will return false
            bool isNotEqual = 2 != 3; // will return true
            bool isEqualOrLarger = 2 >= 3; // will return false
            bool isEqualOrSmaller = 2 <= 3; // will return true

            // ! is a logical operator  which means 'not', there's also && that means 'and' as well as || that means 'or'
            bool isThisBoolTrue = false; // this is false
            bool isThisBoolFalse = !isThisBoolTrue; // This will return opposite of isThisBoolTrue, therefore this will be true
            
            bool isSunny = true;
            bool isWindy = true;
            bool isSunnyOrWindy = isSunny || isWindy; // This will be true if either isSunny or isWindy is true
            bool canPlayBadminton = isSunny && !isWindy; // This will be true if it's both sunny, and not windy


            // Concatenation of strings
            string concatenatedText = "This sentence is a: ";
            string text1 = "Hello";
            string text2 = "World";

            // Will result in "This sentence is a: Hello World"
            concatenatedText += text1 + " " + text2;
            // Will result in "Hello World"
            concatenatedText = text1 + " " + text2;

            char firstLetter = 'd';
            char secondLetter = 'f';
            char thirdLetter = 'g';

            // Using $ sign and inputting variables through {} in a string is called string interpolation
            string stringOfChars = $"abc{firstLetter}e{secondLetter}f{thirdLetter}hij";


            // ==================================================================================================================
            // =====================================================END==========================================================
            // ==================================================================================================================

            TutorialUtilities.OutputToConsole(true, new Dictionary<string, int>
            {
                { "multiplication:  2 * 2 == ", multiplication },
                { "division:        4 / 2 == ", division },
                { "remainder:       3 % 2 == ", remainder },
                { "addition:        2 + 2 == ", addition },
                { "subtraction:     2 - 2 == ", subtraction },
            }, "Take a look at 'VariableOperations' method. There's various number operations, let's first look at arithmetic and assignment operators:");

            TutorialUtilities.OutputToConsole(true, new Dictionary<string, int>
            {
                { "sum = sum * number is same as sum *= number, e.g. sum(2) *= number(2)  == ", 4 },
                { "sum = sum / number is same as sum /= number, e.g. sum(4) /= number(2)  == ", 2 },
                { "sum = sum % number is same as sum %= number, e.g. sum(3) %= number(2)  == ", 1 },
                { "sum = sum + number is same as sum += number, e.g. sum(2) += number(2)  == ", 4 },
                { "sum = sum - number is same as sum -= number, e.g. sum(2) -= number(2)  == ", 0 },
            }, "Next you can see that there's shorthands for these operations:");

            int consoleNumber = 1;
            TutorialUtilities.OutputToConsole(true, new Dictionary<string, int>
            {
                { "if number is 1 and we use number++ it will still be outputted as 1 since it will be incremented after                        == ", consoleNumber++ },
                { "After last increment number is 2, if we use ++number it will now be outputted as 3 since it is incremented before            == ", ++consoleNumber },
                { "After previous increments number is 3, if we use number-- it will still be outputted as 3 since it will be decremented after == ", consoleNumber-- },
                { "after previous decrement number is 2, if we use --number it will be outputted as 1 since it is decremented before            == ", --consoleNumber },
            }, "You can also use ++ for incrementing and -- for decrementing as seen a bit further down:");

            TutorialUtilities.OutputToConsole(true, new Dictionary<string, bool>
            {
                { "isLarger = 2 > 3  == ", isLarger },
                { "isSmaller = 2 < 3 == ", isSmaller },
                { "isEqual = 2 == 3  == ", isEqual },
                { "isNotEqual = 2 != 3  == ", isNotEqual },
                { "isEqualOrLarger = 2 >=3  == ", isEqualOrLarger },
                { "isEqualOrSmaller = 2 <=3  == ", isEqualOrSmaller },
            }, "Let's move on to relational operators, these are used for comparison:");

            TutorialUtilities.OutputToConsole(true, new Dictionary<string, bool>
            {
                { "isThisBoolFalse, uses '!', which is a logical operator  which means 'not'  == ", isThisBoolFalse },
                { "isSunnyOrWindy uses '||' so at least one of those conditions must be true - isSunny or isWindy == ", isSunnyOrWindy },
                { "canPlayBadminton uses '&&' so it checks for both conditions - isSunny and !isWindy", canPlayBadminton },
            }, "Next, there's logical (not, and, or) operators, these are often used in if statements and loops:");

            concatenatedText = "This sentence is a: ";
            TutorialUtilities.OutputToConsole(true, new Dictionary<string, string>
            {
                { "string variable concatenatedText  == ", concatenatedText },
                { "We can concatenate it with text1, space and text2 through concatenatedText += text1 + \" \" + text2         == ", concatenatedText += text1 + " " + text2 },
                { "We can replace it with concatenated text1, space and text2 through concatenatedText = text1 + \" \" + text2 == ", concatenatedText = text1 + " " + text2 }
            }, "Moving onto strings, they can also be concatenated using + or += signs:");

            TutorialUtilities.OutputToConsole(false, new Dictionary<string, string>
            {
                { "$\"abc{firstLetter}e{secondLetter}f{thirdLetter}hij  == ", stringOfChars },
            }, "Finally we can use $ sign to include variables in string through {}, this is string interpolation");

        }

        private static void ConditionalStatements()
        {
            TutorialUtilities.StartSection();
            TutorialUtilities.WriteTitle("Take a look at the 'ConditionalStatements' method. There's multiple ways to deal with conditions, we've got 'if else' statement:");

            // There's multiple ways to deal with conditions, main ones are if else, switch, and ternary operators:

            int num1 = 10;
            int num2 = 20;

            // if else statement
            if (num1 < num2)
            {
                TutorialUtilities.WriteCodeResult($"num1({num1}) is smaller than num2({num2})");
            }
            else if (num1 == num2)
            {
                TutorialUtilities.WriteCodeResult($"num1({num1}) is equal to num2({num2})");
            }
            else
            {
                TutorialUtilities.WriteCodeResult($"num1({num1}) is larger than num2({num2})");
            }
            TutorialUtilities.WaitForKey();

            TutorialUtilities.WriteTitle("There's also switch statement:");
            // switch statement
            switch (num1)
            {
                case 10: TutorialUtilities.WriteCodeResult($"num1({num1}) is equal to 10"); break;
                case 20: TutorialUtilities.WriteCodeResult($"num1({num1}) is equal to 20"); break;
                case 30: TutorialUtilities.WriteCodeResult($"num1({num1}) is equal to 30"); break;
                default: TutorialUtilities.WriteCodeResult($"num1({num1}) is unknown"); break;   // Default is triggered if no other condition triggers
            }
            TutorialUtilities.WaitForKey();

            TutorialUtilities.WriteTitle("Next it's ternary operators:");
            // This is a ternary operator, it's a shorthand for an if statement, it means the same thing as:
            // if (num1 < num2)
            // {
            //      num3 = num1;
            // } else
            // {
            //      num3 = num2;
            // }
            int num3 = num1 < num2 ? num1 : num2;
            TutorialUtilities.WriteCodeResult($"num3 value is {num3}");
            TutorialUtilities.WaitForKey();


            TutorialUtilities.WriteTitle("Finally switch expressions:");
            // switch expression, basically a switch statement but used to assign a value to a variable
            string message = num1 switch
            {
                10 => "num1 is 10",
                20 => "num1 is 20",
                30 => "num1 is 30",
                _ => "num1 is unknown"  // This is default option if no other matches
            };
            TutorialUtilities.WriteCodeResult($"this is the string value of message variable: \"{message}\"");
            TutorialUtilities.WaitForKey();
            TutorialUtilities.CloseSection();
        }

        private static void Enums()
        {
            // Enums allow you to name various options, each enum option is a number under the hood, so first enum option == 0, second == 1, third == 2 and so on,
            // But they are easier to read than numbers as they can mean something, and they also limit the options someone has in doing something

            // At the top of the program an ExampleEnum is defined
            // Here you can see
            ExampleEnum fruit = ExampleEnum.Pen;

            string message = fruit switch
            {
                ExampleEnum.Apple => "This is an apple",
                ExampleEnum.Pen => "This is a pen",
                ExampleEnum.Pineapple => "This is a pineapple",
                _ => "No idea what it is"
            };

            TutorialUtilities.OutputToConsole(false, new Dictionary<string, int>
            {
                { "ExampleEnum fruit is equal to ExampleEnum.Pen, which is identified by number  == ", (int)fruit },
            }, "Going to 'Enums' method, enums allow you to name various options, each enum option is a number under the hood, so first enum option == 0, second == 1, etc.");
        }



        private static void Iteration()
        {
            // There's different ways to iterate (loop over arrays, lists or other objects), we'll use list and dictionary in this example but any array would work
            TutorialUtilities.StartSection();
            TutorialUtilities.WriteTitle("Looking at 'Iteration' method, there's multiple ways to iterate through array types, we've got for loops:");

            List<int> numbers = new() { 1, 2, 3 };
            int listSize = numbers.Count; // will be equal to 3 since we have 3 elements

            // Will output List values at 'i' index, which will get incremented (++) while i is smaller than listSize (so 0 to 2)
            for (int i = 0; i < listSize; i++) // Could use numbers.Count instead of listSize here but this is just an example, 'i' is just a variable, so it can have any name
            {
                TutorialUtilities.WriteCodeResult($"For loop iterating through element with value == {numbers[i]}");
            }

            TutorialUtilities.WaitForKey();


            TutorialUtilities.WriteTitle("foreach loop:");
            // Also iterates through all elements but is neater that above loop 
            foreach (int number in numbers)
            {
                TutorialUtilities.WriteCodeResult($"Foreach loop iterating through element with value == {number}");
            }

            TutorialUtilities.WaitForKey();

            TutorialUtilities.WriteTitle("foreach method that can be called on most array types:");
            // ForEach method that can be called on lists, dictionaries and other array types, cleanest option
            numbers.ForEach(number => TutorialUtilities.WriteCodeResult($"Foreach method iterating through element with value == {number}"));

            TutorialUtilities.WaitForKey();

            TutorialUtilities.WriteTitle("While loops:");
            // while loops - can be used as a replacement for a for loop as seen below, but are often used with booleans e.g. while(foundRecord) { foundRecord = searchForRecord() }
            int index = 0;
            while (index < listSize)
            {
                TutorialUtilities.WriteCodeResult($"While loop iterating through element with value == {numbers[index]}");
                index++;
            }

            TutorialUtilities.WaitForKey();

            TutorialUtilities.WriteTitle("Do while loops:");
            // do while - same as while loop but will loop before checking for condition
            index = 0;
            do
            {
                TutorialUtilities.WriteCodeResult($"Do while loop iterating through element with value == {numbers[index]}");
                index++;
            } while (index < listSize);

            TutorialUtilities.WaitForKey();

            // ============= DICTIONARY ===============


            TutorialUtilities.WriteTitle("Dictionaries can also be looped through:");
            // Looping can be done using (almost all) same methods but since keys come into play it will be slightly different
            Dictionary<string, int> shoppingList = new()
            {
                { "apples", 4 },
                { "bananas", 3 },
                { "watermelon", 1 }
            };

            for (int i = 0; i < shoppingList.Count; i++)
            {
                int element = shoppingList.ElementAt(i).Value;
            }

            foreach (KeyValuePair<string, int> element in shoppingList)
            {
                TutorialUtilities.WriteCodeResult($"Iterating through dictionary with key: \"{element.Key}\" and value: \"{element.Value}\"");
            }

            TutorialUtilities.WaitForKey();

            // Notice shoppingList.ForEach() cannot be called cause dictionary does have this method built into its class

            TutorialUtilities.WriteTitle("In for, foreach, while, do while loops you can skip single iteration with the use of 'continue', or completely exit the loop using 'break' keywords:");
            //In for, foreach, while, do while loops you can skip single iteration with the use of 'continue', or completely exit the loop using 'break' keywords
            DataEnum[] records = new[] { DataEnum.Record, DataEnum.BadRecord, DataEnum.BadRecord, DataEnum.Record, DataEnum.TargetRecord, DataEnum.Record };

            foreach (DataEnum record in records)
            {
                if (record == DataEnum.BadRecord)
                {
                    TutorialUtilities.WriteCodeResult("This record is in bad format, skipping it with the use of 'continue'...");
                    continue;
                } else if (record == DataEnum.TargetRecord)
                {
                    TutorialUtilities.WriteCodeResult("Found the target record, exiting the loop with the use of 'break'...");
                    break;
                }

                TutorialUtilities.WriteCodeResult("Read another normal record");
            }
            TutorialUtilities.WaitForKey();

            TutorialUtilities.CloseSection();
        }

        private static void ListOperations()
        {
            // All array types (List, array, queue, dictionary etc.) have various methods that can be called on them
            // Since we use Lists the most I will show some examples of List methods that can be used

            TutorialUtilities.StartSection();
            TutorialUtilities.WriteTitle("Looking at final 'ListOperations' method in 'VariablesAndLists' script file, there's various operations you can perform on array types using built in methods:");

            List<int> numbers = new() { 1, 2, 2, 3, 3, 3 };
            List<int> numbers2 = new() { 1, 3 };
            TutorialUtilities.WriteCodeResult($"'numbers' list values: {String.Join(", ", numbers)}");
            TutorialUtilities.WriteCodeResult($"'numbers2' list values: {String.Join(", ", numbers2)}");
            TutorialUtilities.WaitForKey();

            TutorialUtilities.WriteTitle("Can use .Distinct() method to get distinct (unique) values in a list or some different array types:");
            // Will output distinct (unique) numbers in enumerable data type, so we then have to use another built in method called ToList() to convert back to a list
            List<int> newNumbers = numbers.Distinct().ToList();
            TutorialUtilities.WriteCodeResult($"Distinct numbers from 'numbers' list: {String.Join(", ", newNumbers)}");
            TutorialUtilities.WaitForKey();

            // Will return an intersection of both lists
            TutorialUtilities.WriteTitle("Can use .Intersect() method to get intersection of two lists and some different array types:");
            newNumbers = numbers.Intersect(numbers2).ToList();
            TutorialUtilities.WriteCodeResult($"Numbers intersected from 'numbers' and 'numbers2' lists: {String.Join(", ", newNumbers)}");
            TutorialUtilities.WaitForKey();

            // Aggregate function, can be anything, but in this case it sums up all numbers
            TutorialUtilities.WriteTitle("Can use .Aggregate() method to aggregate all values into one using any method, in this case we're summing up: ");
            TutorialUtilities.WriteCodeResult($"Sum of all numbers from 'numbers' list: {numbers.Aggregate(0, (sum, next) => sum + next)}");
            TutorialUtilities.WaitForKey();

            // Will remove 2 elements starting at index 3
            TutorialUtilities.WriteTitle("Can use .RemoveRange() method to remove a range of elements from a list: ");
            numbers.RemoveRange(3, 2);
            TutorialUtilities.WriteCodeResult($"Removing 2 elements starting from index [3] from 'numbers' list: {String.Join(", ", numbers)}");
            TutorialUtilities.WaitForKey();
            TutorialUtilities.CloseSection();
        }

    }
}
