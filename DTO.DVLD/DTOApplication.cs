using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DVLD
{
    public class DTOApplication
    {
        public DateTime LastStatusDate { get; set; }
        public decimal PaidFees { get; set; }

        public int CreatedByUserID { get; set; }

        public int ApplicationID { get; set; }

        public int ApplicantPersonID { get; set; }

        public DateTime ApplicationDate { get; set; }

        //public int ApplicationTypeID {  get; set; }

        public enum enApplicationStatus : byte { New = 1, Cancelled = 2, Completed = 3 }

        public enApplicationStatus ApplicationStatus;



        //public string StatusText
        //{
        //    get
        //    {
        //        switch (ApplicationStatus)
        //        {
        //            case enApplicationStatus.New:
        //                {
        //                    return "New";
        //                }
        //            case enApplicationStatus.Cancelled:
        //                {
        //                    return "Cancelled";
        //                }
        //            case enApplicationStatus.Completed:
        //                {
        //                    return "Completed";
        //                }
        //            default: return "None";
        //        }
        //    }


        //}


        public enum enAppType
        {
            NewLocalDrivingLicenseService = 1,
            RenewDrivingLicenseService = 2,
            ReplacementforaLostDrivingLicense = 3,
            ReplacementforaDamagedDrivingLicense = 4,
            ReleaseDetainedDrivingLicsense = 5,
            NewInternationalLicense = 6,
            RetakeTest=7
        }

        public enAppType ApplicationTypeID;

        public string ApplicationTypeName
        {
            get
            {
                switch (ApplicationTypeID)
                {
                    case enAppType.NewInternationalLicense:
                        {
                            return "New International License";
                        }
                    case enAppType.NewLocalDrivingLicenseService:
                        {
                            return "New Local Driving License Service";
                        }
                    case enAppType.RenewDrivingLicenseService:
                        {
                            return "Renew Driving License Service";
                        }
                    case enAppType.ReplacementforaLostDrivingLicense:
                        {
                            return "Replacement for a Lost Driving License";
                        }
                    case enAppType.ReplacementforaDamagedDrivingLicense:
                        {
                            return "Replacement for a Damaged Driving License";
                        }
                    case enAppType.ReleaseDetainedDrivingLicsense:
                        {
                            return "Release Detained Driving Licsense";
                        }



                    default: return "None";


                }
                












            }
        }
    }
}
                   

