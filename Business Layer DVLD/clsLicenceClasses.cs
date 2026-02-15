using Data_Layer_DVLD;
using DTO.DVLD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer_DVLD
{
    public class clsLicenceClasses
    {

        public DTOLicenceClasses _DTOLicenceClasses;


        clsLicenceClasses(DTOLicenceClasses licenceClasses) { 
        
        _DTOLicenceClasses= licenceClasses;
       
        
        }

        public static DataTable GetAllLicenceClasses()
        {

            return clsLicenceClassesDL.GetAllLicenceClasses();


        }

        public static clsLicenceClasses Find(int ID)
        {
           DTOLicenceClasses _DTOLicenceClasses=new DTOLicenceClasses();

            if (clsLicenceClassesDL.GetLicenceClassesByID(ref _DTOLicenceClasses, ID))
            {
                return new clsLicenceClasses(_DTOLicenceClasses);
            }
            else return null;



        }

        private bool _UpdateLicenceClasses()
        {
            if(clsLicenceClassesDL.UpdateLicenceClasses(this._DTOLicenceClasses))
            {
                return true;
            }else 
                return false;


        }
        public bool Save()
        {
            return (_UpdateLicenceClasses());
        }


    }
}
