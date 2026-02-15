using Data_Layer_DVLD;
using DTO.DVLD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer_DVLD
{
    public class clsApplications
    {

          public enum enMode { AddNew=1,Update=2}
          public  enMode _Mode;

        public DTOApplication _application;
        public clsApplicationTypes _applicationType;
        public clsPeople _PersonInfo;
        public clsUsers _User;

        public clsApplications()
        {
            _application = new DTOApplication();
            _Mode = enMode.AddNew;
        }

        private clsApplications(DTOApplication application)
        {
            this._application = application;
            this._User = clsUsers.GetUserByUserID(_application.CreatedByUserID);
            this._applicationType = clsApplicationTypes.FindApptype((clsApplicationTypes.enAppType)_application.ApplicationTypeID);
            this._PersonInfo = clsPeople.Find(application.ApplicantPersonID);
            _Mode = enMode.Update;


        }

         public bool Cancel()
        {

            return (clsApplicationDL.UpdateStatus(2, this._application.ApplicationID));


        }

        public bool setComplete()
        {
            return (clsApplicationDL.UpdateStatus(3,this._application.ApplicationID));

        }

        public static bool IsAppExist(int AppID)
        {
            return clsApplicationDL.IsAppExist(AppID);
        }

        public bool dosePersonHaveActiveApp(int AppTypeID)
        {
            return clsApplicationDL.DosePersonHaveActiveApplication(this._application.ApplicantPersonID, AppTypeID);
        }
        public static bool DosePersonHaveActiveApp(int PersonID,int AppTypeId)
        {
            return clsApplicationDL.DosePersonHaveActiveApplication(PersonID, AppTypeId);
        }

        public static bool DosePersonHaveActiveAppForLicenseClass(int PersonID, DTOApplication.enAppType AppTypeId,int LicenseClassID)
        {
            return (clsApplicationDL.DosePersonHaveActiveApplicationForLicenceClass(PersonID, LicenseClassID,(int) AppTypeId));
        }
        public static clsApplications FindBaseApp(int AppID)
        {
              DTOApplication application = new DTOApplication();
            if (clsApplicationDL.FindBaseApp(ref application, AppID))
            {

                return new clsApplications(application);

            }
            else
                return null;




        }

        public static DataTable GetAllApplications()
        {
            return clsApplicationDL.GetAllApplications();
        }

        public  bool Delete()
        {
            return clsApplicationDL.DeleteApplication(this._application.ApplicationID);
        }

        private bool _AddNewApp()
        {
            this._application.ApplicationID = clsApplicationDL.AddNewApplication(this._application);

            if (this._application.ApplicationID > 0)
            {
                return true;
            }
            else return false;


        }

        private bool _UpdateApp()
        {
            if (clsApplicationDL.UpdateApplication(this._application))
            {
                return true;
            }
            else return false;




        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        
                        if (_AddNewApp())
                        {
                            _Mode = enMode.Update;

                            return true;
                        } else return false;

                    }
                case enMode.Update:
                    {
                        if (_UpdateApp())
                        {
                            return true;
                        } else return false;



                    } default:return false;
                    





            }

          




        }

        public static int GetActiveAppID(int PersonID, DTOApplication.enAppType AppType)
        {
            return clsApplicationDL.GetActiveApplicationByPersonIDandApplicationType(PersonID,(int)AppType);
        }

        public static bool GetActiveAppIDByLicenceClass(int personID,int LicenceClassID, DTOApplication.enAppType Apptype)
        {
            return clsApplicationDL.GetActiveAppIDForLicenceClass(personID, LicenceClassID,(int)Apptype);
        }

        public int GetActiveAppID(DTOApplication.enAppType AppType)
        {
            return clsApplicationDL.GetActiveApplicationByPersonIDandApplicationType(this._application.ApplicantPersonID,(int)AppType);
        }

        public static bool DosePersonHaveActiveApp(int PersonID,DTOApplication.enAppType Apptype)
        {
            return (clsApplicationDL.DosePersonHaveActiveApplication(PersonID, (int)Apptype));
        }

    }
}
