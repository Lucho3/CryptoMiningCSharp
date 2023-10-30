using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoMiningCNew.ModelIntrefaces;
using CryptoMiningCNew.Models.AbstractModels;

namespace CryptoMiningCNew.Models
{
    class Computer : IComputer
    {
        public Processor Processor { get; set; }
        public VideoCard VideoCard { get; set; }
        public int RAM { get; set; }
        public double MinedAmountPerHour { get; set; }

        public Computer(Processor proc, VideoCard videoC, int RAM)
        {
            if (RAM < 0 || RAM > 32)
            {
                throw new ArgumentException("The RAM shall be between 0 and 32");
            }

            this.Processor = proc ?? throw new ArgumentException("There is no processor!");
            this.VideoCard = videoC ?? throw new ArgumentException("There is no video card!");
            this.RAM = RAM;

            this.MinedAmountPerHour = this.Processor.MineMultiplier * this.VideoCard.MinedMoneyPerHour;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Computer Details:");
            sb.AppendLine($"  RAM: {RAM} GB");
            sb.AppendLine($"  Mined Amount Per Hour: ${MinedAmountPerHour:F2}");

            if (Processor != null)
            {
                sb.Append(Processor.ToString());
            }

            if (VideoCard != null)
            {
                sb.Append(VideoCard.ToString());
            }

            return sb.ToString();
        }
    }
}

