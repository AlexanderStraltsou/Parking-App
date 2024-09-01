
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
                    MoveVehicle(parkingGarage);
                    break;


                case "3":
                    RemoveVehicle(parkingGarage);
                    break;

                case "4":
                    FindVehicle(parkingGarage);
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

        static void RemoveVehicle(string[] parkingGarage)
        {

            ShowParkingSpots(parkingGarage);

            Console.WriteLine("Choose an option to remove a vehicle:");
            Console.WriteLine("1. By Spot Number");
            Console.WriteLine("2. By Registration Number");
            string removeOption = Console.ReadLine();

            switch (removeOption)
            {
                case "1":
                    Console.WriteLine("Enter the Spot Number:");
                    int spotNumber;
                    if (int.TryParse(Console.ReadLine(), out spotNumber) && spotNumber > 0 && spotNumber <= parkingGarage.Length)
                    {
                        if (parkingGarage[spotNumber - 1] != null)
                        {
                            Console.WriteLine($"Removing vehicle from Spot Number {spotNumber}");
                            parkingGarage[spotNumber - 1] = null;
                            Console.WriteLine("Press ENTER To Return To The Main Menu");
                            Console.ReadKey();
                            Console.WriteLine();
                            Console.WriteLine();
                            ShowMenu(parkingGarage);
                        }
                        else
                        {
                            Console.WriteLine("No vehicle found in this spot.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Spot Number.");
                    }
                    break;

                case "2":
                    Console.WriteLine("Enter the Registration Number:");
                    string regNumber = Console.ReadLine();
                    bool vehicleFound = false;

                    for (int i = 0; i < parkingGarage.Length; i++)
                    {
                        if (parkingGarage[i] != null && parkingGarage[i].Contains(regNumber))
                        {
                            Console.WriteLine($"Removing vehicle with Registration Number {regNumber} from Spot Number {i + 1}");
                            parkingGarage[i] = null;
                            vehicleFound = true;
                            Console.WriteLine("Press ENTER To Return To The Main Menu");
                            Console.ReadKey();
                            Console.WriteLine();
                            Console.WriteLine();
                            ShowMenu(parkingGarage);
                            break;
                        }
                    }

                    if (!vehicleFound)
                    {
                        Console.WriteLine("No vehicle found with this registration number.");
                    }
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    Console.WriteLine("Press ENTER To Return To The Main Menu");
                    Console.ReadKey();
                    Console.WriteLine();
                    Console.WriteLine();
                    ShowMenu(parkingGarage);
                    break;
            }
        }

        static void MoveVehicle(string[] parkingGarage)
        {
            ShowParkingSpots(parkingGarage);

            Console.WriteLine("Enter the Spot Number of the vehicle you want to move:");
            int fromSpotNumber;
            if (int.TryParse(Console.ReadLine(), out fromSpotNumber) && fromSpotNumber > 0 && fromSpotNumber <= parkingGarage.Length)
            {
                if (parkingGarage[fromSpotNumber - 1] != null)
                {
                    string vehicle = parkingGarage[fromSpotNumber - 1];

                    Console.WriteLine($"Vehicle {vehicle} is currently parked at spot {fromSpotNumber}.");

                    Console.WriteLine("Enter the Spot Number where you want to move the vehicle:");
                    int toSpotNumber;
                    if (int.TryParse(Console.ReadLine(), out toSpotNumber) && toSpotNumber > 0 && toSpotNumber <= parkingGarage.Length)
                    {
                        if (parkingGarage[toSpotNumber - 1] == null)
                        {
                            parkingGarage[toSpotNumber - 1] = vehicle;
                            parkingGarage[fromSpotNumber - 1] = null;

                            Console.WriteLine($"Vehicle {vehicle} has been moved to Spot Number {toSpotNumber}.");
                        }
                        else
                        {
                            Console.WriteLine("The destination spot is already occupied.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Spot Number for destination.");
                    }
                }
                else
                {
                    Console.WriteLine("No vehicle found in the specified spot.");
                }
            }
            else
            {
                Console.WriteLine("Invalid Spot Number for origin.");
            }

            Console.WriteLine("Press ENTER To Return To The Main Menu");
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine();
            ShowMenu(parkingGarage);
        }

        static void FindVehicle(string[] parkingGarage)
        {

            Console.WriteLine();
            Console.WriteLine("Choose an option to find a vehicle:");
            Console.WriteLine();
            Console.WriteLine("1. By Spot Number");
            Console.WriteLine("2. By Registration Number");
            Console.WriteLine("3. Show All Parking Spots");
            string findOption = Console.ReadLine();

            switch (findOption)
            {
                case "1":
                    Console.WriteLine("Enter the Spot Number:");
                    int spotNumber;
                    if (int.TryParse(Console.ReadLine(), out spotNumber) && spotNumber > 0 && spotNumber <= parkingGarage.Length)
                    {
                        if (parkingGarage[spotNumber - 1] != null)
                        {
                            Console.WriteLine($"Vehicle found at Spot Number {spotNumber}: {parkingGarage[spotNumber - 1]}");
                        }
                        else
                        {
                            Console.WriteLine("No vehicle found in this spot.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Spot Number.");
                    }
                    break;

                case "2":
                    Console.WriteLine("Enter the Registration Number:");
                    string regNumber = Console.ReadLine();
                    bool vehicleFound = false;

                    for (int i = 0; i < parkingGarage.Length; i++)
                    {
                        if (parkingGarage[i] != null && parkingGarage[i].Contains(regNumber))
                        {
                            Console.WriteLine($"Vehicle with Registration Number {regNumber} found at Spot Number {i + 1}: {parkingGarage[i]}");
                            vehicleFound = true;
                            break;
                        }
                    }

                    if (!vehicleFound)
                    {
                        Console.WriteLine("No vehicle found with this registration number.");
                    }
                    break;

                case "3":

                    ShowParkingSpots(parkingGarage);

                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }

            Console.WriteLine("Press ENTER To Return To The Main Menu");
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine();
            ShowMenu(parkingGarage);
        }

        static void ShowParkingSpots(string[] parkingGarage)
        {
            Console.WriteLine();
            Console.WriteLine("Current Parking Garage Status:");
            Console.WriteLine();
            for (int i = 0; i < parkingGarage.Length; i++)
            {
                Console.WriteLine($"Spot {i + 1}: {(parkingGarage[i] != null ? parkingGarage[i] : "Empty")}");
            }
            Console.WriteLine();
        }
    }

}

