using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.Exception
{
    public class FileHandlingException
    {
        public static void ReadPetDataFromFile(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException("The specified file was not found.", filePath);
                }

                string[] petData = File.ReadAllLines(filePath);
                if (petData.Length == 0)
                {
                    throw new InvalidOperationException("The file is empty.");
                }

                Console.WriteLine("Pet data read from file:");
                foreach (var line in petData)
                {
                    Console.WriteLine(line);
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"File handling error: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"File handling error: {ex.Message}");
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
    }


}


