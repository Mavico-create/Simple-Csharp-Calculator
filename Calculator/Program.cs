using System;
using System.Collections.Generic;
using System.Globalization;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n=== Simple Calculator ===");
                Console.WriteLine("Type 'exit' to quit the program.");
             List<double> numbers = new List<double>();
                Console.WriteLine("Enter your first number:");
                string input1 = Console.ReadLine();
                if (input1 == null)
                    continue;
                if (input1.Trim().ToLower() == "exit")
                    break;
                // normalize to allow comma or dot as decimal separator
                input1 = input1.Trim().Replace(',', '.');
                if (!double.TryParse(input1, NumberStyles.Float, CultureInfo.InvariantCulture, out double num1))
                {
                    Console.WriteLine("Invalid number entered. Try again.");
                    continue;
                }

                Console.WriteLine("Enter your second number:");
                string input2 = Console.ReadLine();
                if (input2 == null)
                    continue;
                if (input2.Trim().ToLower() == "exit")
                    break;
                input2 = input2.Trim().Replace(',', '.');
                if (!double.TryParse(input2, NumberStyles.Float, CultureInfo.InvariantCulture, out double num2))
                {
                    Console.WriteLine("Invalid number entered. Try again.");
                    continue;
                }

                while (true)
                {
                    Console.WriteLine("Enter the operation you want to perform (+, -, *, /, %):");
                    string operation = Console.ReadLine();
                    if (operation == null)
                        continue;
                    if (operation.Trim().ToLower() == "exit")
                        break;
                    double result = 0;
                    bool valid = true;


                    switch (operation)
                    {
                        case "+":
                            result = num1 + num2;
                            break;

                        case "-":
                            result = num1 - num2;
                            break;

                        case "*":
                            result = num1 * num2;
                            break;

                        case "/":
                            if (num2 == 0)
                            {
                                Console.WriteLine("Error: Division by zero is not allowed.");
                                valid = false;
                            }
                            else result = num1 / num2;
                            break;

                        case "%":
                            if (num2 == 0)
                            {
                                Console.WriteLine("Error: Modulo by zero is not allowed.");
                                valid = false;
                            }
                            result = num1 % num2;
                            break;

                        default:
                            Console.WriteLine("Error: Invalid operation.");
                            valid = false;
                            break;
                    }
                    if (!valid) break;
                
                if (!valid)
                continue;

                    string equation = string.Join ($"{operation}", num1, num2);
                    Console.WriteLine($"The result is: {equation} = {result}");
                    Console.WriteLine("Do you wish to:");
                    Console.WriteLine("1. Continue with a different operation");
                    Console.WriteLine("2. Enter new numbers");
                    Console.WriteLine("3. Exit");

                    Console.Write("Choice:");

                    string choice = Console.ReadLine();
                    if (choice == "1") continue;
                    else if (choice == "2") break;
                    else if (choice == "3") return;
                    else
                    { Console.WriteLine("Invalid choice. Please try again."); }
                  
                }
            }
        }
    }
}
