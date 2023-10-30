﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoMiningCNew.Models.AbstractModels;

namespace CryptoMiningCNew.Models
{
    class HighPerformanceProcessor:Processor
    {
        public HighPerformanceProcessor(string model, decimal price, int generation)
            : base(model, price, generation, 8)
        {
        }
    }
}
