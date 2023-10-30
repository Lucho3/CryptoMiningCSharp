using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoMiningCNew.Models;

namespace CryptoMiningCNew.ModelIntrefaces
{
    interface IUser : IBase
    {
        string Name { get; set; }
        int Stars { get; set; }
        decimal Money { get; set; }
        Computer Computer { get; set; }
        void IncreaseMoney(decimal money);
        void DecreaseMoney(decimal money);


    }
}
