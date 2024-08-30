﻿
namespace ParkingApp
{
class Parking
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome To Prague Castle Parking");
            Console.WriteLine();

            string[] parkingGarage = new string[100];

            ShowMenu(parkingGarage);


        }

        static void ShowMenu(string[] parkingGarage)
        {

            string option = "0";
            //while (option != "5")
            //{


            Console.WriteLine("1. Park A New Vehicle");
            Console.WriteLine("2. Move Vehicle To Another Spot");
            Console.WriteLine("3. Remove Vehicle From Parking");
            Console.WriteLine("4. Find A Vehicle");
            Console.WriteLine("5. Exit");
            Console.WriteLine();
            Console.WriteLine("Choose Your Option By Typing In A Number And Click ENTER");

            option = Console.ReadLine();


            switch (option)
            {

                case "1":
                    ParkVehicle(parkingGarage);
                    break;


                case "2":
                    break;


                case "3":
                    break;

                case "4":
                    break;

                case "5":
                    break;


                default:
                    Console.WriteLine("Wrong option, try again");
                    
                    break;
            }
            //}


            Console.WriteLine();
            Console.WriteLine();
            
        }

        static void ParkVehicle(string[] parkingGarage)
        {
            Console.WriteLine("Choose Vehicle Type By Type In A Number:");
            Console.WriteLine();
            Console.WriteLine("1. CAR");
            Console.WriteLine("2. MC");
            Console.WriteLine();
            string vehicleTypeChoice = Console.ReadLine();

            string vehicleType = "";
            switch (vehicleTypeChoice)
            {
                case "1":
                    vehicleType = "CAR";
                    break;
                case "2":
                    vehicleType = "MC";
                    break;
                default:
                    Console.WriteLine("Wrong Number, Try Again!");
                    return;
            }

            Console.WriteLine("Type In Registration Number");
            string vehicleRegNumber = Console.ReadLine();

            string vehicle = $"{vehicleType}#{vehicleRegNumber}";

            for (int i = 0; i < parkingGarage.Length; i++)
            {
                if (parkingGarage[i] == null)
                {
                    parkingGarage[i] = vehicle;
                    Console.WriteLine($"Vehicle {vehicle} Parked On The Spot Number {i + 1}.");
                    Console.WriteLine("Press ENTER To Return To The Main Menu");
                    Console.ReadKey();
                    Console.WriteLine();
                    Console.WriteLine();
                    ShowMenu(parkingGarage);
                    return;
                }
            }

            ShowMenu(parkingGarage);

            Console.WriteLine("No Available Spots Left");
        }
    }

}

