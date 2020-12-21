using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleCount;
            int receiptTime = 10;
            int waitingTime;

            Console.Write("Enter number of peole in line: ");
            peopleCount = Convert.ToInt32(Console.ReadLine());

            waitingTime = receiptTime * peopleCount;

            Console.WriteLine($"You will stand in line {waitingTime / 60} hours and {waitingTime % 60} minutes");
        }
    }
}
