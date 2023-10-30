using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMiningCNew.ModelIntrefaces
{
    //It could inherit IComponent but will create diamond problems
    interface IProcessor 
    {
        int MineMultiplier { get; set; }
    }
}
