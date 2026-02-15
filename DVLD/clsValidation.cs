using Business_Layer_DVLD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DVLD
{
    internal class clsValidation
    {

        public static bool ValidateEmail(string Email)
        {
            var pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            var regex =new Regex(pattern);

            return regex.IsMatch(Email);    
        }

        public static bool ValdiateNumber(string Number)
        {
            var pattern = "^d+$";
            var regex= new Regex(pattern);
            return regex.IsMatch(Number);


        }

        public static bool ValdiateNationalNo(string NationalNo)
        {

            return clsPeople.IsPersonExists(NationalNo);

        }



    }
}
