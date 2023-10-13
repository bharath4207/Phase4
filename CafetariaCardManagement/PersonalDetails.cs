using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafetariaCardManagement
{
    public enum Gender { select, Male, Female, Transgender }
    public class PersonalDetails
    {
        public string Name { get; set; }
        public string FatherName { get; set; }
        public Gender Gender { get; set; }
        public long Mobile { get; set; }
        public string MailID { get; set; }

        public PersonalDetails() {
            
        }
        public PersonalDetails(string name, string fatherName, Gender gender, long mobile, string mailId)
        {
            Name = name;
            FatherName = fatherName;
            Gender = gender;
            Mobile = mobile;
            MailID = mailId;
        }
    }
}