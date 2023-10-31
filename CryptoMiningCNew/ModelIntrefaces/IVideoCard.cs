using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMiningCNew.ModelIntrefaces
{
    interface IVideoCard
    {
        int RAM { get; set; }
        decimal MinedMoneyPerHour { get; set; }
    }
}
