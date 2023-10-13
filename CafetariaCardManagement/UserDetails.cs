using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafetariaCardManagement
{
    public class UserDetails : PersonalDetails, IBalance
    {
        private static int s_id = 1000;
        private string _userId;
        public string UserID
        {
            get
            {
                return _userId;
            }
        }
        public string WorkStationNumber { get; set; }
        private double _balance;
        

        public double WalletBalance
        {
            get
            {
                return _balance;
            }
        }
        public UserDetails(string name, string fatherName, long mobile, string mailId, Gender gender, string workStationNumber, double walletBalance)
        : base(name, fatherName, gender, mobile, mailId)
        {
            s_id++;
            _userId = "SF" + s_id;
            _balance = walletBalance;
            WorkStationNumber = workStationNumber;
        }

        public UserDetails(string u)
        {
            string[] user = u.Split(",");
            _userId = user[0];
            Name = user[1];
            FatherName = user[2];
            Gender = Enum.Parse<Gender>(user[3]);
            Mobile = long.Parse(user[4]);
            MailID = user[5];
            _balance = double.Parse(user[6]);
            WorkStationNumber = user[7];
        }

        public void WalletRecharge(double amount)
        {
            _balance += amount;
        }
        public void DeductAmount(double amount)
        {
            _balance -= amount;
        }
    }

}