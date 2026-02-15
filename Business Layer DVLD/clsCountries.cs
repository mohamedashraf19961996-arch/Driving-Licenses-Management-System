using Data_Layer_DVLD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer_DVLD
{
    public class clsCountries
    {
       public string _CountryName {  get; set; }
        public int _CountryID {  get; set; }

        private clsCountries(int CountryID,string CountryName)
        {
            _CountryID = CountryID;
            _CountryName = CountryName;


        }
        public static DataTable ListCountries()
        {

            return clsCountriesDL.ListCountries();

        }

        public static clsCountries FindCountry(string CountryName)
        {
            int CountryID = -1;
            if (clsCountriesDL.FindCountry(ref CountryID, CountryName))
            {
                return new clsCountries(CountryID, CountryName);
            }
            else return null;


        }

        public static clsCountries FindCountry(int CountryID)
        {
            string CountryName = "";
            if (clsCountriesDL.FindCountry( CountryID,ref CountryName))
            {
                return new clsCountries(CountryID, CountryName);
            }
            else return null;


        }
    }
}
