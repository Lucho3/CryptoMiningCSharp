using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoMiningCNew.ModelIntrefaces;

namespace CryptoMiningCNew.Models.AbstractModels
{
    abstract class VideoCard : Component, IVideoCard
    {
        public int RAM { get; set; }
        public double MinedMoneyPerHour { get; set; }

        public VideoCard(string model, decimal price, int generation, int ram)
            : base(model, price, generation, ram * generation * 10)
        {
            if (ram < 0 || ram > 32)
            {
                throw new ArgumentException("The RAM shall be >= 0 and <= 32");
            }

            this.RAM = ram;
            this.MinedMoneyPerHour = (double)ram * generation / 10;
        }

        public override string ToString()
        {
            //The idea here is to do not create new string on every + with normal string
            var sb = new StringBuilder();
            sb.AppendLine("Video Card Details:");
            sb.AppendLine($"  Model: {Model}");
            sb.AppendLine($"  Price: {Price:C}");
            sb.AppendLine($"  Generation: {Generation}");
            sb.AppendLine($"  Life Working Hours: {LifeWorkingHours}");
            sb.AppendLine($"  RAM: {RAM} GB");
            sb.AppendLine($"  Mined Money Per Hour: ${MinedMoneyPerHour:F2}");

            return sb.ToString();
        }
    }
}
