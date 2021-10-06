using System;

namespace Calculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;
            double result = 0;

            while (isRunning)
            {
                // Exits the program if user press Escape
                Console.WriteLine("Press any button to continue or escape to exit");
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                    break;

                Console.Clear();

                //Tells the user to enter first input
                Console.WriteLine("Enter a number. ");
                double input1 = GetInputNumber();

                //Tells the user to choose operator
                Console.WriteLine("Enter operation: [+] [-] [/] [*] and press enter");
                string userOperator = Console.ReadLine();

                //Tells the user to enter second input
                Console.WriteLine("Enter a second number.");
                double input2 = GetInputNumber();

                switch (userOperator)
                {
                    case "+":
                        Console.WriteLine("If you want to add more numbers, enter [+], enter anything to continue");
                        switch (Console.ReadLine())
                        {
                            case "+":
                                result = Addition(input1, input2) + Addition(GetArrayInputNumber());
                                break;

                            default:
                                result = Addition(input1, input2);
                                break;
                        }
                        break;

                    case "-":
                        Console.WriteLine("If you want to subtract more numbers, enter [-], enter anything to continue");
                        switch (Console.ReadLine())
                        {
                            case "-":
                                result = Subtraction(input1, input2) + Subtraction(GetArrayInputNumber());
                                break;

                            default:
                                result = Subtraction(input1, input2);
                                break;
                        }
                        break;

                    case "*":
                        result = Multiplication(input1, input2);
                        break;

                    case "/":
                        result = Division(input1, input2);

                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Can only enter a number as input");
                        break;
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Result: {result}\n");
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Get user input
        /// </summary>
        /// <returns>user input</returns>
        public static double GetInputNumber()
        {
            double userInput = 0;
            bool isNumber = false;

            while (!isNumber)
            {
                isNumber = double.TryParse(Console.ReadLine(), out userInput);
            }

            return userInput;
        }

        /// <summary>
        /// Gets several inputs from user
        /// </summary>
        /// <returns>Array with user inputs</returns>
        public static double[] GetArrayInputNumber()
        {

            Console.WriteLine("Enter how many more numbers you would like to add");
            double length = GetInputNumber();

            double[] input = new double[(int)length];

            for (int i = 0; i < length; i++)
            {
                Console.WriteLine("Enter a number");
                input[i] = GetInputNumber();
            }

            return input;
        }

        #region Mathematical Operations

        /// <summary>
        /// Adds param 1 with param 2.
        /// </summary>
        /// <param name="input1"></param>
        /// <param name="input2"></param>
        /// <returns>Results</returns>
        public static double Addition(double input1, double input2)
        {
            return input1 + input2;
        }

        /// <summary>
        /// Adds param 1 with param 2.
        /// </summary>
        /// <param name="input1"></param>
        /// <param name="input2"></param>
        /// <returns>Results</returns>
        public static double Addition(double[] input)
        {
            double sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                sum += input[i];
            }

            return sum;
        }

        /// <summary>
        /// Subtracts param 1 with param 2.
        /// </summary>
        /// <param name="input1"></param>
        /// <param name="input2"></param>
        /// <returns>Results</returns>
        public static double Subtraction(double input1, double input2)
        {
            return input1 - input2;
        }

        /// <summary>
        /// Subtracts indexes
        /// </summary>
        /// <param name="input1"></param>
        /// <param name="input2"></param>
        /// <returns>Results</returns>
        public static double Subtraction(double[] input)
        {
            double sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                sum -= input[i];
            }

            return sum;
        }

        /// <summary>
        /// Multiplies param 1 with param 2
        /// </summary>
        /// <param name="input1"></param>
        /// <param name="input2"></param>
        /// <returns>Results</returns>
        public static double Multiplication(double input1, double input2)
        {
            return input1 * input2;
        }

        /// <summary>
        /// Divides param 1 with param 2, cannot divide by zero
        /// </summary>
        /// <param name="input1"></param>
        /// <param name="input2">Out param</param>
        /// <returns>Results</returns>
        public static double Division(double input1, double input2)
        {
            // While loop if trying to divide by zero
            // Will break if user input is other than zero
            //while (input2 == 0)
            //{
            //    Console.WriteLine(new DivideByZeroException().Message);
            //    Console.WriteLine("Enter a new number");
            //    input2 = GetInputNumber();
            //}

            if (double.IsInfinity(input1 / input2))
                throw new DivideByZeroException();

            return input1 / input2;
        }

        #endregion
    }
}
