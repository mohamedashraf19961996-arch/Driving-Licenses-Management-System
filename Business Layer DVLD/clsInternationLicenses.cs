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
    public class clsInternationLicenses
    {
        public DTOInternationlLicenses internationlLicenses;

        public clsDrivers DriverInfo;
        enum enMode { AddNew,Update}
        enMode _Mode;

        public clsInternationLicenses()
        {
            internationlLicenses =new DTOInternationlLicenses();
            _Mode=enMode.AddNew;
        }

        private clsInternationLicenses(DTOInternationlLicenses internationlLicensesUpdate)
        {
           this.internationlLicenses=internationlLicensesUpdate;
            this.DriverInfo = clsDrivers.FindDriverByID(internationlLicensesUpdate.DriverID);
            _Mode=enMode.Update;
        
        }

        public static clsInternationLicenses Find(int InternationalLicenseID)
        {
            DTOInternationlLicenses internationlLicenses =new DTOInternationlLicenses();

            if (clsInternationlLicensesDL.FindByID(InternationalLicenseID, ref internationlLicenses))
            {

                return new clsInternationLicenses(internationlLicenses);


            }
            else return null;

        }
        public static clsInternationLicenses FindByLocalDriverLicenseID(int LocalDriverLicenseID)
        {
            DTOInternationlLicenses internationlLicenses = new DTOInternationlLicenses();

            if (clsInternationlLicensesDL.FindByLocalDriverLicenseID(LocalDriverLicenseID, ref internationlLicenses))
            {

                return new clsInternationLicenses(internationlLicenses);


            }
            else return null;

        }

        public static bool Delete(int InternationalLicenseID)
        {

            return (clsInternationlLicensesDL.Delete(InternationalLicenseID));    


        }

        private bool _AddNew()
        {
            clsApplications NewApp=new clsApplications();


            NewApp._application.ApplicantPersonID = this.DriverInfo.PersonInformation._Person._PersonID;
            NewApp._application.CreatedByUserID = clsDVLDSittings._CurrentUser._User.UserID;
            NewApp._application.ApplicationStatus =DTOApplication.enApplicationStatus.Completed;
            NewApp._application.ApplicationTypeID =DTOApplication.enAppType.NewInternationalLicense ;
            NewApp._application.PaidFees = clsApplicationTypes.FindApptype(clsApplicationTypes.enAppType.NewInternationalDrivingLicence)._AppFees;
            NewApp._application.ApplicationDate = DateTime.Now;
            NewApp._application.LastStatusDate = DateTime.Now;

            if (!NewApp.Save())
                return false;
            this.internationlLicenses.ApplicationID = NewApp._application.ApplicationID;

            this.internationlLicenses.InternationalLicenseID = clsInternationlLicensesDL.AddNew(this.internationlLicenses);

            return (this.internationlLicenses.InternationalLicenseID > 0);





        }

        private bool _Update()
        {


            return (clsInternationlLicensesDL.Update(this.internationlLicenses));






        }

        public bool Save()
        {
            switch(_Mode)
            {

                case enMode.AddNew:
                    {

                        _Mode = enMode.Update;

                        if (_AddNew())
                        {
                            return true;
                        }
                        else return false;
                    }
                case enMode.Update:
                    {

                        return (_Update());
                    }
                default: { return false; }



            }





        }

        public static DataTable ListInternationalLicense()
        {
            return clsInternationlLicensesDL.ListInternationalLicense();
        }


        public static DataTable ListInernationalLicenseByDriverID(int DriverId)
        {
            return clsInternationlLicensesDL.ListInernationalLicenseByDriverID(DriverId);
        }

        public static bool DoseInternationalLicenseActive(int InternationalLicenseID)
        {

            return clsInternationlLicensesDL.DoseInternationalLicenseActive(InternationalLicenseID);


        }

        public bool DoseInternationalLicenseActive()
        {

            return clsInternationlLicensesDL.DoseInternationalLicenseActive(this.internationlLicenses.InternationalLicenseID);


        }

        public bool DoseLicenseExpired()
        {

            return (this.internationlLicenses.ExpirationDate < DateTime.Now);


        }

    }
}
