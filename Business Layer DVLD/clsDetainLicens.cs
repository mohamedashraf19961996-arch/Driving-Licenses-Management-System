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
    public class clsDetainLicens
    {

        public DTODetainLicense _DetainLicenseInfo;
        enum enMode { AddNew,Update}

        enMode _Mode;

        clsLicenses licensesInfo;

       public clsDetainLicens()
        {
            _DetainLicenseInfo= new DTODetainLicense();
            _Mode = enMode.AddNew;



        }
        
        private clsDetainLicens(DTODetainLicense detainLicenseUpdate)
        {
            _DetainLicenseInfo= detainLicenseUpdate;
            _Mode = enMode.Update;
            licensesInfo = clsLicenses.getLicensebyLicenseID(detainLicenseUpdate.LicenseID);


        }

        public static bool delete(int DetainLicenseID)
        {
            return clsDetatinLicenseDL.Delete(DetainLicenseID);



        }

        public static DataTable ListDetainLicense()
        {
            return clsDetatinLicenseDL.ListDetainLicense();
        }

        public static clsDetainLicens Find(int DetainLicenseID)
        {
            DTODetainLicense detainLicense = new DTODetainLicense();

            if (clsDetatinLicenseDL.Find(DetainLicenseID, ref detainLicense))
            {
                return new clsDetainLicens(detainLicense);
            }
            else return null;


        }

        public static clsDetainLicens FindbyLicenseID(int LicenseID)
        {
            DTODetainLicense detainLicense = new DTODetainLicense();

            if (clsDetatinLicenseDL.FindbyLicenseID(LicenseID, ref detainLicense))
            {
                return new clsDetainLicens(detainLicense);
            }
            else return null;




        }
        private bool _AddNew()
        {
            this._DetainLicenseInfo.DetainID = clsDetatinLicenseDL.AddNewDetainLicense(this._DetainLicenseInfo);

            if (this._DetainLicenseInfo.DetainID != -1 && clsLicenses.ActivateLicense(false, this._DetainLicenseInfo.LicenseID)) 
            {
                return true;

            } else return false;


        }

        private bool _Update()
        {
            return (clsDetatinLicenseDL.Update(this._DetainLicenseInfo));

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
                default:
                    return false;




            }




        }

        public bool ReleaseLicense(int UserID)
        {
            
            clsApplications AppRelase= new clsApplications();

            AppRelase._application.ApplicantPersonID = licensesInfo.DriverInfo.PersonInformation._Person._PersonID;
            AppRelase._application.ApplicationDate = DateTime.Now;
            AppRelase._application.ApplicationStatus = DTOApplication.enApplicationStatus.Completed;
            AppRelase._application.ApplicationTypeID = DTOApplication.enAppType.ReleaseDetainedDrivingLicsense;
            AppRelase._application.CreatedByUserID = UserID;
            AppRelase._application.PaidFees = clsApplicationTypes.FindApptype(clsApplicationTypes.enAppType.ReleaseDetainDrivingLicence)._AppFees;
            AppRelase._application.LastStatusDate = DateTime.Now;

            if (!AppRelase.Save())
                return false;

            this._DetainLicenseInfo.ReleaseAppId = AppRelase._application.ApplicationID;
            if (!clsLicenses.ActivateLicense(true, this._DetainLicenseInfo.LicenseID))
                return false;


            return (clsDetatinLicenseDL.ReleaseLicense(this._DetainLicenseInfo.DetainID, this._DetainLicenseInfo));  


        }
        
        public bool IsLicenseReleased()
        {
            return clsDetatinLicenseDL.IsLicenseReleased(this._DetainLicenseInfo.DetainID);
        }
        public static bool IsLicenseReleased(int DetainID)
        {
            return clsDetatinLicenseDL.IsLicenseReleased(DetainID);
        }

    }
}
