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
    public partial class createUser : Form
    {
        public createUser()
        {
            InitializeComponent();
        }

        private void btnCreateUserOK_Click(object sender, EventArgs e)
        {
            Functions.createUser();
            rtxtCreateUser.Text = "done";
        }
    }
}
