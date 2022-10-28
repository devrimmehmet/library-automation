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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear(); // Panel'in içini temizliyoruz..
            Authors frm2 = new Authors();
            frm2.TopLevel = false;
            panel1.Controls.Add(frm2); // panel1 içerisinde formu ekledik

            frm2.Show(); // formu gösterdik. Ancak buraya dikakt. ShowDialog(); olarak değil Show(); olarak açıyoruz.
            frm2.Dock = DockStyle.Fill; // Açılan formun paneli doldurmasını sağladık.
            frm2.BringToFront(); // formu panel içinde en öne getirdik
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear(); // Panel'in içini temizliyoruz..
            Categories frm2 = new Categories();
            frm2.TopLevel = false;
            panel1.Controls.Add(frm2); // panel1 içerisinde formu ekledik

            frm2.Show(); // formu gösterdik. Ancak buraya dikakt. ShowDialog(); olarak değil Show(); olarak açıyoruz.
            frm2.Dock = DockStyle.Fill; // Açılan formun paneli doldurmasını sağladık.
            frm2.BringToFront(); // formu panel içinde en öne getirdik
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear(); // Panel'in içini temizliyoruz..
            Languages frm2 = new Languages();
            frm2.TopLevel = false;
            panel1.Controls.Add(frm2); // panel1 içerisinde formu ekledik

            frm2.Show(); // formu gösterdik. Ancak buraya dikakt. ShowDialog(); olarak değil Show(); olarak açıyoruz.
            frm2.Dock = DockStyle.Fill; // Açılan formun paneli doldurmasını sağladık.
            frm2.BringToFront(); // formu panel içinde en öne getirdik
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear(); // Panel'in içini temizliyoruz..
            MemberStates frm2 = new MemberStates();
            frm2.TopLevel = false;
            panel1.Controls.Add(frm2); // panel1 içerisinde formu ekledik

            frm2.Show(); // formu gösterdik. Ancak buraya dikakt. ShowDialog(); olarak değil Show(); olarak açıyoruz.
            frm2.Dock = DockStyle.Fill; // Açılan formun paneli doldurmasını sağladık.
            frm2.BringToFront(); // formu panel içinde en öne getirdik
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear(); // Panel'in içini temizliyoruz..
            Permissions frm2 = new Permissions();
            frm2.TopLevel = false;
            panel1.Controls.Add(frm2); // panel1 içerisinde formu ekledik

            frm2.Show(); // formu gösterdik. Ancak buraya dikakt. ShowDialog(); olarak değil Show(); olarak açıyoruz.
            frm2.Dock = DockStyle.Fill; // Açılan formun paneli doldurmasını sağladık.
            frm2.BringToFront(); // formu panel içinde en öne getirdik
        }
    }
}
