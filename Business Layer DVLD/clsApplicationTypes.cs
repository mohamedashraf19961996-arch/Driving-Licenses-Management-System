using Data_Layer_DVLD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer_DVLD
{
    public class clsApplicationTypes
    {
        public int _AppID {  get; set; }

        public string _AppName {  get; set; }

        public decimal _AppFees {  get; set; }

        enum enMode { AddNew,Update};
        enMode _Mode= enMode.AddNew;
        public enum enAppType
        {
            NewDrivingLicence = 1, RenewDrivingLicence = 2, ReplaceLostDrivingLicence = 3, ReplaceDamageDrivingLicence = 4
         , ReleaseDetainDrivingLicence = 5, NewInternationalDrivingLicence = 6,RetakeTest=7
        }

        public enAppType _AppType;

        public clsApplicationTypes()
        {
            _AppName = "";
            _AppFees = 0;
            _AppID = -1;

            _Mode = enMode.AddNew;
        }
        private clsApplicationTypes(int AppID,string AppName,decimal AppFees)
        {
            _AppID = AppID;
            _AppName = AppName;
            _AppFees = AppFees;
            _Mode = enMode.Update;

        }

        public static clsApplicationTypes FindApptype(enAppType AppID)
        {
            string AppName = "";decimal AppFees = 0;
            if (clsApplicationTypesDL.FindApplicationType((int)AppID, ref AppName, ref AppFees))
            {
                return new clsApplicationTypes((int)AppID, AppName, AppFees);
            }
            else return null;


        }
        private bool EditApptype()
        {
            if(clsApplicationTypesDL.UpdateApplicationTypes(this._AppID,this._AppName,this._AppFees))
            {
                return true;
            }else return false;



        }

        
        public bool Save()
        {
            switch(_Mode)
            {
                case enMode.Update:
                    {

                        if (EditApptype())
                        {
                            return true;
                        }
                        else return false;
                    }
                case enMode.AddNew:
                    {
                        _Mode = enMode.Update;
                        return false;
                        

                    }
                default:return false;



            }


        }

       public static DataTable ListAppType()
        {

            return clsApplicationTypesDL.ListApplicationTypes();


        }

    }
}
