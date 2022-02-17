using System;
using System.Collections.Generic;
using TabloidCLI.Models;

namespace TabloidCLI.UserInterfaceManagers
{
    public class ColorChanger : IUserInterfaceManager
    {
        private readonly IUserInterfaceManager _parentUI;
        private string _connectionString;

        public ColorChanger(IUserInterfaceManager parentUI, string connectionString)
        {
            _parentUI = parentUI;
            _connectionString = connectionString;
        }

        public IUserInterfaceManager Execute()
        {
            Console.WriteLine("Background Color Selector");
            Console.WriteLine(" 1) Black");
            Console.WriteLine(" 2) Dark Blue");
            Console.WriteLine(" 3) Dark Green");
            Console.WriteLine(" 4) Dark Red");
            Console.WriteLine(" 5) Dark Gray");
            Console.WriteLine(" 0) Go Back");

            Console.Write("> ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":

                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Press any key to continue");
                    Console.ReadKey();
                    return this;
                case "2":
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    return this;
                case "3":
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Press any key to continue");
                    Console.ReadKey();
                    return this;
                case "4":
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Press any key to continue");
                    Console.ReadKey();
                    return this;
                case "5":
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Press any key to continue");
                    Console.ReadKey();
                    return this;
                case "0":
                    return _parentUI;
                default:
                    Console.WriteLine("Invalid Selection");
                    return this;
            }
        }
    }
}