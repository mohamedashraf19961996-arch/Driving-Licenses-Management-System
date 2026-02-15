using Data_Layer_DVLD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer_DVLD
{
    public class clsTestTypes
    {
        public string _TestTitle;

        public string _TestDescription;

        public enTestTypeId _TestID;

        public decimal _TestFees;

        enum enMode { AddNew,Update}
        enMode _Mode;
        public enum enTestTypeId { VisionTest=1,WrittenTest=2,StreetTest=3}
      public clsTestTypes()
        {
            _TestID = enTestTypeId.VisionTest;
            _TestTitle = "";
            _TestDescription = "";
            _TestFees = 0;
            _Mode=enMode.AddNew;


        }

        private clsTestTypes(enTestTypeId TestID,string TestTitle,string TestDesc,decimal TestFees)
        {
            _TestID=TestID;
            _TestTitle=TestTitle;
            _TestDescription=TestDesc;
            _TestFees=TestFees;
            _Mode = enMode.Update;



        }

        public static clsTestTypes Find(clsTestTypes.enTestTypeId TestID)
        {
           string TestTitle=""; string TestDesc=""; decimal TestFees = 0;

            if (clsTestTypesDL.GetTestTypeByID((int)TestID,ref TestTitle,ref TestDesc,ref TestFees))
            {
                return new clsTestTypes(TestID, TestTitle, TestDesc, TestFees);
            }
            else
                return null;

        }

        public static DataTable ListTestTypes()
        {
            return clsTestTypesDL.ListTestTypes();
        }

        private bool _UpdateTestType()
        {
            return (clsTestTypesDL.UpdateTestType((int)this._TestID,this._TestTitle,this._TestDescription,this._TestFees));
        }
        public bool Save()
        {
            return (_UpdateTestType());
        }



    }
}
