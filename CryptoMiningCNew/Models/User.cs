using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoMiningCNew.ModelIntrefaces;

namespace CryptoMiningCNew.Models
{
    class User : IUser
    {
        public string Name { get; set; } 
        public int Stars { get; set; }
        public decimal Money { get; set; }
        public Computer Computer { get; set; }

        public User(string name, decimal money)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("The name shall not be empty!");
            }
            if (money < 0)
            {
                throw new ArgumentException("The money shall not be lower than 0");
            }

            this.Name = name;
            this.Money = money;
            this.Stars = (int)money / 100;
        }

        public void DecreaseMoney(decimal money)
        {
            Money -= money;
        }

        public void IncreaseMoney(decimal money)
        {
            Money += money;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("User Details:");
            sb.AppendLine($"Name: {Name}");
            sb.AppendLine($"Stars: {Stars}");
            sb.AppendLine($"Money: ${Money:F2}");

            if (Computer != null)
            {
                sb.Append(Computer.ToString());
            }

            return sb.ToString();
        }
    }
}
