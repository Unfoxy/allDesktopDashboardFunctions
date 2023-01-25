using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace desktopDashboard___Y_Lee.Forms
{
    public partial class dataMigration : Form
    {
        public dataMigration()
        {
            InitializeComponent();
        }

        private void btnDataMigrationOK_Click(object sender, EventArgs e)
        {
            string newPc = "AMMVWCZD81T3-L";     //txtDataMigrationNewPc.Text;
            string oldPc = "AMMVW5ML81T3-L";   //txtDataMigrationOldPc.Text;
            string username = "yxl13153";//txtDataMigrationUserId.Text;
            string item = comboxDataMigration.Text.ToString();

            try
            {
                string[] usernameAD = Functions.GetAD(username);
                if (usernameAD == null)
                {
                    rtxtDataMigration.Text = "Invalid Username Entry" + "\nUsername: " + username.ToUpper() + " is Incorrect";
                }
                else
                {
                    string answer = MessageBox.Show("Please Confirm Again " + "\nNew PC: " + newPc.ToUpper() + "\nOld PC: " + oldPc.ToUpper() + "\nUser ID: " + username.ToUpper() + "\nUser name: " + usernameAD[0],
                "Desktop Dashboard", MessageBoxButtons.YesNo, MessageBoxIcon.Warning).ToString();

                    if (answer == "Yes")
                    {
                        string[] newPcTesting = Functions.pingHostname(newPc);
                        string[] oldPcTesting = Functions.pingHostname(oldPc);

                        if (newPcTesting != null && oldPcTesting != null)
                        {
                            if (item == "Chrome" || item == "Edge")
                            {
                                Functions.copyfiles(newPc, oldPc, username, item);
                                rtxtDataMigration.Text = item + " Bookmarks Transfer Done";
                            }
                            else if (item == "Quick Access" || item == "Outlook Signatures")
                            {
                                Functions.copyDirectory(newPc, oldPc, username, item);
                                rtxtDataMigration.Text = item + " Transfer Done";
                            }
                        }
                        else
                        {
                            string displayMessageNew;
                            string displayMessageOld;
                            if (newPcTesting == null)
                            {
                                displayMessageNew = "Offline";
                            }
                            else
                            {
                                displayMessageNew = "Online";
                            }
                            if (oldPcTesting == null)
                            {
                                displayMessageOld = "Offline";
                            }
                            else
                            {
                                displayMessageOld = "Online";
                            }
                            rtxtDataMigration.Text = "PC Status Error" + "\nNew PC: " + newPc.ToUpper() + " Status " + displayMessageNew + "\nOld PC: " + oldPc.ToUpper() + " Status " + displayMessageOld;
                        }
                    }
                    else
                    {
                        rtxtDataMigration.Text = item + " Transfer Request Cancelled";
                    }
                }
            }
            catch
            {
                rtxtDataMigration.Text = "Invalid Entry. Please Verify Correct Username and PC Names";
            }
        }
    }
}