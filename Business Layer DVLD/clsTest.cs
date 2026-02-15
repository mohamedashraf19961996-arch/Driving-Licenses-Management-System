using Data_Layer_DVLD;
using DTO.DVLD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer_DVLD
{
    public class clsTest
    {
      public  DTOTests _TestInformation;
        public clsTestAppointment _TestAppointment;
        public clsUsers _User;
        enum enMode { AddNew,Update}
        enMode _Mode= enMode.AddNew;

        public clsTest()
        {
            _TestInformation=new DTOTests();
            _Mode= enMode.AddNew;



        }
        
        private clsTest(DTOTests TestInformation)
        {
            _Mode = enMode.Update;
            this._TestInformation=TestInformation;
            this._TestAppointment = clsTestAppointment.Find(_TestInformation.TestAppointmentID);
            this._User=clsUsers.GetUserByUserID(_TestInformation.UserID);







        }

        public static clsTest GetTestByID(int TestID)
        {
            DTOTests Test = new DTOTests();
            if (clsTestsDL.GetTestByID(TestID, ref Test))
            {
                return new clsTest(Test);
            }
            else return null;

        }

        public static clsTest GetTestByPersonAndTestTypeAndLicenseClass(int PersonID, clsTestTypes.enTestTypeId TestTypeID,DTOLicenceClasses.enLicenceClassName LicenseClassID)
        {
            DTOTests Test = new DTOTests();
            if (clsTestsDL.GetTestByPersonAndTestTypeAndLicenseClass(PersonID,(int) TestTypeID,(int)LicenseClassID, ref Test))
            {
                return new clsTest(Test);
            }
            else return null;




        }
        public static bool Delete(int TestID)
        {

            return (clsTestsDL.DeleteTest(TestID));



        }

        private bool _AddNewTest()
        {
            this._TestInformation.TestID = clsTestsDL.AddNewTest(this._TestInformation);


                return (this._TestInformation.TestID != -1);

        }

        private bool _UpdateTest() {


            return (clsTestsDL.UpdateTest(this._TestInformation));



        }

        public bool Save()
        {
            switch(_Mode)
            {
                case enMode.AddNew:
                    {
                        _Mode = enMode.Update;
                        if (_AddNewTest())
                        {
                            return true;
                        }
                        else return false;


                        
                    }
                case enMode.Update:
                    {
                        return (_UpdateTest());
                    }
                default:return false;




            }





        }




    }
}
