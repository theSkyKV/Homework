using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string userMessage = "";
            string password = "";

            while(userMessage != "Exit")
            {
                Console.WriteLine("Please, enter command:");
                Console.WriteLine("Clear - clear console, SetPassword - set the password, LogIn - log in");
                Console.WriteLine("SetTextColor - set color of the text, Exit - exit");
                userMessage = Console.ReadLine();

                switch(userMessage)
                {
                    case "Clear":
                        Console.Clear();
                        break;
                    case "SetPassword":
                        password = Console.ReadLine();
                        break;
                    case "LogIn":
                        if (password != "")
                        {
                            Console.WriteLine("Enter password");
                            userMessage = Console.ReadLine();

                            if (userMessage == password)
                            {
                                Console.WriteLine("Hello");
                            }
                            else
                            {
                                Console.WriteLine("Access denied");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Access denied. You haven't got a password.");
                        }
                        break;
                    case "SetTextColor":
                        Console.WriteLine("Set color of the text: Green, Blue, Red");
                        userMessage = Console.ReadLine();

                        switch(userMessage)
                        {
                            case "Green":
                                Console.ForegroundColor = ConsoleColor.Green;
                                break;
                            case "Blue":
                                Console.ForegroundColor = ConsoleColor.Blue;
                                break;
                            case "Red":
                                Console.ForegroundColor = ConsoleColor.Red;
                                break;
                        }
                        break;
                    case "Exit":
                        Console.WriteLine("Bye");
                        break;
                    default:
                        Console.WriteLine("Invalid command. Try again");
                        break;
                }
            }
        }
    }
}
