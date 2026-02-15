using Data_Layer_DVLD;
using DTO.DVLD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Business_Layer_DVLD
{
    public class clsLocalDrivingLicenseApplications:clsApplications
    {

        public enum enMode { AddNew=1, Update=2 }
        public enMode _Mode;
        public int _LocalDrivingLicenseAppID {  get; set; }
        public int _LicenseClassID {  get; set; }
        public clsLicenceClasses licenceClass;
        
        public clsLocalDrivingLicenseApplications()
        {
           this._LocalDrivingLicenseAppID = -1;
            this._LicenseClassID = -1;
            _Mode = enMode.AddNew;
            
        }

        private clsLocalDrivingLicenseApplications(int LocalDrivingLicenseAppID, int LicenseClassID, DTOApplication App)
        {
            _LocalDrivingLicenseAppID = LocalDrivingLicenseAppID;
            _LicenseClassID = LicenseClassID;
            licenceClass = clsLicenceClasses.Find(LicenseClassID);
            this._application = App;
            this._User = clsUsers.GetUserByUserID(_application.CreatedByUserID);
            this._applicationType = clsApplicationTypes.FindApptype((clsApplicationTypes.enAppType)_application.ApplicationTypeID);

            this._PersonInfo = clsPeople.Find(this._application.ApplicantPersonID);

            _Mode = enMode.Update;


        }

        public static clsLocalDrivingLicenseApplications GetLocalDrivingLicenseApplicationsByID(int LocalDrivingLicenseAppID)
        {
            int ApplicationID = -1; int LicenseClassID = -1;DTOApplication appInfo;

            if (clsLocalDriverLicenceApplicationDL.GetLocalLicenceAppbyID(LocalDrivingLicenseAppID, ref ApplicationID, ref LicenseClassID))
            {
                clsApplications App=clsApplications.FindBaseApp(ApplicationID);
                if (App != null)
                {
                    appInfo = App._application;
                    return new clsLocalDrivingLicenseApplications(LocalDrivingLicenseAppID, LicenseClassID, appInfo);
                }
                else return null;

            }
            else return null;
        }

        public static clsLocalDrivingLicenseApplications GetLocalDrivingLicenseApplicationsByAppID(int AppID)
        {
            int LocalDrivingLicenseAppID = -1; int LicenseClassID = -1; DTOApplication appInfo;

            if (clsLocalDriverLicenceApplicationDL.GetLocalLicenceAppbyAppID(ref LocalDrivingLicenseAppID, AppID, ref LicenseClassID))
            {
                clsApplications App = clsApplications.FindBaseApp(AppID);
                if (App != null)
                {
                    appInfo = App._application;
                    return new clsLocalDrivingLicenseApplications(LocalDrivingLicenseAppID, LicenseClassID, appInfo);
                } else return null;
            }
            else return null;
        }


        public bool Delete()
        {

            if( clsLocalDriverLicenceApplicationDL.DeleteLocalLicenceApp(this._LocalDrivingLicenseAppID))
            {
                if (!base.Delete())
                { return false; }
                else
                    return true;

            }else return false;



        }

        public static DataTable GetAllLocalDriverLicenceApp()
        {
            return clsLocalDriverLicenceApplicationDL.GetAllLocalLicenceApp();


        }

        private bool _AddNew()
        {

             this._LocalDrivingLicenseAppID = clsLocalDriverLicenceApplicationDL.AddNewLocalLicenceApp(_application.ApplicationID, _LicenseClassID);

            return (this._LocalDrivingLicenseAppID > 0);



        }

        private bool _Update()
        {
            if (clsLocalDriverLicenceApplicationDL.UpdateLocalLicenceApp(this._LocalDrivingLicenseAppID,this._application.ApplicationID,this._LicenseClassID))
            {
                return true;
            }
            else return false;
            
        }
        public bool  Save()
        {
            base._Mode = (clsApplications.enMode)this._Mode;
            if(!base.Save())
            {
                return false;
            }

            switch(_Mode)
            {
                case enMode.AddNew:
                    {
                       
                        if (_AddNew())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }


                        else return false;
                    }
                case enMode.Update:
                    {
                        if (_Update())
                        {

                            return true;
                        }


                        else return false;




                    }
                default:return false;









            }
        }

        public int GetCountOfPassedTestsForLicenseApp()
        {
            return clsLocalDriverLicenceApplicationDL.GetCountOfPassedTestsForLicenseApp(this._LocalDrivingLicenseAppID);
        }

        public static int GetCountOfPassedTestsForLicenseApp(int LocalDrivingLicenseID)
        {
            return clsLocalDriverLicenceApplicationDL.GetCountOfPassedTestsForLicenseApp(LocalDrivingLicenseID);
        }

        public bool IsThereAnActiveScaduledTest(clsTestTypes.enTestTypeId TestType)
        {
            return (clsLocalDriverLicenceApplicationDL.IsThereAnActiveScaduledTest( this._LocalDrivingLicenseAppID, (int)TestType));
        }

        public static bool IsThereAnActiveScaduledTest(clsTestTypes.enTestTypeId TestType,int LocalDrivingLicenseID)
        {
            return (clsLocalDriverLicenceApplicationDL.IsThereAnActiveScaduledTest((int)TestType, LocalDrivingLicenseID));
        }

        public bool DoseAttendTestType(clsTestTypes.enTestTypeId testtype)
        {
            return clsLocalDriverLicenceApplicationDL.DoseAttendTestType((int)testtype, this._LocalDrivingLicenseAppID);
        }
        public static bool DoseAttendTestType(clsTestTypes.enTestTypeId testtype,int LocalDriverLicensseID)
        {
            return clsLocalDriverLicenceApplicationDL.DoseAttendTestType((int)testtype, LocalDriverLicensseID);
        }

        public bool DosePassTestType(clsTestTypes.enTestTypeId testtype)
        {
            return clsLocalDriverLicenceApplicationDL.DosePassTestType(this._LocalDrivingLicenseAppID,(int) testtype);
        }

        public static bool DosePassTestType(clsTestTypes.enTestTypeId testtype, int LocalDriverLicensseID)
        {
            return clsLocalDriverLicenceApplicationDL.DosePassTestType(LocalDriverLicensseID, (int)testtype);
        }

        public static int TotalTrialsPerTest(clsTestTypes.enTestTypeId testtype, int LocalDriverLicensseID)
        {
            return clsLocalDriverLicenceApplicationDL.TotalTrialsPerTest((int)testtype, LocalDriverLicensseID);
        }
        

        public int TotalTrialsPerTest(clsTestTypes.enTestTypeId testtype)
        {
            return clsLocalDriverLicenceApplicationDL.TotalTrialsPerTest((int)testtype,this._LocalDrivingLicenseAppID);
        }

    }
}
