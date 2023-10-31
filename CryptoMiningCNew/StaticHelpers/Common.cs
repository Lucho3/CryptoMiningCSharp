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
        private static bool ValidatePrice(decimal price) => price > 0 && price <= 10000;
        private static bool ValidateModel(string model) => !string.IsNullOrEmpty(model);
        private static bool ValidateGen(int generation) => generation > 0;
        private static bool ValidateVideoRAM(int ram) => ram > 0 && ram <=32;
        private static bool ValidateName(string name) => !string.IsNullOrEmpty(name);
        private static bool ValidateMoney(decimal money) => money >= 0;
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
        public static Func<T, bool> GetDelegate<T>(string whatToValidate)
        {
            MethodInfo method = typeof(Common).GetMethod(whatToValidate, BindingFlags.Static | BindingFlags.NonPublic);

            return (Func<T, bool>)Delegate.CreateDelegate(typeof(Func<T, bool>), method);
        }

        //sirech e tva dikshunari
        //tazi funkciq nqma da ni e okei ako iskame da varirame s vidovete atributi
        //ako izpolzvame T za celta ni trqbva object, ideqta e che runtime dokato pravi mapinga shte vidi che ne suvpadat tipovete i shte gurmi 
        //sore no template here
        //Na kratko ako izpolzvame template shte nacaka edin i susht tip navsqkude koeto ne e ok 
        public static Func<object, bool> GetValidationFunction(string valString)
        {
            var validators = new Dictionary<string, Func<object, bool>>
            {
                 { "Gen", (arg) => GetDelegate<int>("ValidateGen")((int)arg) },
                 { "ProcessorGen", (arg) => GetDelegate<int>("ValidateProcessorGen")((int)arg) },
                 { "Price", (arg) => GetDelegate<decimal>("ValidatePrice")((decimal)arg) },
                 { "Model", (arg) => GetDelegate<string>("ValidateModel")((string)arg) },
                 { "RAM", (arg) => GetDelegate<int>("ValidateVideoRAM")((int)arg )},
                 { "Name", (arg) => GetDelegate<string>("ValidateName")((string)arg) },
                 { "Proc", (arg) => GetDelegate<string>("ValidateProcType")((string)arg) },
                 { "Video",(arg) => GetDelegate<string>("ValidateVideoType")((string)arg)},
                 { "Money", (arg) => GetDelegate<decimal>("ValidateMoney")((decimal)arg) }
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

        //Taka ako navsqkude pasvame T v edin moment kogato kompilatorut mine prez dikshunarito 
        //shte izprati edin i susht tip navsqkde, koeto e problem zashtoto nqkoi funkcii 
        //priemat razl tipove, reshenieto e lambda v dikshunarito + eksplicitno zdavane
        //Zabavleniq - ref i out i dvete podavat po referenciq razlikata e che out ne 
        //durji da e inicializirano dkato ref iska
        public static void Validate<T>(ref T data, string function, string prompt)
        {
            Func<object, bool> validationFunction = GetValidationFunction(function);
            while(!validationFunction(data))
            {
                Console.Clear();
                Console.Write("Invalid input. Please reenter " + prompt + ": ");
                string userInput = Console.ReadLine();
                //tova po dosta paragrafi ne e okey no go ostavqm tuk za celt na zanqtieto :D
                //kastut kum object ot statichen tip kato int struct bla bla, pravi takak narecheniq boxing sirech
                //value type => reference type sheshtate se che tova vkluchva zadelqne na pamet, ako e kritichna tova ne e ok!!!
                //data = (T)(object)userInput ba daje i ne bachka :D
                data = (T)Convert.ChangeType(userInput, typeof(T));
            }
        }


    }
}
