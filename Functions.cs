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
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace desktopDashboard___Y_Lee
{
    public class Functions
    {
        public static void createUser()
        {
            //try
            //{
            //    PrincipalContext pricipalContext = null;
            //    pricipalContext = new PrincipalContext(ContextType.Domain, "in1.ad.innovene.com", "OU=Client,DC=in1,DC=ad,DC=innovene,DC=com");
            //    //Sometimes we need to connect to AD using service/admin account credentials, in that case the above line of code will be as below
            //    //pricipalContext = new PrincipalContext(ContextType.Domain, "yourdomain.com", "OU=TestOU,DC=yourdomain,DC=com","YourAdminUser","YourAdminPassword");
            //    UserPrincipal up = new UserPrincipal(pricipalContext);
            //    up.SamAccountName = "yxl13153";
            //    up.DisplayName = "Test User";
            //    up.EmailAddress = "test@ineos.com";
            //    up.GivenName = "dump";
            //    up.Name = "Test User";
            //    up.Description = "User Created for testing";
            //    up.Enabled = true;
            //    up.SetPassword("Ineos2023");
            //    up.Save();
            //    MessageBox.Show("User Created");
            //}
            //catch (Exception ex)
            //{

            //}

            try
            {
                DirectoryEntry directoryEntry = new DirectoryEntry("");
                directoryEntry.Path = "LDAP://OU=Client,DC=in1,DC=ad,DC=innovene,DC=com";
                directoryEntry.AuthenticationType = AuthenticationTypes.Secure;


                DirectoryEntry childEntry = directoryEntry.Children.Add("CN=TestUser", "user");
                childEntry.Properties["samAccountName"].Value = "test12345";
                childEntry.Properties["mail"].Value = "test12345@ineos.com";
                childEntry.CommitChanges();
                directoryEntry.CommitChanges();
                childEntry.Invoke("SetPassword", new object[] { "Ineos2023" });
                childEntry.CommitChanges();
                MessageBox.Show("User Created");
            }
            catch (Exception ex)
            {

            }
        }
        public static void resetPassword(string userName)
        {
            PrincipalContext context = new PrincipalContext(ContextType.Domain);
            UserPrincipal user = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, userName);
            //Enable Account if it is disabled
            user.Enabled = true;
            //Reset User Password
            user.SetPassword("Ineos2023");
            //Force user to change password at next logon
            user.ExpirePasswordNow();
            user.Save();
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
            //int result;
            var serviceController = new ServiceController();
            ManagementObject obj = new ManagementObject(@"\\" + hostName + "\\root\\cimv2:Win32_Service.Name='RemoteRegistry'");
            try
            {
                if (obj["StartMode"].ToString() == "Disabled")
                {
                    inParam = obj.GetMethodParameters("ChangeStartMode");
                    inParam["StartMode"] = "Manual";
                    outParam = obj.InvokeMethod("ChangeStartMode", inParam, null);
                    //result = Convert.ToInt32(outParam["returnValue"]);
                    //if (result != 0)
                    //{
                    //    throw new Exception("ChangeStartMode method error " + result);
                    //}
                }
            }
            catch
            {
                MessageBox.Show("failed");
            }
        }
        public static void startupDisabled(string hostName)
        {
            ManagementBaseObject inParam;
            ManagementBaseObject outParam;
            //int result;
            var serviceController = new ServiceController();
            ManagementObject obj = new ManagementObject(@"\\" + hostName + "\\root\\cimv2:Win32_Service.Name='RemoteRegistry'");
            try
            {
                if (obj["StartMode"].ToString() == "Manual")
                {
                    inParam = obj.GetMethodParameters("ChangeStartMode");
                    inParam["StartMode"] = "Disabled";
                    outParam = obj.InvokeMethod("ChangeStartMode", inParam, null);
                    //result = Convert.ToInt32(outParam["returnValue"]);

                    //if (result != 0)
                    //{
                    //    throw new Exception("ChangeStartMode method error " + result);
                    //}
                }
            }
            catch
            {
                MessageBox.Show("failed");
            }
        }
        public static void startStopService(string inputHostName)
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
        public static string[] GetAD(string inputUsername)
        {
            try
            {
                DirectoryEntry ldapConnection = new DirectoryEntry("");
                ldapConnection.Path = "LDAP://OU=Client,DC=in1,DC=ad,DC=innovene,DC=com";
                ldapConnection.AuthenticationType = AuthenticationTypes.Secure;
                DirectorySearcher search = new DirectorySearcher(ldapConnection);

                search.Filter = "(samaccountname=" + inputUsername + ")";
                string[] requiredProperties = new string[] { "cn", "mail" };

                foreach (String property in requiredProperties)
                    search.PropertiesToLoad.Add(property);

                SearchResult result = search.FindOne();

                if (result != null)
                {
                    string[] results = new string[2] { "", "" };
                    int i = 0;
                    foreach (String property in requiredProperties)
                        foreach (Object myCollection in result.Properties[property])
                        {
                            if (results[i] != "")
                                i++;
                            results[i] = myCollection.ToString();
                        }                            
                    return results;
                }
                else
                {
                    return null;
                }     
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public static string[] pingHostname(string inputHostname)
        {
            
            Ping myPing = new Ping();
            string[] pingResults = new string[2] { "", "" };
            try
            {
                PingReply reply = myPing.Send(inputHostname, 10000);

                if (reply.Status.ToString() == "Success")
                {
                    pingResults[0] = reply.Address.ToString();
                    pingResults[1] = reply.RoundtripTime.ToString();
                    return pingResults;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception e)
            {
                return null;
            }
        }
        public static void copyfiles(string newPc, string oldPc, string userId, string item)
        {

            if(item == "Edge")
            {
                string[,] edge = edgePath(newPc, oldPc, userId);
                for (int i = 0; i < 3; i++)
                {
                    File.Copy(edge[0, i], edge[1, i], true);
                }
            }
            else if(item == "Chrome")
            {
                string[,] edge = chromePath(newPc, oldPc, userId);
                for (int i = 0; i < 2; i++)
                {
                    File.Copy(edge[0, i], edge[1, i], true);
                }
            }
        }
        public static void copyDirectory(string inputDestPath, string inputSourcePath, string inputUserId, string item)
        {
            if (item == "Quick Access")
            {
                string[,] quickAccess = quickAccessPath(inputDestPath, inputSourcePath, inputUserId);
                var files = new DirectoryInfo(quickAccess[1, 0]).GetFiles("*.*");

                foreach (FileInfo file in files)
                {
                    file.CopyTo(quickAccess[0, 0] + file.Name, true);
                }
            }
            if (item == "Outlook Signatures")
            {
                string[,] outlookSignatures = outlookSignaturesPath(inputDestPath, inputSourcePath, inputUserId);
                var files = new DirectoryInfo(outlookSignatures[1, 0]).GetFiles("*.*");

                string signaturesFoler = @"\\" + inputDestPath + @"\c$\users\" + inputUserId + @"\appdata\roaming\microsoft\Signatures";
                if (!Directory.Exists(signaturesFoler))
                {
                    Directory.CreateDirectory(signaturesFoler);
                }
                
                foreach (FileInfo file in files)
                {
                    file.CopyTo(outlookSignatures[0, 0] + file.Name, true);
                }
            }
        }
        public static string[,] edgePath(string newPc, string oldPc, string username)
        {
            string[,] edgePath = new string[2, 3]
            {
                { @"\\" + oldPc + @"\c$\users\" + username + @"\appdata\local\microsoft\edge\user data\default\bookmarks",
                    @"\\" + oldPc + @"\c$\users\" + username + @"\appdata\local\microsoft\edge\user data\default\bookmarks.bak",
                    @"\\" + oldPc + @"\c$\users\" + username + @"\appdata\local\microsoft\edge\user data\default\bookmarks.msbak" },
                { @"\\" + newPc + @"\c$\users\" + username + @"\appdata\local\microsoft\edge\user data\default\bookmarks",
                    @"\\" + newPc + @"\c$\users\" + username + @"\appdata\local\microsoft\edge\user data\default\bookmarks.bak",
                    @"\\" + newPc + @"\c$\users\" + username + @"\appdata\local\microsoft\edge\user data\default\bookmarks.msbak" }
            };
            return edgePath;
        }
        public static string[,] chromePath(string newPc, string oldPc, string username)
        {
            string[,] chromePath = new string[2, 2]
            {
                { @"\\" + oldPc + @"\c$\users\" + username + @"\appdata\local\google\chrome\user data\default\bookmarks",
                    @"\\" + oldPc + @"\c$\users\" + username + @"\appdata\local\google\chrome\user data\default\bookmarks.bak",},
                { @"\\" + newPc + @"\c$\users\" + username + @"\appdata\local\google\chrome\user data\default\bookmarks",
                    @"\\" + newPc + @"\c$\users\" + username + @"\appdata\local\google\chrome\user data\default\bookmarks.bak",}
            };
            return chromePath;
        }
        public static string[,] quickAccessPath(string newPc, string oldPc, string username)
        {
            string[,] quickAccessPath = new string[2, 1]
            {
                { @"\\" + newPc + @"\c$\users\" + username + @"\appdata\roaming\microsoft\Windows\Recent\automaticDestinations\"},
                {@"\\" + oldPc + @"\c$\users\" + username + @"\appdata\roaming\microsoft\Windows\Recent\automaticDestinations"}
            };
            return quickAccessPath;
        }
        public static string[,] outlookSignaturesPath(string newPc, string oldPc, string username)
        {
            string[,] outlookSignaturesPath = new string[2, 1]
            {
                { @"\\" + newPc + @"\c$\users\" + username + @"\appdata\roaming\microsoft\Signatures\"},
                {@"\\" + oldPc + @"\c$\users\" + username + @"\appdata\roaming\microsoft\Signatures"}
            };
            return outlookSignaturesPath;
        }
    }
}