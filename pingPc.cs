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
    public partial class pingPc : Form
    {
        public pingPc()
        {
            InitializeComponent();
        }
        private void btnPingPcOK_Click(object sender, EventArgs e)
        {
            string hostname = "AMMVWCZD81T3-L";//txtPingPc.Text;"AMMVWCZD81T3-L"
            try
            {
                string[] result = Functions.pingHostname(hostname);
                if (result != null)
                {
                    rtxtPingPc.Text = hostname.ToUpper() + " / " + result[0] + " is Online";
                }
                else
                {
                    rtxtPingPc.Text = hostname.ToUpper() + " is Offline";
                }
            }
            catch
            {
                rtxtPingPc.Text = "Invalid Entry";
            }
        }
    }
}
