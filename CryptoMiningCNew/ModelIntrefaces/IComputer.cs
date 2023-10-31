using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoMiningCNew.Models.AbstractModels;

namespace CryptoMiningCNew.ModelIntrefaces
{
    interface IComputer : IBase
    {
        Processor Processor { get; set; }
        VideoCard VideoCard { get; set; }
        int RAM { get; set; }
        decimal MinedAmountPerHour { get; set; }

    }
}
