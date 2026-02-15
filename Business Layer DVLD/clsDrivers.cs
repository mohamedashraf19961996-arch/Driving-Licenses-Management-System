using Data_Layer_DVLD;
using DTO.DVLD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer_DVLD
{
    public class clsDrivers
    {
        public DTODrivers Driver;
        public clsPeople PersonInformation;
        public clsUsers UserInformation;
        enum enMode { AddNew,Update};
        enMode _Mode= enMode.AddNew;

       private clsDrivers(DTODrivers UpdatedDriver)
        {
            Driver= UpdatedDriver;
            _Mode = enMode.Update;
            PersonInformation = clsPeople.Find(Driver.PersonID);
            UserInformation=clsUsers.GetUserByUserID(Driver.UserID);
        }

        public clsDrivers()
        {
            Driver= new DTODrivers();
            _Mode= enMode.AddNew;
        }

        public static clsDrivers FindDriverByID(int DriverID)
        {
            DTODrivers Driver=new DTODrivers();
            if (clsDriverDL.GetDriverByID(DriverID, ref Driver))
            {
                return new clsDrivers(Driver);
            }
            else return null;



        }
        public static clsDrivers FindDriverByPersonID(int PersonID)
        {
            DTODrivers Driver = new DTODrivers();
            if (clsDriverDL.GetDriverByPersonID(PersonID, ref Driver))
            {
                return new clsDrivers(Driver);
            }
            else return null;



        }

        public static bool Delete(int DriverID)
        {
            return (clsDriverDL.DeleteDriver(DriverID));
        }

        private bool _AddNewDriver()
        {
            this.Driver.DriverID = clsDriverDL.AddNewDriver(this.Driver);

            return (this.Driver.DriverID > 0);




        }

        private bool _UpdateDriver()
        {
            return (clsDriverDL.UpdateDriver(this.Driver)); 
        }

        public bool Save()
        {
            switch(_Mode)
            {
                case enMode.AddNew:
                    {

                        if (_AddNewDriver())
                        {
                            _Mode = enMode.Update;
                            return true;

                        }
                        else return false;
                    }
                case enMode.Update:
                    {

                        return (_UpdateDriver());



                    }
                default:return false;




            }






        }

        public static DataTable ListDrivers()
        {

            return clsDriverDL.ListDrivers();



        }

        public static DataTable ListDriverLicenseHistory(int PersonID)
        {

            return clsDriverDL.ListDriverLicenseInfo(PersonID);


        }



    }
}
