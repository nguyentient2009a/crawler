using System;
using Raw.entity;
using Raw.model;

namespace Raw.controller
{
    public class AnimalControllerImplement: AnimalController
    {
        private AnimalModel _animalModel = new AnimalModelMySQLImplement();
        public void CreateAnimal()
        {
            Console.WriteLine("Enter information.");
            Console.WriteLine("Id: ");
            var id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Name: ");
            var name = Console.ReadLine();
            var animal = new Animal
            {
                Id = id,
                Name = name
            };
            _animalModel.Save(animal);
        }

        public void ShowAllAnimal()
        {
            var list =  _animalModel.FindAll();
            foreach (var animal in list)
            {
                Console.WriteLine($"Animal, id: {animal.Id}, name: {animal.Name}");
            }
        }

        public void UpdateAnimal()
        {
            Console.WriteLine("Enter id to update: ");
            var id = Convert.ToInt32(Console.ReadLine());
            var existAnimal =  _animalModel.FindById(id);
            if (existAnimal == null)
            {
                Console.WriteLine("Not found.");
                return;
            }
            Console.WriteLine($"Found animal with name: {existAnimal.Name}");
            Console.WriteLine("Enter new name: ");
            var name = Console.ReadLine();
            var updateAnimal = new Animal
            {
                Name =  name
            };
            bool result = _animalModel.Update(id, updateAnimal);
            if (result)
            {
                Console.WriteLine("Update success!");
            }
            else
            {
                Console.WriteLine("Update fails! Please try later!");
            }
        }

        public void DeleteAnimal()
        {
            Console.WriteLine("Enter id to delete: ");
            var id = Convert.ToInt32(Console.ReadLine());
            var existAnimal =  _animalModel.FindById(id);
            if (existAnimal == null)
            {
                Console.WriteLine("Not found.");
                return;
            }
            Console.WriteLine($"Found animal with name: {existAnimal.Name}");
            Console.WriteLine("Are you sure (y/n) ?");
            var answer = Console.ReadLine();
            if (answer.ToLower().Equals("y"))
            {
                bool result = _animalModel.Delete(id);
                if (result)
                {
                    Console.WriteLine("Action success!");
                }
                else
                {
                    Console.WriteLine("Action fails! Please try later!");
                }
            }
        }
    }
}