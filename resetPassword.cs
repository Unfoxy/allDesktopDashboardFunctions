using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace desktopDashboard___Y_Lee.Forms
{
    public partial class resetPassword : Form
    {
        public resetPassword()
        {
            InitializeComponent();
        }

        private void btnResetPasswordOK_Click(object sender, EventArgs e)
        {
            string username = "txd47487";//txtResetPassword.Text;
            try
            {
                string[] usernameAD = Functions.GetAD(username);
                if (usernameAD == null)
                {
                    rtxtResetPassword.Text = "Invalid Username Entry" + "\nUsername: " + username.ToUpper() + " is Incorrect";
                }
                else
                {
                    string answer = MessageBox.Show("Please Confirm again " + "\nUser ID: " + username.ToUpper() + "\nUser name: " + usernameAD[0],
                    "Desktop Dashboard", MessageBoxButtons.YesNo, MessageBoxIcon.Warning).ToString();

                    if (answer == "Yes")
                    {
                        Functions.resetPassword(username);
                        rtxtResetPassword.Text = "Passowrd Reset Completed" + "\nUser ID: " + username.ToUpper() + "\nUser name: " + usernameAD[0] + "\nNew Password is 'Ineos2023'";
                    }
                    else
                    {
                        rtxtResetPassword.Text = "Password Reset Cancelled";
                    }
                }
            }
            catch
            {
                rtxtResetPassword.Text = "Invalid Entry";
            }
        }
    }
}
