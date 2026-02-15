using Data_Layer_DVLD;
using DTO.DVLD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer_DVLD
{
    public class clsPeople
    {

        public DTOPeople _Person {  get; set; }

       
        enum enMode { AddNew, Update }
        enMode _Mode;
        private clsPeople(DTOPeople person)
        {
           
            _Person = person;
            _Mode = enMode.Update;
        }

        public clsPeople()
        {
            _Person = new DTOPeople();
            _Mode = enMode.AddNew;


        }
        public static clsPeople Find(int PersonID)
        {
            DTOPeople person = new DTOPeople();


            if (ClsPersonDL.FindPerson(ref person, PersonID))
            {
                return new clsPeople(person);
            }
            else { return null; }



        }

        public static clsPeople Find(string NationalNo)
        {
            DTOPeople person = new DTOPeople();


            if (ClsPersonDL.FindPerson(ref person, NationalNo))
            {
                return new clsPeople(person);
            }
            else { return null; }



        }

        public static bool IsPersonExists(string NationalNo)
        {

            return ClsPersonDL.IsPersonExcist(NationalNo);


        }
         bool _AddNew(DTOPeople person)
        {

            this._Person._PersonID = ClsPersonDL.AddNewPerson(person);

            if (_Person._PersonID > 0)
            {
                this._Person = person;

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
                        _Mode = enMode.Update;
                        if (_AddNew(this._Person))
                        {
                            return true;
                        }
                        else return false;


                    }
                case enMode.Update:
                    {
                        if(_UpdatePerson(this._Person))
                        {
                            return true;
                        }else 

                            return false;


                    }
                default: return false;

            }


        }

        public static bool DeletePerson(int PersonID)
        {
            if (ClsPersonDL.DeletePerson(PersonID))
            {
                return true;

            }
            else return false;




        }

         bool _UpdatePerson(DTOPeople perosn)
        {
           

            if (ClsPersonDL.UpdatePerson(perosn))
            {
                return true;


            }
            else return false;




        }

        public static DataTable ListPeople()
        {

            return ClsPersonDL.ListPeople();


        }

        public static DataTable ListPeople(string Filter)
        {
            return ClsPersonDL.ListPeopleByFilter(Filter);
        }
        public static DataTable ListPeopleWithFirstName(string FirstName)
        {

            return ClsPersonDL.ListPeopleWithFirstName(FirstName);


        }

        public static DataTable ListPeopleWithDateOfBirthYear(int Year)
        {
            return ClsPersonDL.ListPeopleWithDateOFBirthYear(Year);
        }

        public static DataTable ListPeopleWithCountry(string Country)
        {
            return ClsPersonDL.ListPeopleWithCountry(Country);
        }

        public static DataTable ListPeopleWithSecondName(string SecondName)
        {

            return ClsPersonDL.ListpeopleWithSecondName(SecondName);


        }
        public static DataTable ListPeopleWithThirdName(string ThirdName)
        {

            return ClsPersonDL.ListPeopleWithThirdName(ThirdName);


        }
        public static DataTable ListPeopleWithForthName(string ForthName)
        {

            return ClsPersonDL.ListPeopleWithForthName(ForthName);


        }

        public static DataTable ListPeopleWithNationalNo(string NationalNo)
        {

            return ClsPersonDL.ListPeopleWithNationalNo(NationalNo);


        }
        public static DataTable ListPeopleWithAddress(string Address)
        {
            return ClsPersonDL.ListPeopleWithAddress(Address);
        }

        public static DataTable ListPeopleWithEmail(string Email)
        {
            return ClsPersonDL.ListPeopleWithEmail(Email);

        }
        public static DataTable ListPeopleWithPhoneNumber(string PhoneNumber)
        {
            return ClsPersonDL.ListPeopleWithPhoneNumber(PhoneNumber);
        }


    }
}
