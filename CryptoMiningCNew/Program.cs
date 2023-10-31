using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoMiningCNew.StaticHelpers;

namespace CryptoMiningCNew
{
    class Program
    {
        static void Main(string[] args)
        {
            var intValidator = Common.getDelegate<int>("ValidateGen");

            Console.WriteLine(intValidator(5));
            Console.ReadLine();
        }
    }
}
