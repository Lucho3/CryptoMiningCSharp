using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoMiningCNew.ModelIntrefaces;

namespace CryptoMiningCNew.Models.AbstractModels
{
    abstract class Processor : Component, IProcessor
    {
        public int MineMultiplier { get; set; }

        public Processor(string model, decimal price, int generation, int mineMultiplier)
            : base(model, price, generation, generation * 100)
        {
            if (generation > 9)
            {
                throw new ArgumentException("The generation shall be <= 9!");
            }

            this.MineMultiplier = mineMultiplier;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Processor Details:");
            sb.AppendLine($"  Model: {Model}");
            sb.AppendLine($"  Price: {Price:C}");
            sb.AppendLine($"  Generation: {Generation}");
            sb.AppendLine($"  Life Working Hours: {LifeWorkingHours}");
            sb.AppendLine($"  Mine Multiplier: {MineMultiplier}");
            return sb.ToString();
        }

    }
}
