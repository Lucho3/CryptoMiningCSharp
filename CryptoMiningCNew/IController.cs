using CryptoMiningCNew.Models;
using System.Collections.Generic;

namespace CryptoMiningCNew
{
    interface IController
    {
        decimal MinedAmount { get; set; }
        List<User> Users { get; set; }
        void CreateComputer(string name, string procType, string procModel, int procGen, decimal procPrice, string videoType, string videoModel, int videoGen, int RAM, decimal videoPrice);
        void CreateUser();
        void InitializeComputer();
        void Mine();
        void Shutdown();
        void UserInfo(string name);
    }
}