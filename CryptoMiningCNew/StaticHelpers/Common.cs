using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoMiningCNew.Models.AbstractModels;
using CryptoMiningCNew.Models;
using System.Reflection;

namespace CryptoMiningCNew.StaticHelpers
{
    //static classes can not use interfaces
    static class Common
    {

        //Symple lambads
        private static bool ValidateProcessorGen(int generation) => generation > 0 && generation <= 9;
        private static bool ValidatePrice(double price) => price > 0 && price <= 10000;
        private static bool ValidateModel(string model) => !string.IsNullOrEmpty(model);
        private static bool ValidateGen(int generation) => generation > 0;
        private static bool ValidateVideoRAM(int ram) => ram > 0 && ram <=32;
        private static bool ValidateName(string name) => !string.IsNullOrEmpty(name);
        private static bool ValidateMoney(double money) => money >= 0;
        private static bool ValidateVideoType(string type) => type == "Game" || type == "Mine";
        private static bool ValidateProcType(string type) => type == "Low" || type == "High";
        public static Processor ProcessorFactory(string type, string model, decimal price, int generation)
        {
            if (type == "High")
                return new HighPerformanceProcessor(model, price, generation);
            else if (type == "Low")
                return new LowPerformanceProcessor(model, price, generation);
            else
                throw new ArgumentException("No such processor!");
        }
        public static VideoCard VideoCardFactory(string type, string model, decimal price, int generation, int ram)
        {
            if (type == "Game")
                return new GameVideoCard(model, price, generation, ram);
            else if (type == "Mine")
                return new MineVideoCard(model, price, generation, ram);
            else
                throw new ArgumentException("No such video card!");
        }


        //Pisha na bulgarski shtoto sum v deili i tva izvrashtenie na prirodata ne e normalno
        //Tuk izpolzvame reflekshuni i delegati celta na tva neshto e bazirano na daden string da
        //vurnem nqkakva afunkciq ot klasa, gotinkoto e che imame vuzmojnost da vurnem funkciq koqto
        //priema razlichni parametri  realno samo taq funkciq si ni e nujna osven ako ne iskam da zatvorim
        // izbora samo do nqkolko f-cii
        public static Func<T, bool> getDelegate<T>(string whatToValidate)
        {
            MethodInfo method = typeof(Common).GetMethod(whatToValidate, BindingFlags.Static | BindingFlags.NonPublic);

            return (Func<T, bool>)Delegate.CreateDelegate(typeof(Func<T, bool>), method);
        }

        //sirech e tva dikshunari
        public static Func<T, bool> getValidationFunction<T>(string valString)
        {
            var validators = new Dictionary<string, Func<T, bool>>
            {
                 { "Gen",getDelegate<T>("ValidateGen") }
            };
        

            if (validators.ContainsKey(valString))
            {
                return validators[valString];
            }
            else
            {
                return (value) => false;
            }
        }

        public static  object Validate(object data, string function, string prompt)
        {
            throw new NotImplementedException();
        }


    }
}
