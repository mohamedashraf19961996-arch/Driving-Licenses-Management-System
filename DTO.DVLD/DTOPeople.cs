using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DVLD
{
    public class DTOPeople
    {


        public int _PersonID { get; set; }
        public string _FirstName { get; set; }
        public string _SecondName { get; set; }
        public string _ThirdName { get; set; }
        public string _ForthName { get; set; }

        public string _NationalNO { get; set; }

        public DateTime _DateOfBirth { get; set; }

        
      public  enum enGender :byte{ Male=1,Female=2}

      public  enGender _Gender;

        public string _Address { get; set; }

        public string _PhoneNumber { get; set; }

        public string _Email { get; set; }

        public int _NationalCountryID { get; set; }

        public string _ImagePath { get; set; }

        public string FullName { get { return _FirstName + " " + _SecondName + " " + _ThirdName + " " + _ForthName; } }



    }
}
