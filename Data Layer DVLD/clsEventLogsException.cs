using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer_DVLD
{
    internal class clsEventLogsException
    {

        public static void AddExceptionToEventLog(string Message)
        {
            string SourceName = "DVLD.App";

            if (!EventLog.SourceExists(SourceName))
            {

                EventLog.CreateEventSource(SourceName, "Application");
                
            }

            EventLog.WriteEntry(SourceName, Message, EventLogEntryType.Error);






        }



    }
}
