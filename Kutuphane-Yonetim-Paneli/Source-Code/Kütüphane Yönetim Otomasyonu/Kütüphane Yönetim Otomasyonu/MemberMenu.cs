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
    public partial class MemberMenu : Form
    {
        public MemberMenu()
        {
            InitializeComponent();
        }
       
        public int ActiveMemberID;
       
        private void SelectedFormPanelBackColor()
        {
            pnl_Members.BackColor = Color.DarkSlateGray;
        }
        private void pnl_Members_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            SelectedFormPanelBackColor();
            pnl_Members.BackColor = Color.DarkGreen;
            MemberProfile frm2 = new MemberProfile();
            frm2.ActiveMemberID=ActiveMemberID;
            frm2.TopLevel = false;
            panel1.Controls.Add(frm2);
            frm2.Show();
            frm2.Dock = DockStyle.Fill;
            frm2.BringToFront();
        }
     
    }
}
