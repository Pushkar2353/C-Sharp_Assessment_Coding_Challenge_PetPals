using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.Entity
{
    public class PetShelter : IAdoptable
    {
        // Property to hold available pets
        public List<Pet> AvailablePets { get; private set; } = new List<Pet>();

        // Method to add a pet to the shelter
        public void AddPet(Pet pet)
        {
            AvailablePets.Add(pet);
        }

        // Method to remove a pet from the shelter
        public void RemovePet(Pet pet)
        {
            AvailablePets.Remove(pet);
        }

        // Method to list all available pets
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

        // Implementation of the Adopt method from IAdoptable
        public void Adopt()
        {
            // Adoption logic (not implemented in this example)
            Console.WriteLine("Pet has been adopted.");
        }
    }
}



