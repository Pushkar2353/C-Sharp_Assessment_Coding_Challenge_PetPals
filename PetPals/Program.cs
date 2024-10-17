using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PP.Dao;
using PP.Entity;
using PP.Exception;
using PP.Util;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;



namespace PetPals
{
    class MainModule
    {
        /*
        static void Main(string[] args)
        {
            string connectionString = "Server=.\\sqlexpress;Database=PP;Integrated Security=true;";
            try
            {
                using (SqlConnection conn = DBConnUtil.GetConnection(connectionString))
                {
                    Console.WriteLine("Connection successful!");

                    // Example of counting pets
                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Pet", conn))
                    {
                        int count = (int)cmd.ExecuteScalar();
                        Console.WriteLine($"Number of pets in the database: {count}");
                    }
                }
            }
            catch (DatabaseException ex)
            {
                Console.WriteLine("Database Exception: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected Error: " + ex.Message);
            }
        }
    }
}
 */
        static void Main(string[] args)
        {
            string connectionString = "Server=.\\sqlexpress;Database=PP;Integrated Security=true;";

            // Display Pet Listings
            try
            {
                PetDao petDao = new PetDao(connectionString);
                List<Pet> availablePets = petDao.GetAvailablePets();

                Console.WriteLine("Available Pets:");
                foreach (var pet in availablePets)
                {
                    Console.WriteLine(pet.ToString());
                }
            }
            catch (DatabaseException ex)
            {
                Console.WriteLine("Database Exception: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected Error: " + ex.Message);
            }

            // Record Donation
            try
            {
                Console.Write("Enter donor name: ");
                string donorName = Console.ReadLine();
                Console.Write("Enter donation amount (in rupees): ");
                decimal amount;
                while (!decimal.TryParse(Console.ReadLine(), out amount) || amount < 10)
                {
                    Console.WriteLine("Invalid input. Please enter a donation amount of ₹10 or more.");
                }

                CashDonation donation = new CashDonation(donorName, amount); // Use the CashDonation subclass
                DonationDao donationDao = new DonationDao(connectionString);
                donationDao.RecordDonation(donation);
                Console.WriteLine("Donation recorded successfully.");
            }
            catch (DatabaseException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Adoption Event Management
            try
            {
                AdoptionEventDao adoptionEventDao = new AdoptionEventDao(connectionString);
                List<AdoptionEvent> events = adoptionEventDao.GetUpcomingEvents();

                Console.WriteLine("Upcoming Adoption Events:");
                foreach (var ev in events)
                {
                    Console.WriteLine($"{ev.EventID}: {ev.EventName}");
                }

                Console.Write("Register for an event (Enter EventID): ");
                int eventId = int.Parse(Console.ReadLine());
                Console.Write("Enter your name: ");
                string participantName = Console.ReadLine();
                Console.Write("Enter your Shelter ID: ");
                int shelterId = int.Parse(Console.ReadLine());
                Console.Write("Enter the Pet ID you want to register for: ");  // Capture PetID
                int petId = int.Parse(Console.ReadLine());

                adoptionEventDao.RegisterParticipant(eventId, participantName, shelterId, petId);  // Pass PetID here
                Console.WriteLine("Registered for the event successfully.");
            }
            catch (DatabaseException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
    /*
            static void Main(string[] args)
            {
                // Create instances of PetShelter and AdoptionEvent
                PetShelter shelter = new PetShelter();
                AdoptionEvent adoptionEvent = new AdoptionEvent();

                // Adding pets to the shelter with exception handling for age
                try
                {
                    Console.WriteLine("Enter the name of the dog:");
                    string dogName = Console.ReadLine();
                    Console.WriteLine("Enter the age of the dog (positive integer):");
                    int dogAge = Convert.ToInt32(Console.ReadLine());
                    if (dogAge <= 0)
                    {
                        throw new InvalidPetAgeException("Pet age must be a positive integer.");
                    }
                    Console.WriteLine("Enter the breed of the dog:");
                    string dogBreed = Console.ReadLine();
                    Console.WriteLine("Enter the specific breed of the dog:");
                    string dogSpecificBreed = Console.ReadLine();

                    Dog dog = new Dog(dogName, dogAge, dogBreed, dogSpecificBreed);
                    shelter.AddPet(dog);
                    Console.WriteLine("Dog added to shelter successfully.");
                }
                catch (InvalidPetAgeException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number for age.");
                }

                // Adding a cat with similar exception handling
                try
                {
                    Console.WriteLine("Enter the name of the cat:");
                    string catName = Console.ReadLine();
                    Console.WriteLine("Enter the age of the cat (positive integer):");
                    int catAge = Convert.ToInt32(Console.ReadLine());
                    if (catAge <= 0)
                    {
                        throw new InvalidPetAgeException("Pet age must be a positive integer.");
                    }
                    Console.WriteLine("Enter the breed of the cat:");
                    string catBreed = Console.ReadLine();
                    Console.WriteLine("Enter the color of the cat:");
                    string catColor = Console.ReadLine();

                    Cat cat = new Cat(catName, catAge, catBreed, catColor);
                    shelter.AddPet(cat);
                    Console.WriteLine("Cat added to shelter successfully.");
                }
                catch (InvalidPetAgeException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number for age.");
                }

                // List available pets in the shelter with null reference handling
                Console.WriteLine("\nListing available pets:");
                shelter.ListAvailablePets();

                // Make a cash donation with exception handling
                try
                {
                    Console.WriteLine("Enter donor name:");
                    string donorName = Console.ReadLine();
                    Console.WriteLine("Enter donation amount (minimum 100 Rupees):");
                    decimal donationAmount = Convert.ToDecimal(Console.ReadLine());
                    if (donationAmount < 100)
                    {
                        throw new InsufficientFundsException("Minimum donation amount is 100 Rupees.");
                    }

                    CashDonation cashDonation = new CashDonation(donorName, donationAmount, DateTime.Now);
                    cashDonation.RecordDonation();
                    Console.WriteLine("Cash donation recorded successfully.");
                }
                catch (InsufficientFundsException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid amount for donation.");
                }

                // File Handling exception demonstration
                string filePath = "pets_data.txt"; // Example file path
                FileHandlingException.ReadPetDataFromFile(filePath);

                // Rest of your main module code...
                Console.WriteLine("\nEnd of the Pet Adoption Platform Demo.");

                // Handling an adoption event with custom exception
                try
                {
                    Console.WriteLine("Registering for an adoption event...");
                    if (shelter.AvailablePets.Count == 0)
                    {
                        throw new AdoptionException("No pets available for adoption.");
                    }

                    adoptionEvent.RegisterParticipant(shelter);
                    Console.WriteLine("Shelter registered for the adoption event successfully.");
                }
                catch (AdoptionException e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine("\nEnd of the Pet Adoption Platform Demo.");
            }
        }
    */


