using ClaimsRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Claims_Console
{
    class ProgramUI
    {
        private ClaimsRepo _claimsRepo = new ClaimsRepo();

        public void Run()
        {

            Menu();
        }

        public void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {

                Console.WriteLine("Select a menu option:\n" +
                    "1. See all claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter new claim\n" +
                    "4. Exit Application");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        SeeAllClaims();
                        break;
                    case "2":
                        TakeCareOfNextClaim();
                        break;
                    case "3":
                        AddNewClaim();
                        break;
                    case "4":
                        Console.WriteLine("exiting");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;

                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void AddNewClaim()
        {
            Console.Clear();
            Claims newClaim= new Claims();

            Console.WriteLine("Enter the claim ID number..");
            string numberAsString = Console.ReadLine();
            newClaim.ClaimID = int.Parse(numberAsString);

            Console.WriteLine("Enter the claim type...");
            Console.WriteLine("Enter the type of claim:\n" +
               "1. Car\n" +
               "2. Home\n" +
               "3. Theft\n");

            string claimAsString = Console.ReadLine();
            int claimAsInt = int.Parse(claimAsString);
            newClaim.TypeOfClaim = (ClaimType)claimAsInt;

            Console.WriteLine("Enter description...");
            newClaim.Description = Console.ReadLine();

            Console.WriteLine("Enter the claim amount.. (please exclude $)");
            string priceAsString = Console.ReadLine();
            newClaim.ClaimAmount = decimal.Parse(priceAsString);

            Console.WriteLine("Enter the date of incident...(MM/dd/yyyy)");
            string dateAsString = Console.ReadLine();
            newClaim.DateOfIncident = DateTime.Parse(dateAsString);

            Console.WriteLine("Enter the date the claim was filed...MM/dd/yyyy");
            string input = Console.ReadLine();
            newClaim.DateOfClaim = DateTime.Parse(input);
            

            Console.WriteLine("Is this claim valid (y/n)");
            string isValidString = Console.ReadLine().ToLower();

            if (isValidString == "y")
            {
                newClaim.IsValid = true;
            }
            else
            {
                newClaim.IsValid = false;
            }

            _claimsRepo.AddClaimToList(newClaim);
        }

        private void TakeCareOfNextClaim()
        {
            Queue<Claims> queueOfClaims = _claimsRepo.ViewAllClaims();
            Claims claim = queueOfClaims.Peek();
            Console.WriteLine($"Claim ID:{claim.ClaimID}, " +
                $"\nType of Claim: {claim.TypeOfClaim}, " +
                $"\nDescription: {claim.Description}," +
                $"\nClaim Amount: {claim.ClaimAmount}, " +
                $"\nDate of Incident: {claim.DateOfIncident.Date.ToString("d")}, " +
                $"\nDate of Claim{claim.DateOfClaim.Date.ToString("d")}, " +
                $"\nIs Valid: {claim.IsValid}");

            Console.WriteLine($"\n Would you like to take care of this claim Y/N?");
            string input = Console.ReadLine().ToLower();

           if(input == "y")
            {
                queueOfClaims.Dequeue();
            }
           else
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }


        }

        private void SeeAllClaims()
        {
            Console.Clear();
            Queue<Claims> queueOfClaims = _claimsRepo.ViewAllClaims();

            foreach(Claims claim in queueOfClaims)
            {
                Console.WriteLine($"Claim ID\t" +  "Claim Type\t" + "Description\t" + "Claim Amount\t" + "Date of Incident\t" + "Date of Claim\t" + "Is Claim Valid\t");
                Console.WriteLine($"{claim.ClaimID}\t\t"              + $"{claim.TypeOfClaim}\t\t"           + $"{claim.Description}\t\t"             + $"{claim.ClaimAmount}\t\t"           + $"{claim.DateOfIncident.Date.ToString("d")}\t\t"           + $"{claim.DateOfClaim.Date.ToString("d")}\t\t"          + $"{ claim.IsValid}\t\t");
            }

        }

    }
}

