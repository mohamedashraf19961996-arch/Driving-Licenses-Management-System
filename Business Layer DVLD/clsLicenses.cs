using Data_Layer_DVLD;
using DTO.DVLD;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer_DVLD
{
    public class clsLicenses
    {
       public DTOLicense LicenseInfo;
        public clsApplications ApplicationInfo;
        public clsDrivers DriverInfo;
        public clsLicenceClasses LicenseClassInfo;
        public clsUsers UserInfo;
        clsDetainLicens Detain;

        enum enMode { AddNew,Update}
        enMode _Mode = enMode.AddNew;

        private clsLicenses(DTOLicense UpdatedLicense)
        {
            this.LicenseInfo= UpdatedLicense;
            _Mode = enMode.Update;
            this.ApplicationInfo = clsApplications.FindBaseApp(LicenseInfo.ApplicationID);
            this.DriverInfo =clsDrivers.FindDriverByID(LicenseInfo.DriverID);
            this.LicenseClassInfo = clsLicenceClasses.Find(LicenseInfo.LicenseClassID);
            this.UserInfo = clsUsers.GetUserByUserID(LicenseInfo.CreatedByUserID);
            
        }

        public clsLicenses()
        {
            _Mode = enMode.AddNew;
            LicenseInfo=new DTOLicense();


        }


        public static clsLicenses getLicensebyLicenseID(int LicenseID)
        {
            DTOLicense license = new DTOLicense();

            if (clsLicenseDL.FindLicenseByLicenseID(LicenseID, ref license))
            {
                return new clsLicenses(license);
            }
            else return null;





        }

        public static clsLicenses getLicensebyPersonLicenseClass(int PersonID,DTOLicenceClasses.enLicenceClassName LicenseClass)
        {
            DTOLicense license = new DTOLicense();

            if (clsLicenseDL.FindLicenseByAppAndDriverAndLicenseClassID(PersonID,(int)LicenseClass, ref license))
            {
                return new clsLicenses(license);
            }
            else return null;
        }

        public static bool delete(int LicenseId)
        {


            return (clsLicenses.delete(LicenseId));


        }

        public static DataTable ListLicense(int DriverID)
        {
            return clsLicenses.ListLicense(DriverID);
        }

        private bool _AddNew()
        {
            this.LicenseInfo.LicenseID = clsLicenseDL.AddNewLicense(this.LicenseInfo);

            return (this.LicenseInfo.LicenseID > 0);



        }

        private bool _Update()
        {
            return (clsLicenseDL.UpdateLicense(this.LicenseInfo));
           
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

                        return _Update();


                    }
                default: return false;




            }






        }

        public static bool DoseDriverHaveLicenseOfLicenseClass(int ApplicationID, DTOLicenceClasses.enLicenceClassName LicenseClass)
        {


            return (clsLicenseDL.DoseDriverHaveLicenseOfLicenseClass(ApplicationID, (int)LicenseClass));
        }

        public  bool DoseDriverHaveLicenseOfLicenseClass()
        {


            return clsLicenseDL.DoseDriverHaveLicenseOfLicenseClass(this.LicenseInfo.ApplicationID, this.LicenseInfo.LicenseClassID);
        }

        public bool DoseLicenseIsActive()
        {
            return clsLicenseDL.DoseLicenseIsActive(this.LicenseInfo.LicenseID);
        }

        public static bool DoseLicenseIsActive(int LicenseID)
        {
            return clsLicenseDL.DoseLicenseIsActive(LicenseID);
        }

        public bool ActivateLicense(bool IsActive)
        {

            return clsLicenseDL.ActivateLicense(this.LicenseInfo.LicenseID, IsActive);


        }

        public static bool ActivateLicense(bool IsActive,int LicenseID)
        {

            return clsLicenseDL.ActivateLicense(LicenseID, IsActive);


        }

        public int RenewLicense(int UserID,string Notes)
        {







            clsApplications RenewApp = new clsApplications();

            RenewApp._application.ApplicantPersonID = this.DriverInfo.Driver.PersonID;
            RenewApp._application.PaidFees = clsApplicationTypes.FindApptype(clsApplicationTypes.enAppType.RenewDrivingLicence)._AppFees;
            RenewApp._application.ApplicationDate = DateTime.Now;
            RenewApp._application.CreatedByUserID = UserID;
            RenewApp._application.LastStatusDate = DateTime.Now;
            RenewApp._application.ApplicationStatus = DTOApplication.enApplicationStatus.Completed;
            RenewApp._application.ApplicationTypeID = DTOApplication.enAppType.RenewDrivingLicenseService;

            if(!RenewApp.Save())
            {
                return -1;
            }

            clsLicenses RenewLicense = new clsLicenses();

            RenewLicense.LicenseInfo.ApplicationID = RenewApp._application.ApplicationID;
            RenewLicense.LicenseInfo.DriverID = this.DriverInfo.Driver.DriverID;
            RenewLicense.LicenseInfo.CreatedByUserID = UserID;
            RenewLicense.LicenseInfo.ExpirationDate = DateTime.Now.AddYears(clsLicenceClasses.Find(this.LicenseInfo.LicenseClassID)._DTOLicenceClasses.DefaultValidityLength);
            RenewLicense.LicenseInfo.IssueDate = DateTime.Now;
            RenewLicense.LicenseInfo.issueReason = DTOLicense.enIssueReason.Renew;
            RenewLicense.LicenseInfo.PaidFees = clsLicenceClasses.Find(this.LicenseInfo.LicenseClassID)._DTOLicenceClasses.ClassFees;
            RenewLicense.LicenseInfo.IsActive = true;
            RenewLicense.LicenseInfo.Notes = Notes;
            RenewLicense.LicenseInfo.LicenseClassID=this.LicenseInfo.LicenseClassID;

            if (RenewLicense.Save())
            {
                this.ActivateLicense(false);
                return RenewLicense.LicenseInfo.LicenseID;

            }
            else
                return -1;








        }

        public int ReplacementForDamaged(int UserID)
        {
            clsApplications NewAppForDamaged= new clsApplications();

           NewAppForDamaged._application.ApplicantPersonID = this.DriverInfo.Driver.PersonID;
           NewAppForDamaged._application.PaidFees = clsApplicationTypes.FindApptype(clsApplicationTypes.enAppType.ReplaceDamageDrivingLicence)._AppFees;
           NewAppForDamaged._application.ApplicationDate = DateTime.Now;
           NewAppForDamaged._application.CreatedByUserID = UserID;
           NewAppForDamaged._application.LastStatusDate = DateTime.Now;
           NewAppForDamaged._application.ApplicationStatus = DTOApplication.enApplicationStatus.Completed;
           NewAppForDamaged._application.ApplicationTypeID = DTOApplication.enAppType.ReplacementforaDamagedDrivingLicense;

            if (!NewAppForDamaged.Save())
            {
                return -1;
            }

            clsLicenses NewLicenseForDamaged = new clsLicenses();

            NewLicenseForDamaged.LicenseInfo.ApplicationID = NewAppForDamaged._application.ApplicationID;
            NewLicenseForDamaged.LicenseInfo.DriverID = this.DriverInfo.Driver.DriverID;
            NewLicenseForDamaged.LicenseInfo.CreatedByUserID = UserID;
            NewLicenseForDamaged.LicenseInfo.ExpirationDate = this.LicenseInfo.ExpirationDate; ;
            NewLicenseForDamaged.LicenseInfo.IssueDate = DateTime.Now;
            NewLicenseForDamaged.LicenseInfo.issueReason = DTOLicense.enIssueReason.ReplacementForDamaged;
            NewLicenseForDamaged.LicenseInfo.PaidFees = 0;
            NewLicenseForDamaged.LicenseInfo.IsActive = true;
            NewLicenseForDamaged.LicenseInfo.Notes = this.LicenseInfo.Notes;
            NewLicenseForDamaged.LicenseInfo.LicenseClassID = this.LicenseInfo.LicenseClassID;

            if (NewLicenseForDamaged.Save())
            {
                this.ActivateLicense(false);
                return NewLicenseForDamaged.LicenseInfo.LicenseID;

            }
            else
                return -1;








        }

        public bool DoseLicenseExpierd()
        {
            if (this.LicenseInfo.ExpirationDate > DateTime.Now)
            {
                return true;
            }
            else return false;





        }

        public int ReplacementForLost(int UserID)
        {
            clsApplications NewAppForLost = new clsApplications();

            NewAppForLost._application.ApplicantPersonID = this.DriverInfo.Driver.PersonID;
            NewAppForLost._application.PaidFees = clsApplicationTypes.FindApptype(clsApplicationTypes.enAppType.ReplaceLostDrivingLicence)._AppFees;
            NewAppForLost._application.ApplicationDate = DateTime.Now;
            NewAppForLost._application.CreatedByUserID = UserID;
            NewAppForLost._application.LastStatusDate = DateTime.Now;
            NewAppForLost._application.ApplicationStatus = DTOApplication.enApplicationStatus.Completed;
            NewAppForLost._application.ApplicationTypeID = DTOApplication.enAppType.ReplacementforaLostDrivingLicense;

            if (!NewAppForLost.Save())
            {
                return -1;
            }

            clsLicenses NewLicenseForLost = new clsLicenses();

            NewLicenseForLost.LicenseInfo.ApplicationID = NewAppForLost._application.ApplicationID;
            NewLicenseForLost.LicenseInfo.DriverID = this.DriverInfo.Driver.DriverID;
            NewLicenseForLost.LicenseInfo.CreatedByUserID = UserID;
            NewLicenseForLost.LicenseInfo.ExpirationDate = this.LicenseInfo.ExpirationDate;
            NewLicenseForLost.LicenseInfo.IssueDate = DateTime.Now;
            NewLicenseForLost.LicenseInfo.issueReason = DTOLicense.enIssueReason.ReplacementForLost;
            NewLicenseForLost.LicenseInfo.PaidFees = 0;
            NewLicenseForLost.LicenseInfo.IsActive = true;
            NewLicenseForLost.LicenseInfo.Notes = this.LicenseInfo.Notes;
            NewLicenseForLost.LicenseInfo.LicenseClassID = this.LicenseInfo.LicenseClassID;

            if (NewLicenseForLost.Save())
            {
                this.ActivateLicense(false);
                return NewLicenseForLost.LicenseInfo.LicenseID;

            }
            else
                return -1;












        }




    }
}
