using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{

    /// <summary>
    /// Class Customer Detaisl inherits Personal details and Ibalance
    /// </summary>
    public class CustomerDetails : PersonalDetails , IBalance
    {
        //         CustomerDetails class: Inherits Personal Details, IBalance
        // Field: _balance
        // Properties: CustomerID, WalletBalance
        // Methods: WalletRecharge, DeductBalance


        private double _balance;

        /// <summary>
        /// Customer Details Constructor
        /// </summary>
        /// <param name="walletBalance">Type double</param>
        /// <param name="name">string type</param>
        /// <param name="fatherName">string type</param>
        /// <param name="gender">Enum type</param>
        /// <param name="mobileNumber">long type</param>
        /// <param name="dateOfBirth">DateTime type</param>
        /// <param name="mailId">Type string</param>
        /// <param name="location">Type string</param>
        /// <returns></returns>
        public CustomerDetails(double walletBalance , string name, string fatherName, Gender gender, long mobileNumber, DateTime dateOfBirth, string mailId, string location) : base( name,  fatherName,  gender,  mobileNumber,  dateOfBirth,  mailId,  location)
        {
            CustomerId = "CID" + s_id.ToString();
            s_id++;
            WalletBalance = walletBalance;
        }

        private static int s_id = 1001;

        public string CustomerId { get; set; }
        public double WalletBalance { get; set; }
        
        public void  WalletRecharge(double amount) {
            WalletBalance += amount;
        }

        public void DeductBalance(double amount) {
            WalletBalance -= amount;
        }


    }
}