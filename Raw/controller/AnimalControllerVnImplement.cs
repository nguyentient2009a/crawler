using System;
using Raw.entity;
using Raw.model;

namespace Raw.controller
{
    public class AnimalControllerVnImplement: AnimalController
    {
         private AnimalModel _animalModel = new AnimalModelMySQLImplement();
        public void CreateAnimal()
        {
            Console.WriteLine("Vui lòng nhập thông tin con vật.");
            Console.WriteLine("Mã: ");
            var id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Tên: ");
            var name = Console.ReadLine();
            var animal = new Animal()
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
                Console.WriteLine($"Con vật, mã: {animal.Id}, tên: {animal.Name}");
            }
        }

        public void UpdateAnimal()
        {
            Console.WriteLine("Vui lòng nhập id con vật cần update: ");
            var id = Convert.ToInt32(Console.ReadLine());
            var existAnimal =  _animalModel.FindById(id);
            if (existAnimal == null)
            {
                Console.WriteLine("Không tìm thấy.");
                return;
            }
            Console.WriteLine($"Tìm thấy vật nuôi với tên: {existAnimal.Name}");
            Console.WriteLine("Vui lòng nhập tên mới: ");
            var name = Console.ReadLine();
            var updateAnimal = new Animal
            {
                Name =  name
            };
            bool result = _animalModel.Update(id, updateAnimal);
            if (result)
            {
                Console.WriteLine("Thao tác thành công!");
            }
            else
            {
                Console.WriteLine("Thao tác thất bại, vui lòng thử lại sau.");
            }
        }

        public void DeleteAnimal()
        {
            Console.WriteLine("Vui lòng nhập id vật nuôi cần xoá: ");
            var id = Convert.ToInt32(Console.ReadLine());
            var existAnimal =  _animalModel.FindById(id);
            if (existAnimal == null)
            {
                Console.WriteLine("Không tìm thấy.");
                return;
            }
            Console.WriteLine($"Tìm thấy vật nuôi với tên: {existAnimal.Name}");
            Console.WriteLine("Bạn có chắc muốn xoá (y/n) ?");
            var answer = Console.ReadLine();
            if (answer.ToLower().Equals("y"))
            {
                bool result = _animalModel.Delete(id);
                if (result)
                {
                    Console.WriteLine("Thao tác thành công!");
                }
                else
                {
                    Console.WriteLine("Thao tác thất bại, vui lòng thử lại sau.");
                }
            }
        }
    }
}
