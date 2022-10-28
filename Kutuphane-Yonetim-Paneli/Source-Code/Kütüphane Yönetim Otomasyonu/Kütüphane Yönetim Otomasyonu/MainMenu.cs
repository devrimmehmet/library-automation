using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Members members = new Members();
            members.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Books books = new Books();
            books.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Employees employees = new Employees();
            employees.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Transactions transactions = new Transactions();
            transactions.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Requests requests = new Requests();
            requests.ShowDialog();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            AboutUs aboutUs = new AboutUs();
            aboutUs.ShowDialog();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Statistics statistics = new Statistics();
            statistics.ShowDialog();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Categories categories = new Categories();
            categories.ShowDialog();
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //Members members = new Members();
            //members.ShowDialog();
            //this.Close();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //this.Hide();
            //Members members = new Members();
            //members.ShowDialog();
            //this.Close();
            //Members form2 = new Members();//açılacak form
            //form2.MdiParent = this;//bu formu parent olarak veriyoruz.
            //form2.Show(); //form 2 açılıyor.
          
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            //panel1.Controls.Clear(); // Panel'in içini temizliyoruz..
            //Members frm2 = new Members();
            //frm2.TopLevel = false;
            //panel1.Controls.Add(frm2); // panel1 içerisinde formu ekledik

            //frm2.Show(); // formu gösterdik. Ancak buraya dikakt. ShowDialog(); olarak değil Show(); olarak açıyoruz.
            //frm2.Dock = DockStyle.Fill; // Açılan formun paneli doldurmasını sağladık.
            //frm2.BringToFront(); // formu panel içinde en öne getirdik
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            panel1.Controls.Clear(); // Panel'in içini temizliyoruz..
            Employees frm2 = new Employees();
            frm2.TopLevel = false;
            panel1.Controls.Add(frm2); // panel1 içerisinde formu ekledik

            frm2.Show(); // formu gösterdik. Ancak buraya dikakt. ShowDialog(); olarak değil Show(); olarak açıyoruz.
            frm2.Dock = DockStyle.Fill; // Açılan formun paneli doldurmasını sağladık.
            frm2.BringToFront(); // formu panel içinde en öne getirdik
        }

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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear(); // Panel'in içini temizliyoruz..
            Employees frm2 = new Employees();
            frm2.TopLevel = false;
            panel1.Controls.Add(frm2); // panel1 içerisinde formu ekledik

            frm2.Show(); // formu gösterdik. Ancak buraya dikakt. ShowDialog(); olarak değil Show(); olarak açıyoruz.
            frm2.Dock = DockStyle.Fill; // Açılan formun paneli doldurmasını sağladık.
            frm2.BringToFront(); // formu panel içinde en öne getirdik
        }
    }
}
