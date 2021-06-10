using System;

namespace Raw.entity
{
    public abstract class AbstractAnimal
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void SayHello()
        {
            Console.WriteLine("Hello world");
        }

        public abstract void SaySomething();
    }
}