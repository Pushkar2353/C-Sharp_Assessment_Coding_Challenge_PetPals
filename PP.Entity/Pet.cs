using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.Entity
{
    public class Pet
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Breed { get; set; }

        public Pet(string name, int age, string breed)
        {
            Name = name;
            Age = age;
            Breed = breed;
        }

        public Pet() { }

        public override string ToString()
        {
            return $"Pet [Name={Name}, Age={Age}, Breed={Breed}]";
        }
    }
}
