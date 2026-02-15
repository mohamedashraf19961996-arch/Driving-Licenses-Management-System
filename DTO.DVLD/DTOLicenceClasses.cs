using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DVLD
{
    public class DTOLicenceClasses
    {
        public int ID {  get; set; }

        public enum enLicenceClassName  {
            SmallMotorcycle =1,
            HeavyMotorcycleLicense=2,
            Ordinarydrivinglicense=3,
                Commercial=4,
                Agricultural=5,
            Smallandmediumbus=6,
        Truckandheavyvehicle=7}

        public enLicenceClassName  ClassNameID;

        public string ClassName;
        
        public string Description {  get; set; }

        public byte MinimumAllowedAge {  get; set; }

        public byte DefaultValidityLength {  get; set; }

        public decimal ClassFees {  get; set; }



    }
}
