using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kütüphane_Yönetim_Otomasyonu
{
    public partial class VolunteerMenu : Form
    {
        public VolunteerMenu()
        {
            InitializeComponent();
        }
        public int ActiveEmployeeID=0;
        public int ActiveEmployeePermission = 0;
     
        private void SelectedFormPanelBackColor()
        {
            pnl_Members.BackColor = Color.DarkSlateGray;
            pnl_Entrust.BackColor = Color.DarkSlateGray;
            pnl_ReturnExtendTime.BackColor = Color.DarkSlateGray;
          
        }
        private void pnl_Members_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            SelectedFormPanelBackColor();
            pnl_Members.BackColor = Color.DarkGreen;
            Members frm2 = new Members();
            frm2.ActiveEmployeeID = this.ActiveEmployeeID;
            frm2.ActiveEmployeePermission = this.ActiveEmployeePermission;
            frm2.TopLevel = false;
            panel1.Controls.Add(frm2);
            frm2.Show();
            frm2.Dock = DockStyle.Fill;
            frm2.BringToFront();
        }
        private void pnl_Entrusts_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            SelectedFormPanelBackColor();
            pnl_Entrust.BackColor = Color.DarkGreen;
            Entrust frm2 = new Entrust();
            frm2.TopLevel = false;
            panel1.Controls.Add(frm2);
            frm2.ActiveEmployeeID = this.ActiveEmployeeID;
            frm2.Show();
            frm2.Dock = DockStyle.Fill;
            frm2.BringToFront();
        }
        private void pnl_ReturnExtendTime_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            SelectedFormPanelBackColor();
            pnl_ReturnExtendTime.BackColor = Color.DarkGreen;
            ReturnExtendTime frm2 = new ReturnExtendTime();
            frm2.TopLevel = false;
            panel1.Controls.Add(frm2);
            frm2.ActiveEmployeeID = this.ActiveEmployeeID;
            frm2.Show();
            frm2.Dock = DockStyle.Fill;
            frm2.BringToFront();
        }
    }
}
