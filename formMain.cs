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
    public partial class formMain : Form
    {
        public formMain()
        {
            InitializeComponent();
            hideSubMenu();
        }

        void hideSubMenu()
        {
            foreach (var pn in pnMenu.Controls.OfType<Panel>())
                pn.Height = 50;
        }

        void showSubMenu(Panel pn)
        {
            pn.Height = pn.Controls.OfType<Button>().Count() * 25 + 25;
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void btnUtilitytools_Click(object sender, EventArgs e)
        {
            hideSubMenu(); 
            showSubMenu(pnDrUtilitytools);
        }

        private void btnTroubleshootingtools_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            showSubMenu(pnDrTroubleshootingtools);
        }

        private void btnActivedirectory_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            showSubMenu(pnDrActivedirectory);
        }
        private void btnLookupUser_Click(object sender, EventArgs e)
        {
            var myForm = new lookupUser();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            this.pnMain.Controls.Add(myForm);
            myForm.BringToFront();
            myForm.Show();
        }

        private void btnRemoteRegistryEdit_Click(object sender, EventArgs e)
        {
            var myForm = new remoteRegistry();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            this.pnMain.Controls.Add(myForm);
            myForm.BringToFront();
            myForm.Show();
        }

        private void btnResetpassword_Click(object sender, EventArgs e)
        {
            var myForm = new resetPassword();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            this.pnMain.Controls.Add(myForm);
            myForm.BringToFront();
            myForm.Show();
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            var myForm = new createUser();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            this.pnMain.Controls.Add(myForm);
            myForm.BringToFront();
            myForm.Show();
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            var myForm = new deleteUser();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            this.pnMain.Controls.Add(myForm);
            myForm.BringToFront();
            myForm.Show();
        }

        private void btnLoopupHostname_Click(object sender, EventArgs e)
        {
            var myForm = new lookupHostname();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            this.pnMain.Controls.Add(myForm);
            myForm.BringToFront();
            myForm.Show();
        }

        private void btnPingPc_Click(object sender, EventArgs e)
        {
            var myForm = new pingPc();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            this.pnMain.Controls.Add(myForm);
            myForm.BringToFront();
            myForm.Show();
        }

        private void btnDatamigration_Click(object sender, EventArgs e)
        {
            var myForm = new dataMigration();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            this.pnMain.Controls.Add(myForm);
            myForm.BringToFront();
            myForm.Show();
        }

        private void pbExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
