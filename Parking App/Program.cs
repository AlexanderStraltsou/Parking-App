
namespace ParkingApp
{
class TestClass
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome To Prague Castle Parking");
            Console.WriteLine();

            string[] parkingGarage = new string[100];
            

            
            
            Console.WriteLine("1. Park A New Vehicle");
            Console.WriteLine("2. Move Vehicle To Another Spot");
            Console.WriteLine("3. Remove Vehicle From Parking");
            Console.WriteLine("4. Find A Vehicle");
            Console.WriteLine("5. Exit");
            Console.WriteLine();
            Console.WriteLine("Choose Your Option By Typing In A Number And Click ENTER");
            
            string option = Console.ReadLine();


            switch (option)
            {
                
                case "1":
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

        
            Console.WriteLine();
            Console.WriteLine();

        }
    }

}

