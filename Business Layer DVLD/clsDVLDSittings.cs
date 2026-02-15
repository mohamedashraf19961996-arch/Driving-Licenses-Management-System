using DTO.DVLD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


    }
}
