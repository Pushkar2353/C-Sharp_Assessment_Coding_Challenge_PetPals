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
        static void Main(string[] args)
        {
            string connectionString = "Server=.\\sqlexpress;Database=PP;Integrated Security=true;";
            try
            {
                using (SqlConnection conn = DBConnUtil.GetConnection(connectionString))
                {
                    Console.WriteLine("Connection successful!");
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

            PetShelter shelter = new PetShelter();
            AdoptionEvent adoptionEvent = new AdoptionEvent();

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

            Console.WriteLine("\nListing available pets:");
            shelter.ListAvailablePets();

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

                CashDonation cashDonation = new CashDonation(donorName, donationAmount);
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

            string filePath = "appsettings.json";
            FileHandlingException.ReadPetDataFromFile(filePath);

            Console.WriteLine("\nEnd of the Pet Adoption Platform Demo.");

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

                CashDonation donation = new CashDonation(donorName, amount);
                DonationDao donationDao = new DonationDao(connectionString);
                donationDao.RecordDonation(donation);
                Console.WriteLine("Donation recorded successfully.");
            }
            catch (DatabaseException ex)
            {
                Console.WriteLine(ex.Message);
            }

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
                Console.Write("Enter the Pet ID you want to register for: ");
                int petId = int.Parse(Console.ReadLine());

                adoptionEventDao.RegisterParticipant(eventId, participantName, shelterId, petId);
                Console.WriteLine("Registered for the event successfully.");
            }
            catch (DatabaseException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}



           


