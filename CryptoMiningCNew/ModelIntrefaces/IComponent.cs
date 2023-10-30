using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMiningCNew.ModelIntrefaces
{
    interface IComponent: IBase
    {
        string Model { get; set; }
        decimal Price { get; set; }
        int Generation { get; set; }
        int LifeWorkingHours { get; set; }
    }
}
