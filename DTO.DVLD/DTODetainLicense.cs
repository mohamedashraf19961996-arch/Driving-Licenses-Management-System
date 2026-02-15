using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DVLD
{
    public class DTODetainLicense
    {
       public int DetainID=-1;

        public int LicenseID = -1;

        public DateTime DetainDate = DateTime.Now;

        public decimal FineFees = 0;

        public int CreatedByUserID = -1;

        public bool IsReleased = false;

        public DateTime ? ReleaseDate;

        public int ReleasedbyUserID = -1;

        public int ReleaseAppId = -1;



    }
}
