using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.Entity
{
    public class PetShelter : IAdoptable
    {
        public List<Pet> AvailablePets { get; private set; } = new List<Pet>();

        public void AddPet(Pet pet)
        {
            AvailablePets.Add(pet);
        }

        public void RemovePet(Pet pet)
        {
            AvailablePets.Remove(pet);
        }

        public void ListAvailablePets()
        {
            if (AvailablePets.Count == 0)
            {
                Console.WriteLine("No pets available for adoption.");
                return;
            }

            foreach (var pet in AvailablePets)
            {
                Console.WriteLine(pet.ToString());
            }
        }

        public void Adopt()
        {
            Console.WriteLine("Pet has been adopted.");
        }
    }
}



