using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoMiningCNew.Models;
using CryptoMiningCNew.Models.AbstractModels;
using CryptoMiningCNew.StaticHelpers;

namespace CryptoMiningCNew
{
    class Controller : IController
    {
        public decimal MinedAmount { get; set; }
        public List<User> Users { get; set; }

        public Controller()
        {
            MinedAmount = 0;
            Users = new List<User>();
        }

        //LINQ zaqvchica heheh bqh gi zbarvil polzvat se mnogo s entity framework
        private User CheckName(string name)
        {
            User foundUser = this.Users.FirstOrDefault(user => user.Name == name);
            return foundUser;
        }

        private void RegisterUser(string name, decimal money)
        {
            Console.Clear();
            //bavno moje optimizacii ama  tuk ne ni trqbvat
            User existingUser = CheckName(name);
            if (existingUser != null)
            {
                Console.WriteLine("User exists!");
            }
            else
            {
                try
                {
                    User newUser = new User(name, money);
                    Users.Add(newUser);
                    Console.WriteLine("User registered: " + name + "!");
                }
                catch (ArgumentException ex)
                {
                    Console.Error.WriteLine("Invalid argument: " + ex.Message);
                }
            }
        }

        public void CreateUser()
        {
            this.GetUserInput(out string name, "name", "Name");
            this.GetUserInput(out decimal money, "money", "Money");
            this.RegisterUser(name, money);
        }

        public void Mine()
        {
            decimal minedMoney;
            Console.Clear();

            foreach (var user in this.Users)
            {
                try
                {
                    minedMoney = user.Computer.MinedAmountPerHour * 24;
                    user.IncreaseMoney(minedMoney);
                    this.MinedAmount += minedMoney;
                    user.Computer.Processor.DrainLife(24);
                    user.Computer.VideoCard.DrainLife(24);
                    Console.WriteLine("Mined amount: " + minedMoney);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Invalid argument: " + ex.Message);
                }
            }

            Console.WriteLine("Profits: " + this.MinedAmount + "!");

        }

        public void UserInfo(string name)
        {
            Console.Clear();
            User user = this.CheckName(name);
            Console.WriteLine(user != null ? user.ToString() : "Unknown user!");
        }

        public void Shutdown()
        {
            Console.Clear();
            this.Users.ForEach(us => Console.WriteLine(us.ToString()));
        }

        public void CreateComputer(string name, string procType, string procModel, int procGen, decimal procPrice, string videoType, string videoModel, int videoGen, int RAM, decimal videoPrice)
        {
            Console.Clear();
            try
            {
                User user = CheckName(name);
                if (user == null)
                {
                    Console.WriteLine("User doesn't exist!");
                    return;
                }

                decimal moneyForPC = procPrice + videoPrice;

                if (user.Money > moneyForPC)
                {
                    user.DecreaseMoney(moneyForPC);

                    Processor prc = Common.ProcessorFactory(procType, procModel, procPrice, procGen);
                    VideoCard vc = Common.VideoCardFactory(videoType, videoModel, videoPrice, videoGen, RAM);
                    Computer cmp = new Computer(prc, vc, 16);

                    user.Computer = cmp;

                    Console.WriteLine("Computer assigned to the user!");
                }
                else
                {
                    Console.WriteLine("Not enough money!");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("The computer wasn't created!" + ex.Message);
            }
        }

        public void InitializeComputer()
        {
            Console.Clear();

            this.GetUserInput(out string name, "name", "Name");
            this.GetUserInput(out string procType, "processor type", "Proc");
            this.GetUserInput(out string procModel, "processor model", "Model");
            this.GetUserInput(out int genP, "processor generation", "ProcessorGen");
            this.GetUserInput(out decimal priceP, "processor price", "Price");
            this.GetUserInput(out string videoType, "video card type", "Video");
            this.GetUserInput(out string videoModel, "video card model", "Model");
            this.GetUserInput(out int genV, "video card generation", "Gen");
            this.GetUserInput(out int ramV, "video card RAM", "RAM");
            this.GetUserInput(out decimal priceV, "video card price", "Price");
            this.CreateComputer(name, procType, procModel, genP, priceP, videoType, videoModel, genV, ramV, priceV);
        }

        private void GetUserInput<T>(out T value, string prompt, string validationType)
        {
            Console.Clear();
            Console.Write($"Enter the {prompt}: ");
            string input = Console.ReadLine();
            value = default;

            if (typeof(T) == typeof(int))
            {
                if (int.TryParse(input, out int intValue))
                {
                    //ne e okei cast amaaa obqsneno e v common zashto
                    value = (T)(object)intValue;

                }
            }
            else if (typeof(T) == typeof(decimal))
            {
                if (decimal.TryParse(input, out decimal decimalValue))
                {
                    //ne e okei cast amaaa obqsneno e v common zashto
                    value = (T)(object)decimalValue;
                }
            }
            else if (typeof(T) == typeof(string))
            {
                //ne e okei cast amaaa obqsneno e v common zashto
                value = (T)(object)input;
            }

            Common.Validate(ref value, validationType, $"the {prompt} ");
        }
    }
}
