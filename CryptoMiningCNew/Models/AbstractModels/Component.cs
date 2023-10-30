using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoMiningCNew.ModelIntrefaces;

namespace CryptoMiningCNew.Models.AbstractModels
{
    abstract class Component : IComponent
    {
        //With properties we don't need to explicitly create the private fields if we don't need them
        public string Model { get; set; }
        public int Generation { get; set; }
        public decimal Price { get; set; }
        public int LifeWorkingHours { get; set; }

        public Component(string model, decimal price, int generation, int lifeWorkingHours)
        {
            this.Model = model;
            this.Price = price;
            this.Generation = generation;
            this.LifeWorkingHours = lifeWorkingHours;
        }
        public void DrainLife(int amountOfHours)
        {
            if (LifeWorkingHours - amountOfHours < 0)
            {
                throw new InvalidOperationException("Component died!");
            }

            LifeWorkingHours -= amountOfHours;
        }
    }
}
