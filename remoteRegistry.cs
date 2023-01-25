using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace desktopDashboard___Y_Lee.Forms
{
    public partial class remoteRegistry : Form
    {
        public remoteRegistry()
        {
            InitializeComponent();
        }

        private void btnRemoteRegistryOK_Click(object sender, EventArgs e)
        {
            string hostname = "AMMVWCZD81T3-L";//txtRemoteRegistry.Text;
            string item = comboxRemoteRegistry.Text.ToString();

            try
            {
                string answer = MessageBox.Show("Please Confirm Again " + "PC Name: " + hostname.ToUpper() + "\nCategory: " + item,
                "Desktop Dashboard", MessageBoxButtons.YesNo, MessageBoxIcon.Warning).ToString();
                if (answer == "Yes")
                {
                    string[] pingTesting = Functions.pingHostname(hostname);

                    if (pingTesting != null)
                    {
                        rtxtRemoteRegistry.Text = item + " Request Start...";
                        rtxtRemoteRegistry.AppendText(Environment.NewLine + "Change RemoteRegistry Startup to Manual...");
                        Functions.startupManual(hostname);
                        rtxtRemoteRegistry.AppendText(Environment.NewLine + "Start RemoteRegistry Service...");
                        Functions.startStopService(hostname);
                        rtxtRemoteRegistry.AppendText(Environment.NewLine + "Edit 'IPChecksumOffloadIPv4' Value...");
                        Functions.editRegistry(hostname);
                        rtxtRemoteRegistry.AppendText(Environment.NewLine + "Disable RemoteRegistry Startup to Disabled...");
                        Functions.startupDisabled(hostname);
                        rtxtRemoteRegistry.AppendText(Environment.NewLine + "Stop RemoteRegistry Service...");
                        Functions.startStopService(hostname);
                        rtxtRemoteRegistry.AppendText(Environment.NewLine + item + "Request Completed");
                    }
                    else
                    {
                        rtxtRemoteRegistry.Text = "PC Status Error" + "\nPC: " + hostname.ToUpper() + " Not Online";
                    }
                }
                else
                {
                    rtxtRemoteRegistry.Text = item + " Request Cancelled";
                }
            }
            catch
            {
                rtxtRemoteRegistry.Text = "Invalid Entry";
            }
        }
    }
}
