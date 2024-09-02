
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
            while (true)
            {
                string option = "0";



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
                        Environment.Exit(0);
                        break;


                    default:
                        Console.WriteLine("Wrong option, try again");

                        break;
                }



                Console.WriteLine();
                Console.WriteLine();

            }
            
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

            Console.WriteLine("Type In Registration Number (6 Characters)");
            string vehicleRegNumber = Console.ReadLine();

            string vehicle = $"{vehicleType}#{vehicleRegNumber}";

            for (int i = 0; i < parkingGarage.Length; i++)
            {
                if (vehicleType == "CAR")
                {
                    if (parkingGarage[i] == null)
                    {
                        parkingGarage[i] = vehicle;
                        Console.WriteLine($"Vehicle {vehicle} Parked On Spot Number {i + 1}.");
                        Console.WriteLine("Press ENTER To Return To The Main Menu");
                        Console.ReadKey();
                        Console.WriteLine();
                        Console.WriteLine();
                        ShowMenu(parkingGarage);
                        return;
                    }
                }
                else if (vehicleType == "MC")
                {
                    if (parkingGarage[i] == null)
                    {
                        parkingGarage[i] = vehicle;
                        Console.WriteLine($"Vehicle {vehicle} Parked On Spot Number {i + 1}.");
                        Console.WriteLine("Press ENTER To Return To The Main Menu");
                        Console.ReadKey();
                        Console.WriteLine();
                        Console.WriteLine();
                        ShowMenu(parkingGarage);
                        return;
                    }
                    else if (parkingGarage[i].StartsWith("MC") && !parkingGarage[i].Contains("|"))
                    {
                        parkingGarage[i] = string.Join("|", parkingGarage[i], vehicle);
                        Console.WriteLine($"Vehicle {vehicle} Parked On Spot Number {i + 1} (sharing with another MC).");
                        Console.WriteLine("Press ENTER To Return To The Main Menu");
                        Console.ReadKey();
                        Console.WriteLine();
                        Console.WriteLine();
                        ShowMenu(parkingGarage);
                        return;
                    }
                }
            }

            ShowMenu(parkingGarage);

            Console.WriteLine("No Available Spots Left");
        }


        static void RemoveVehicle(string[] parkingGarage)
        {
            ShowParkingSpots(parkingGarage);

            Console.WriteLine("Choose Nn Option To Remove A Vehicle:");
            Console.WriteLine("1. By Spot Number");
            Console.WriteLine("2. By Registration Number");
            string removeOption = Console.ReadLine();

            switch (removeOption)
            {
                case "1":
                    Console.WriteLine("Enter the Spot Number:");
                    if (int.TryParse(Console.ReadLine(), out int spotNumber) && spotNumber > 0 && spotNumber <= parkingGarage.Length)
                    {
                        if (parkingGarage[spotNumber - 1] != null)
                        {
                            if (parkingGarage[spotNumber - 1].Contains("|"))
                            {
                                Console.WriteLine("This spot contains multiple vehicles. Enter the registration number of the vehicle to remove:");
                                string regNumber = Console.ReadLine();
                                string[] vehicles = parkingGarage[spotNumber - 1].Split('|');
                                if (vehicles[0].Contains(regNumber))
                                {
                                    parkingGarage[spotNumber - 1] = vehicles[1];
                                }
                                else if (vehicles[1].Contains(regNumber))
                                {
                                    parkingGarage[spotNumber - 1] = vehicles[0];
                                }
                                else
                                {
                                    Console.WriteLine("No vehicle found with this registration number in the selected spot.");
                                }
                            }
                            else
                            {
                                parkingGarage[spotNumber - 1] = null;
                                Console.WriteLine($"Vehicle removed from Spot Number {spotNumber}.");
                            }
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
                    Console.WriteLine("Enter the Registration Number (6 Characters):");
                    string regNumberToRemove = Console.ReadLine();
                    bool vehicleFound = false;

                    for (int i = 0; i < parkingGarage.Length; i++)
                    {
                        if (parkingGarage[i] != null && parkingGarage[i].Contains(regNumberToRemove))
                        {
                            if (parkingGarage[i].Contains("|"))
                            {
                                string[] vehicles = parkingGarage[i].Split('|');
                                if (vehicles[0].Contains(regNumberToRemove))
                                {
                                    parkingGarage[i] = vehicles[1];
                                }
                                else
                                {
                                    parkingGarage[i] = vehicles[0];
                                }
                            }
                            else
                            {
                                parkingGarage[i] = null;
                            }
                            Console.WriteLine($"Removing vehicle with Registration Number {regNumberToRemove} from Spot Number {i + 1}");
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

            Console.WriteLine("Choose an option to move a vehicle:");
            Console.WriteLine("1. By Spot Number");
            Console.WriteLine("2. By Registration Number");
            string moveOption = Console.ReadLine();

            string vehicle = null;
            int fromSpotNumber = -1;

            if (moveOption == "1")
            {
                Console.WriteLine("Enter the Spot Number of the vehicle you want to move:");
                if (int.TryParse(Console.ReadLine(), out fromSpotNumber) && fromSpotNumber > 0 && fromSpotNumber <= parkingGarage.Length)
                {
                    if (parkingGarage[fromSpotNumber - 1] != null)
                    {
                        vehicle = parkingGarage[fromSpotNumber - 1];

                        
                        if (vehicle.Contains("|"))
                        {
                            string[] vehicles = vehicle.Split('|');
                            Console.WriteLine($"Spot {fromSpotNumber} contains two vehicles:");
                            Console.WriteLine($"1. {vehicles[0]}");
                            Console.WriteLine($"2. {vehicles[1]}");
                            Console.WriteLine("Select the vehicle you want to move (1 or 2):");
                            string choice = Console.ReadLine();

                            if (choice == "1")
                            {
                                vehicle = vehicles[0];
                                parkingGarage[fromSpotNumber - 1] = vehicles[1]; 
                            }
                            else if (choice == "2")
                            {
                                vehicle = vehicles[1];
                                parkingGarage[fromSpotNumber - 1] = vehicles[0]; 
                            }
                            else
                            {
                                Console.WriteLine("Invalid choice.");
                                return;
                            }
                        }
                        else
                        {
                            parkingGarage[fromSpotNumber - 1] = null;
                        }
                    }
                    else
                    {
                        Console.WriteLine("No vehicle found in the specified spot.");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Spot Number.");
                    return;
                }
            }
            else if (moveOption == "2")
            {
                Console.WriteLine("Enter the Registration Number of the vehicle you want to move:");
                string regNumber = Console.ReadLine();
                for (int i = 0; i < parkingGarage.Length; i++)
                {
                    if (parkingGarage[i] != null && parkingGarage[i].Contains(regNumber))
                    {
                        string[] vehicles = parkingGarage[i].Split('|');
                        if (vehicles.Length == 2)
                        {
                            if (vehicles[0].Contains(regNumber))
                            {
                                vehicle = vehicles[0];
                                parkingGarage[i] = vehicles[1]; 
                            }
                            else
                            {
                                vehicle = vehicles[1];
                                parkingGarage[i] = vehicles[0]; 
                            }
                        }
                        else
                        {
                            vehicle = parkingGarage[i];
                            parkingGarage[i] = null;
                        }

                        fromSpotNumber = i + 1;
                        break;
                    }
                }

                if (vehicle == null)
                {
                    Console.WriteLine("No vehicle found with this registration number.");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Invalid option.");
                return;
            }

            Console.WriteLine($"Vehicle {vehicle} is currently parked at spot {fromSpotNumber}.");

            Console.WriteLine("Enter the Spot Number where you want to move the vehicle:");
            if (int.TryParse(Console.ReadLine(), out int toSpotNumber) && toSpotNumber > 0 && toSpotNumber <= parkingGarage.Length)
            {
                if (parkingGarage[toSpotNumber - 1] == null)
                {
                    parkingGarage[toSpotNumber - 1] = vehicle;
                    Console.WriteLine($"Vehicle {vehicle} has been moved to Spot Number {toSpotNumber}.");
                }
                else if (vehicle.StartsWith("MC") && parkingGarage[toSpotNumber - 1].StartsWith("MC") && !parkingGarage[toSpotNumber - 1].Contains("|"))
                {
                   
                    parkingGarage[toSpotNumber - 1] = string.Join("|", parkingGarage[toSpotNumber - 1], vehicle);
                    Console.WriteLine($"Vehicle {vehicle} has been moved to Spot Number {toSpotNumber} (sharing with another MC).");
                }
                else
                {
                    Console.WriteLine("The destination spot is already occupied.");
                   
                    parkingGarage[fromSpotNumber - 1] = vehicle;
                }
            }
            else
            {
                Console.WriteLine("Invalid Spot Number for destination.");
               
                parkingGarage[fromSpotNumber - 1] = vehicle;
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
                        Console.WriteLine("No Vehicle Found With This Registration Number.");
                    }
                    break;

                case "3":

                    ShowParkingSpots(parkingGarage);

                    break;

                default:
                    Console.WriteLine("Invalid Option.");
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
            Console.WriteLine();
            Console.WriteLine("Current Parking Garage Status:");
            Console.WriteLine();
            for (int i = 0; i < parkingGarage.Length; i++)
            {
                Console.WriteLine($"Spot {i + 1}: {(parkingGarage[i] != null ? parkingGarage[i] : "Empty")}");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }

}

