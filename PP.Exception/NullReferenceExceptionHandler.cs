using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PP.Entity;

namespace PP.Exception
{
    public class NullReferenceExceptionHandler
    {
        public static void HandleNullReference(Pet pet)
        {
            try
            {
                if (pet.Name == null || pet.Age == 0 || pet.Breed == null)
                {
                    throw new NullReferenceException("Some pet information is missing.");
                }
                Console.WriteLine(pet);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}


