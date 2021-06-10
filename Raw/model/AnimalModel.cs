using System.Collections.Generic;
using Raw.entity;

namespace Raw.model
{
    public interface AnimalModel
    {
        bool Save(Animal animal);
        List<Animal> FindAll();
        Animal FindById(int id);
        bool Update(int id, Animal updateAnimal);
        bool Delete(int id);
    }
}