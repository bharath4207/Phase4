using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{

    /// <summary>
    /// Interface Ibalance
    /// </summary>
    public interface IBalance
    {
        //         Interface IBalance
        // Properties: WalletBalance
        // Method: WalletRecharge, DeductBalance

        public double WalletBalance { get; set; }
        
        public void WalletRecharge(double amount) {

        }

        public void DeductBalance(double amount) {
            
        }

    }
}