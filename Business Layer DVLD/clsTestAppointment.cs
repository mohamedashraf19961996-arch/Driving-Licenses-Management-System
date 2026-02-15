using Data_Layer_DVLD;
using DTO.DVLD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Business_Layer_DVLD.clsTestTypes;

namespace Business_Layer_DVLD
{
    public class clsTestAppointment
    {
       public   DTOTestAppointment _testAppointment;

        enum enMode { AddNew,Update};
        enMode _Mode;
        public clsUsers _User;
        public clsTestTypes testType;
        public clsLocalDrivingLicenseApplications _localDrivingLicenseApplications;
        public clsApplications _ApplicationRetakeTest;
       private clsTestAppointment(DTOTestAppointment testAppointment)
        {
           _testAppointment=testAppointment;
            _Mode = enMode.Update;
            _User=clsUsers.GetUserByUserID(_testAppointment.UserID);
            testType = clsTestTypes.Find((clsTestTypes.enTestTypeId)testAppointment.TestTypeID);
            _localDrivingLicenseApplications = clsLocalDrivingLicenseApplications.GetLocalDrivingLicenseApplicationsByID(_testAppointment.LocalDriverLicenseID);
            _ApplicationRetakeTest = clsApplications.FindBaseApp(_testAppointment.RetakeTestID);

        }
       public clsTestAppointment()
        {
            _testAppointment=new DTOTestAppointment();
            _Mode=enMode.AddNew;
        }


        public static clsTestAppointment Find(int TestAppointmentID)
        {
            DTOTestAppointment testAppointment = new DTOTestAppointment();
            if (clsTestAppointmentsDL.FindByID(TestAppointmentID, ref testAppointment))
            {

                return new clsTestAppointment(testAppointment);


            }
            else return null;




        }

        private bool _AddNew()
        {
            this._testAppointment.TestAppointmentID = clsTestAppointmentsDL.AddNewTestAppointment(_testAppointment);

            return (this._testAppointment.TestAppointmentID!=-1);


        }

        private bool _Update()
        {

            return (clsTestAppointmentsDL.UpdateTestAppointment(_testAppointment,this._testAppointment.TestAppointmentID));



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
                        if (_Update())
                        {
                            return true;
                        }
                        else return false;

                    }
                default: { return false; }



            }






        }

        public static bool Delete(int TestAppointmentId)
        {

            return clsTestAppointmentsDL.DeleteTestAppointment(TestAppointmentId);


        }

        public static DataTable GetAllTestAppointments()
        {
            return clsTestAppointmentsDL.ListTestAppoinment();
        }

        public static DataTable GetAllTestAppointmentForTestType(clsTestTypes.enTestTypeId TestType,int LocalDrivingLicenseId)
        {
            return clsTestAppointmentsDL.ListTestAppointment((int)TestType, LocalDrivingLicenseId);
        }

        
        public static clsTestAppointment GetLastTestAppointment(int LocalDriverLicenseID,clsTestTypes.enTestTypeId TestTypeID)
        {
            DTOTestAppointment testAppointment= new DTOTestAppointment();

            if (clsTestAppointmentsDL.GetLastTestAppointment(LocalDriverLicenseID, (int)TestTypeID, ref testAppointment))
            {
                return new clsTestAppointment(testAppointment);
            }
            else
                return null;


        }


    }

}
