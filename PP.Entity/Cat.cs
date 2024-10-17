using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.Entity
{
    public class Cat : Pet
    {
        public string CatColor { get; set; }

        public Cat(string name, int age, string breed, string catColor) : base(name, age, breed)
        {
            CatColor = catColor;
        }

        public Cat() { }
        public override string ToString()
        {
            return $"Cat [Name={Name}, Age={Age}, Breed={Breed}, CatColor={CatColor}]";
        }
    }
}


