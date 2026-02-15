using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using Microsoft.Win32;
namespace DVLD
{
    [Serializable]

    public class Login
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Rememberme { get; set; }

    }

    internal class clsUtils
    {
       static string _FileDestintion = @"D:\UserLogin2.txt";
        public static bool CreateFileISNotExsit(string DestinationFile)
        {
            if (!Directory.Exists(DestinationFile))
            {


                Directory.CreateDirectory(DestinationFile);
                return false;
            }
            else return true;

        }

        public static string GenerateGuid()
        {
            return Guid.NewGuid().ToString();
        }
        public static string ReplaceFileNameWithGuid(string SourceFile)
        {
            string extension = Path.GetExtension(SourceFile);
            return $"{Guid.NewGuid()}{extension}";
        }
        public static bool CopyImagesToProjectImagesFile(ref string SourceFile)
        {

            if(string.IsNullOrEmpty(SourceFile))
            {
                return false;
            }

            string DestinationFolder = @"D:\Images";

            if(!CreateFileISNotExsit(DestinationFolder))
            {
                MessageBox.Show("Image Folder is not exist");
                return false;
            }

             string DestinationFile=Path.Combine(DestinationFolder,ReplaceFileNameWithGuid(SourceFile));
            try
            {
                File.Copy(SourceFile, DestinationFile, true);
            }catch(IOException iox)
            {
                MessageBox.Show(iox.Message, "Error");
                return false;


            }
          SourceFile= DestinationFile;
            return true;
        }


        public static bool CopyLoginInfoToTextFile(string UserName,string Password)
        {
            //if (string.IsNullOrEmpty(UserName)||string.IsNullOrEmpty(Password))
            //{
            //    return false;
            //}
            //Login Loginobj = new Login();

            //Loginobj.UserName= UserName;
            //Loginobj.Password= Password;
            //Loginobj.Rememberme= remeberMe;

            //XmlSerializer serlizer = new XmlSerializer(typeof(Login));
            //string path = @"D:\DVLD\UserLogin10.xml";

            //using (TextWriter writer = new StreamWriter(path))
            //{
            //    serlizer.Serialize(writer, Loginobj);
            //}

            //    return true;

            string keyPath = @"HKEY_CURRENT_USER\Software\DVLD";
            string ValueName = "UserName";
            string ValueData = UserName;

            string ValueName1 = "Password";
            string ValueData1 = Password;
            try
            {
                Registry.SetValue(keyPath, ValueName, ValueData,RegistryValueKind.String);
                Registry.SetValue(keyPath, ValueName1, ValueData1, RegistryValueKind.String);
                return true;

            }
            catch (IOException iox)
            {
                MessageBox.Show(iox.Message);
                return false;
            }


        }

        public static void RestoreLoginInfo(ref string UserName,ref string Password)
        {
            
            //string[] data = File.ReadAllText(_FileDestintion).Split(',');

            // UserName=data[0];
            // Password=data[1];
            // RemeberMe=data[2];
            //XmlSerializer serlizer = new XmlSerializer(typeof(Login));
            //string path = @"D:\DVLD\UserLogin10.xml";

            //using (TextReader reader=new StreamReader(path))
            //{
            //    Login Deselrization=(Login)serlizer.Deserialize(reader);

            //    if(Deselrization!=null)
            //    {
            //        UserName=Deselrization.UserName;
            //        Password=Deselrization.Password;
            //        RemeberMe = Deselrization.Rememberme;
            //    }

            //}

            string Keypath= @"HKEY_CURRENT_USER\Software\DVLD";
            string ValueName = "UserName";

            string ValueName1= "Password";

            try
            {
               string ValueData=Registry.GetValue(Keypath, ValueName,null) as string;
                string ValueData1 = Registry.GetValue(Keypath, ValueName1, null) as string;

                if (ValueData != null&&ValueData1!=null)
                {
                    UserName=ValueData;
                    Password=ValueData1;
                    
                }

            }catch(IOException e)
            {
                MessageBox.Show(e.Message);
            }



        }

        public static void AddLogingAsEventLog(string Message,EventLogEntryType eventLogEntryType)
        {
            string SourceName = "DVLD.App";

            if (!EventLog.SourceExists(SourceName))
            {

                EventLog.CreateEventSource(SourceName,"Application");
                MessageBox.Show("Created Log Done","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);

            }

            EventLog.WriteEntry(SourceName, Message,eventLogEntryType);


        }


    }
}
