using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoMiningCNew.Models.AbstractModels;

namespace CryptoMiningCNew.Models
{
    class GameVideoCard:VideoCard
    {
        public GameVideoCard(string model, decimal price, int generation, int ram)
            : base(model, price, generation, ram)
        {
            if (generation > 6)
            {
                throw new ArgumentException("The generation shall be > 6");
            }

            this.MinedMoneyPerHour *= 2;
        }
    }
}
