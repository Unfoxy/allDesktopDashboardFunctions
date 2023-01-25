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
    public partial class lookupUser : Form
    {
        public lookupUser()
        {
            InitializeComponent();
        }

        private void btnLookupUserOK_Click(object sender, EventArgs e)
        {
            string inputUsername = "yxl13153";//txtLookupUser.Text;
            string[] results = new string[2] { "", "" };
            try
            {
                results = Functions.GetAD(inputUsername);
                if (results != null)
                {
                    rtxtLookupUser.Text = "Name is: " + results[0] + "\nEmail is: " + results[1];
                }
                else
                {
                    rtxtLookupUser.Text = "Invalid Entry" + "\n" + inputUsername.ToUpper() + " is Not Correct";
                }
            }
            catch
            {
                rtxtLookupUser.Text = "Invalid Entry";
            }
        }
    }
}
