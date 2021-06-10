using System;
using System.Collections.Generic;
using Raw.entity;

namespace Raw.model
{
    public class AnimalModelImplement: AnimalModel
    {
        private List<Animal> _list = new List<Animal>();
        public bool Save(Animal animal)
        {
            _list.Add(animal);
            return true;
        }

        public List<Animal> FindAll()
        {
            return _list;
        }

        public Animal FindById(int id)
        {
            Animal result = null;
            for (int i = 0; i < _list.Count; i++)
            {
                var item = _list[i];
                if (item.Id.Equals(id))
                {
                    result = item;
                    break;
                }
            }
            return result;
        }

        public bool Update(int id, Animal updateAnimal)
        {
            Animal existAnimal = FindById(id);
            if (existAnimal == null)
            {
                Console.WriteLine("Not found");
                return false;
            }
            existAnimal.Name = updateAnimal.Name;
            return true;
        }

        public bool Delete(int id)
        {
            Animal existAnimal = FindById(id);
            if (existAnimal == null)
            {
                Console.WriteLine("Not found");
                return false;
            }
            _list.Remove(existAnimal);
            return true;
        }
    }
}