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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }
        public int ActiveEmployeeID;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            panel1.Controls.Clear(); // Panel'in içini temizliyoruz..
            Members frm2 = new Members();
            frm2.TopLevel = false;
            panel1.Controls.Add(frm2); // panel1 içerisinde formu ekledik
            frm2.Show(); // formu gösterdik. Ancak buraya dikakt. ShowDialog(); olarak değil Show(); olarak açıyoruz.
            frm2.Dock = DockStyle.Fill; // Açılan formun paneli doldurmasını sağladık.
            frm2.BringToFront(); // formu panel içinde en öne getirdik
        }
        private void SelectedFormPanelBackColor()
        {
            pnl_Members.BackColor = Color.DarkSlateGray;
            pnl_Employees.BackColor = Color.DarkSlateGray;
            pnl_Languages.BackColor = Color.DarkSlateGray;
            pnl_Categories.BackColor = Color.DarkSlateGray;
            pnl_Authors.BackColor = Color.DarkSlateGray;
            pnl_Books.BackColor = Color.DarkSlateGray;
            pnl_Publisher.BackColor = Color.DarkSlateGray;
            pnl_Entrust.BackColor = Color.DarkSlateGray;
            pnl_ReturnExtendTime.BackColor = Color.DarkSlateGray;
            panel12.BackColor = Color.DarkSlateGray;
        }
        private void pnl_Members_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            SelectedFormPanelBackColor();
            pnl_Members.BackColor = Color.DarkGreen;
            Members frm2 = new Members();
            frm2.TopLevel = false;
            panel1.Controls.Add(frm2);
            frm2.Show();
            frm2.Dock = DockStyle.Fill;
            frm2.BringToFront();
        }
        private void pnl_Employees_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            SelectedFormPanelBackColor();
            pnl_Employees.BackColor = Color.DarkGreen;
            Employees frm2 = new Employees();
            frm2.TopLevel = false;
            panel1.Controls.Add(frm2);
            frm2.ActiveEmployeeID = this.ActiveEmployeeID;
            frm2.Show();
            frm2.Dock = DockStyle.Fill;
            frm2.BringToFront();
        }
        private void pnl_Languages_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            SelectedFormPanelBackColor();
            pnl_Languages.BackColor = Color.DarkGreen;
            Languages frm2 = new Languages();
            frm2.TopLevel = false;
            panel1.Controls.Add(frm2);
            frm2.Show();
            frm2.Dock = DockStyle.Fill;
            frm2.BringToFront();
        }
        private void pnl_Authors_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            SelectedFormPanelBackColor();
            pnl_Authors.BackColor = Color.DarkGreen;
            Authors frm2 = new Authors();
            frm2.TopLevel = false;
            panel1.Controls.Add(frm2);
            frm2.Show();
            frm2.Dock = DockStyle.Fill;
            frm2.BringToFront();
        }
        private void pnl_Categories_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            SelectedFormPanelBackColor();
            pnl_Categories.BackColor = Color.DarkGreen;
            Categories frm2 = new Categories();
            frm2.TopLevel = false;
            panel1.Controls.Add(frm2);
            frm2.Show();
            frm2.Dock = DockStyle.Fill;
            frm2.BringToFront();
        }
        private void pnl_Books_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            SelectedFormPanelBackColor();
            pnl_Books.BackColor = Color.DarkGreen;
            Books frm2 = new Books();
            frm2.TopLevel = false;
            panel1.Controls.Add(frm2);
            frm2.Show();
            frm2.Dock = DockStyle.Fill;
            frm2.BringToFront();
        }
        private void pnl_Publisher_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            SelectedFormPanelBackColor();
            pnl_Publisher.BackColor = Color.DarkGreen;
            Publishers frm2 = new Publishers();
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

        private void pnl_Requests_Click(object sender, EventArgs e)
        {
           panel1.Controls.Clear();
            SelectedFormPanelBackColor();

            RequestsAndComments frm2 = new RequestsAndComments();
            frm2.TopLevel = false;
            panel1.Controls.Add(frm2);
        
            frm2.Show();
            frm2.Dock = DockStyle.Fill;
            frm2.BringToFront();
        }

        private void pnl_deletedPage_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            SelectedFormPanelBackColor();
           
            DeletedNotePage frm2 = new DeletedNotePage();
            frm2.TopLevel = false;
            panel1.Controls.Add(frm2);

            frm2.Show();
            frm2.Dock = DockStyle.Fill;
            frm2.BringToFront();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

            panel1.Controls.Clear();
            SelectedFormPanelBackColor();

            MoneyTransactions frm2 = new MoneyTransactions();
            frm2.activeEmployeeID = this.ActiveEmployeeID;
            frm2.TopLevel = false;
            panel1.Controls.Add(frm2);

            frm2.Show();
            frm2.Dock = DockStyle.Fill;
            frm2.BringToFront();
        }
    }
}
