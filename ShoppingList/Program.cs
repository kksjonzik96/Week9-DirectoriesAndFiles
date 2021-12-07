using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateFile();
        }

        static public void CreateFile()
        {
            string rootDirectory = @"D:\Programmeerimise algkursus (RKE132)\FunctionsReturnAndArraysFromFile\nadal 8";
            Console.WriteLine("Enter directory name:");
            string newDirectory = Console.ReadLine();
            Console.WriteLine("Enter file name:");
            string fileName = Console.ReadLine();

            if (Directory.Exists($"{rootDirectory}\\{newDirectory}") && File.Exists($"{rootDirectory}\\{newDirectory}\\{fileName}"))
            {
                Console.WriteLine($"Directory and File exist.");
            }
            else
            {
                Directory.CreateDirectory($"{rootDirectory}\\{newDirectory}");
                File.Create($"{rootDirectory}\\{newDirectory}\\{fileName}");
                
            }
            CreateList(rootDirectory, newDirectory, fileName);
            
        }
        static public void CreateList(string rootDir, string  dir, string file )
        {
            
            string first = rootDir + $@"\\{dir}";
            string last = $@"\\{file}.txt";

            string[] arrayFromFile = File.ReadAllLines($"{first}{last}");
            List<string> myList = arrayFromFile.ToList<string>();

            bool loopActive = true;

            while (loopActive)
            {
                Console.WriteLine("Would you like to add a item? Y/N:");
                char userInput = Convert.ToChar(Console.ReadLine().ToLower());

                if (userInput == 'y')
                {
                    Console.WriteLine("Enter item for buying :");
                    string userList = Console.ReadLine();
                    myList.Add(userList);
                }
                else
                {
                    loopActive = false;
                    Console.WriteLine("Take care!");
                }
            }

            Console.Clear();
            foreach (string wish in myList)
            {
                Console.WriteLine($"Your wish: {wish}");
            }

            File.WriteAllLines($"{rootDir}{first}{last}", List);
        }


    }
}
