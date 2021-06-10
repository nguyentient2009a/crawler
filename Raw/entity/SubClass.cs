using System;

namespace Raw.entity
{
    public class SubClass: AbstractAnimal
    {
        public override void SaySomething()
        {
            Console.WriteLine("Say theo cách của bạn!");
        }
    }
}