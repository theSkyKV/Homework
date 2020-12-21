using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            string workplace;
            int age;

            Console.Write("Hello! What is your name? ");
            name = Console.ReadLine().ToString();
            Console.Write("How old are you? ");
            age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Where do you work? ");
            workplace = Console.ReadLine().ToString();

            Console.Write($"Your name is {name}. You are {age} years old. You work in {workplace}.");
        }
    }
}
