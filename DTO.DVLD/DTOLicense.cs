using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DVLD
{
    public class DTOLicense
    {
        public int LicenseID;

        public int ApplicationID=-1;

        public int DriverID = -1;

        public int LicenseClassID = -1;

        public DateTime IssueDate=DateTime.Now;

        public DateTime ExpirationDate= DateTime.Now;

        public string Notes = "";

        public decimal PaidFees = 0;

        public bool IsActive;

        public enum enIssueReason: byte { FirstTime=1,Renew=2,ReplacementForDamaged=3,ReplacementForLost=4}
        public enIssueReason issueReason = enIssueReason.FirstTime;
        
            

        
        public int CreatedByUserID = -1;






    }
}
