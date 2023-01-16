using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Runtime;
using System.Security.Policy;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using copyUserDataConsoleCsharp;
using System.Windows;
using Microsoft.VisualBasic.ApplicationServices;
using System.Diagnostics;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.ServiceProcess;
using System.Threading;
using System.Management;
using System.Runtime.Remoting.Services;
using Microsoft.Win32;

namespace copyUserDataConsoleCsharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Enter Destination Hostname:");
            string destPath = "AMMVWCZD81T3-L";//Console.ReadLine();

            //Console.WriteLine("Enter Source Hostname:");
            string sourcePath = "AMMVW5ML81T3-L";//Console.ReadLine();

            //Console.WriteLine("Enter User ID:");
            string userId = "yxl13153";//Console.ReadLine();

            Console.WriteLine("Press any key to start");
            Console.ReadLine();

            //editRegistry(destPath);
            //startupManual(destPath);
            //startStopService(destPath);
            //Console.WriteLine("Press any key to stop");
            //Console.ReadLine();
            //startupDisabled(destPath);
            //startStopService(destPath);

            //getad(userid);
            //pingpc(destpath);
            //pingpc(sourcepath);
            //copyfiles(destpath, sourcepath, userid);
            //copydirectory(destpath, sourcepath, userid);
            //getusername(userid)
            Console.WriteLine("Task Complete");
            Console.ReadLine();
        }
        
        public static void editRegistry(string hostName)
        {
            var inputRegistry = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, hostName);
            inputRegistry = inputRegistry.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Class\{4d36e972-e325-11ce-bfc1-08002be10318}\0001", true);
            inputRegistry.SetValue("*IPChecksumOffloadIPv4", "0");
        }

        public static void startupManual(string hostName)
        {
            ManagementBaseObject inParam;
            ManagementBaseObject outParam;
            int result;
            var serviceController = new ServiceController();
            ManagementObject obj = new ManagementObject(@"\\" + hostName + "\\root\\cimv2:Win32_Service.Name='RemoteRegistry'");
            try
            {
                if (obj["StartMode"].ToString() == "Disabled")
                {
                    inParam = obj.GetMethodParameters("ChangeStartMode");
                    inParam["StartMode"] = "Manual";
                    outParam = obj.InvokeMethod("ChangeStartMode", inParam, null);
                    result = Convert.ToInt32(outParam["returnValue"]);

                    if (result != 0)
                    {
                        throw new Exception("ChangeStartMode method error " + result);
                    }
                }
            }
            catch
            {
                throw;
            }
            Console.WriteLine("Change start mode Manual complete");
        }

        public static void startupDisabled(string hostName)
        {
            ManagementBaseObject inParam;
            ManagementBaseObject outParam;
            int result;
            var serviceController = new ServiceController();
            ManagementObject obj = new ManagementObject(@"\\" + hostName + "\\root\\cimv2:Win32_Service.Name='RemoteRegistry'");
            try
            {
                if (obj["StartMode"].ToString() == "Manual")
                {
                    inParam = obj.GetMethodParameters("ChangeStartMode");
                    inParam["StartMode"] = "Disabled";
                    outParam = obj.InvokeMethod("ChangeStartMode", inParam, null);
                    result = Convert.ToInt32(outParam["returnValue"]);

                    if (result != 0)
                    {
                        throw new Exception("ChangeStartMode method error " + result);
                    }
                }
            }
            catch
            {
                throw;
            }
            Console.WriteLine("Change start mode disabled complete");
        }

        private static void startStopService(string inputHostName)
        {
            try
            {
                string serviceName = "RemoteRegistry";

                ServiceController serviceController = new ServiceController("Remote Registry", inputHostName);
                ConnectionOptions connectoptions = new ConnectionOptions();
                ManagementScope scope = new ManagementScope("\\\\" + inputHostName + "\\root\\CIMV2");
                scope.Options = connectoptions;
                //WMI query to be executed on the remote machine  
                SelectQuery query = new SelectQuery("select * from Win32_Service where name = '" + serviceName + "'");
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query))
                {
                    ManagementObjectCollection collection = searcher.Get();
                    foreach (ManagementObject service in collection.OfType<ManagementObject>())
                    {
                        if (service["started"].Equals(true))
                        {
                            //Start the service  
                            service.InvokeMethod("StopService", null);
                            serviceController.WaitForStatus(ServiceControllerStatus.Stopped);
                        }
                        else
                        {
                            //Stop the service  
                            service.InvokeMethod("StartService", null);
                            serviceController.WaitForStatus(ServiceControllerStatus.Running);
                        }
                    }
                }
            }
            catch (NullReferenceException)
            {
                throw;
            }
        }

        //Local PC Start
        //private static void startService()
        //{
        //    ServiceController service = new ServiceController("RemoteRegistry");
        //    if ((service.Status.Equals(ServiceControllerStatus.Stopped)) || (service.Status.Equals(ServiceControllerStatus.StopPending)))
        //    {
        //        service.Stop();
        //    }
        //}

        static DirectoryEntry createDirectoryEntry()
        {
            DirectoryEntry ldapConnection = new DirectoryEntry("");
            ldapConnection.Path = "LDAP://OU=Client,DC=in1,DC=ad,DC=innovene,DC=com";
            ldapConnection.AuthenticationType = AuthenticationTypes.Secure;

            return ldapConnection;
        }

        private static void GetAD(string inputUsername)
        {
            try
            {
                DirectoryEntry myLdapConnection = createDirectoryEntry();
                DirectorySearcher search = new DirectorySearcher(myLdapConnection);
                search.Filter = "(samaccountname=" + inputUsername + ")";
                string[] requiredProperties = new string[] { "cn", "mail" };

                foreach (String property in requiredProperties)
                    search.PropertiesToLoad.Add(property);

                SearchResult result = search.FindOne();

                if (result != null)
                {
                    foreach (String property in requiredProperties)
                        foreach (Object myCollection in result.Properties[property])
                            Console.WriteLine(String.Format("{0,-20} : {1}",
                                          property, myCollection.ToString()));
                }
                else Console.WriteLine("User not found!");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught:\n\n" + e.ToString());
            }
        }

        private static void pingPc(string inputHostname)
        {
            try
            {
                Ping myPing = new Ping();
                PingReply reply = myPing.Send(inputHostname, 1000);
                string result = reply.Status.ToString();
                Console.WriteLine(result);
            }
            catch
            {
                Console.WriteLine("Invalid");
            }
            Console.ReadKey();
        }

        private static void copyfiles(string inputDestPath, string inputSourcePath, string inputUserId)
        {
            try
            {
                const int edgePathLength = 3;
                string[,] edgePath = new string[2, edgePathLength]{
                {@"\\" + inputSourcePath + @"\c$\users\" + inputUserId + @"\appdata\local\microsoft\edge\user data\default\bookmarks",
                 @"\\" + inputSourcePath + @"\c$\users\" + inputUserId + @"\appdata\local\microsoft\edge\user data\default\bookmarks.bak",
                 @"\\" + inputSourcePath + @"\c$\users\" + inputUserId + @"\appdata\local\microsoft\edge\user data\default\bookmarks.msbak"},
                {@"\\" + inputDestPath + @"\c$\users\" + inputUserId + @"\appdata\local\microsoft\edge\user data\default\bookmarks",
                 @"\\" + inputDestPath + @"\c$\users\" + inputUserId + @"\appdata\local\microsoft\edge\user data\default\bookmarks.bak",
                 @"\\" + inputDestPath + @"\c$\users\" + inputUserId + @"\appdata\local\microsoft\edge\user data\default\bookmarks.msbak"}
            };
                int count = 1; //Console number count
                for (int i = 0; i < edgePathLength; i++)
                {
                    File.Copy(edgePath[0, i], edgePath[1, i], true);
                    Console.WriteLine(count + " Completed");
                    count++;
                }

                Console.WriteLine("Copy file complete");
            }
            catch
            {
                Console.WriteLine("Invalid");
            }
            Console.ReadKey();
        }

        private static void copyDirectory(string inputDestPath, string inputSourcePath, string inputUserId)
        {
            try
            {
                const int quickAccessPathLength = 1;
                string[,] quickAccessPath = new string[2, quickAccessPathLength]
                {
                            {@"\\" + inputDestPath + @"\c$\users\" + inputUserId + @"\appdata\roaming\microsoft\Windows\Recent\automaticDestinations\"},
                            {@"\\" + inputSourcePath + @"\c$\users\" + inputUserId + @"\appdata\roaming\microsoft\Windows\Recent\automaticDestinations"}
                };

                var files = new DirectoryInfo(quickAccessPath[1, 0]).GetFiles("*.*");

                int count = 1; //Console number count
                foreach (FileInfo file in files)
                {
                    file.CopyTo(quickAccessPath[0, 0] + file.Name, true);
                    Console.WriteLine(count + " Completed");
                    count++;
                }

                Console.WriteLine("Copy Directory complete");

            }
            catch
            {
                Console.WriteLine("Invalid");
            }
            Console.ReadLine();
        }
    }
}