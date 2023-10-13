using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafetariaCardManagement
{
    public interface IBalance
    {
        public double WalletBalance { get; }
        void WalletRecharge(double amount);
        void DeductAmount(double amount);
    }
}