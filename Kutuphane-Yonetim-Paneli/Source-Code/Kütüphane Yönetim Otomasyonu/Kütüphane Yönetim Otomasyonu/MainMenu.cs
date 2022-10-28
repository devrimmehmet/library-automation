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
    }
}
