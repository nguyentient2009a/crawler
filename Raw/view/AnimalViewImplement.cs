using System;
using Raw.controller;

namespace Raw.view
{
    public class AnimalViewImplement: AnimalView
    {
              private AnimalController _animalController = new AnimalControllerImplement();

        public void ShowAnimalMenu()
        {
            while (true)
            {
                Console.WriteLine("Animal Manager");
                Console.WriteLine("-------------------");
                Console.WriteLine("1. Create.");
                Console.WriteLine("2. Show All.");
                Console.WriteLine("3. Update.");
                Console.WriteLine("4. Delete.");
                Console.WriteLine("5. Exit.");
                Console.WriteLine("0. Change language.");
                Console.WriteLine("-------------------");
                Console.WriteLine("Enter your choice (1-5): ");
                var choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        _animalController.CreateAnimal();
                        break;
                    case 2:
                        _animalController.ShowAllAnimal();
                        break;
                    case 3:
                        _animalController.UpdateAnimal();
                        break;
                    case 4:
                        _animalController.DeleteAnimal();
                        break;
                    case 5:
                        Console.WriteLine("Bye bye.");
                        break;
                    case 0:
                        Console.WriteLine("Please choose your language: 1. English | 2. Vietnamese.");
                        var languageChoice = Convert.ToInt32(Console.ReadLine());
                        if (languageChoice == 1)
                        {
                            _animalController = new AnimalControllerImplement();
                        }else if (languageChoice == 2)
                        {
                            _animalController = new AnimalControllerVnImplement();
                        }
                        break;
                    default:
                        Console.WriteLine("Wrong choice. Must be 1-5.");
                        break;
                }
                if (choice == 5)
                {
                    break;
                }
                Console.ReadLine();
            }
        }
    }
}