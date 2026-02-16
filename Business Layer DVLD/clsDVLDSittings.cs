using DTO.DVLD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace Business_Layer_DVLD
{
    public class clsDVLDSittings
    {

        public static clsUsers _CurrentUser;
        



        public static bool GetCurrentUser(string UserName,string Password)
        {
            DTOUsers User =new DTOUsers();
            _CurrentUser = clsUsers.FindCurrentUser(User,Password,UserName);

            if (_CurrentUser == null)
            {
                return false;
                

            }
            else
                return true;
        }

        public static string ComputeHashing(string Input)
        {

            
            using(SHA256 sHA256 = SHA256.Create())
            {

                byte[] Hashed=sHA256.ComputeHash(Encoding.UTF8.GetBytes(Input));

                return BitConverter.ToString(Hashed).Replace("-","").ToLower();

            }





        }


    }
}
