using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{

    /// <summary>
    /// Enum gender 
    /// </summary>
    public enum Gender {

        Male,
        Female,
        Transgender
    }

    /// <summary>
    /// Personal details class to store the details of persons
    /// </summary>
    public class PersonalDetails
    {
        /// <summary>
        /// A constructor to initialize values 
        /// </summary>
        /// <param name="name">type string</param>
        /// <param name="fatherName">type string</param>
        /// <param name="gender">type gender</param>
        /// <param name="mobileNumber">Type long</param>
        /// <param name="dateOfBirth">type dateTime</param>
        /// <param name="mailId">Type string</param>
        /// <param name="location">Type string</param> <summary>
        
        public PersonalDetails(string name, string fatherName, Gender gender, long mobileNumber, DateTime dateOfBirth, string mailId, string location)
        {
            Name = name;
            FatherName = fatherName;
            Gender = gender;
            MobileNumber = mobileNumber;
            DateOfBirth = dateOfBirth;
            MailId = mailId;
            Location = location;
        }

        // Personal Details Class:
        // Properties: Name, FatherName, Gender- {Select, Male, Female, Transgender}, Mobile, DOB, MailID, Location

        public string Name { get; set; }
        public string FatherName { get; set; }
        public Gender Gender { get; set; }
        public long MobileNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string MailId { get; set; }
        public string Location { get; set; }


    }
}