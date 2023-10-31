using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoMiningCNew.StaticHelpers;

namespace CryptoMiningCNew
{
    class Program
    {
        static int SetGlobalMenu()
        {
            Console.Clear();
            Console.WriteLine("Main Menu:");
            Console.WriteLine("0. Create user.");
            Console.WriteLine("1. Buy computer for user");
            Console.WriteLine("2. Mine");
            Console.WriteLine("3. User Info");
            Console.WriteLine("4. Shutdown");

            string choice = Console.ReadLine();
            return int.Parse(choice);
        }

        static void Main(string[] args)
        {
            IController controller = new Controller();

            while (true)
            {
                switch (SetGlobalMenu())
                {
                    case 0:
                        controller.CreateUser();
                        Console.ReadLine();
                        break;
                    case 1:
                        controller.InitializeComputer();
                        Console.ReadLine();
                        break;
                    case 2:
                        controller.Mine();
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.Clear();
                        Console.Write("Enter username: ");
                        var username = Console.ReadLine();
                        controller.UserInfo(username);
                        Console.ReadLine();
                        break;
                    case 4:
                        controller.Shutdown();
                        Console.ReadLine();
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
        }
    }
}
