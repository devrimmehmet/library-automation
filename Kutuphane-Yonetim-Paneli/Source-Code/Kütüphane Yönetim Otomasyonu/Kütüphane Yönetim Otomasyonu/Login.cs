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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection($"Data Source=.;Initial Catalog=Library;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand Employee = new SqlCommand($"SELECT * FROM Employees where IdentityNumber='{textBox1.Text}' AND Password='{textBox2.Text}'", sqlConnection);
            SqlDataReader  dr = Employee.ExecuteReader();
            if (dr.Read())
            {
               
                this.Hide();
                MainMenu admin = new MainMenu();
                admin.ActiveEmployeeID = Convert.ToInt32(dr["ID"]);
                sqlConnection.Close();
                admin.ShowDialog();

               
                this.Close();
            }
            sqlConnection.Close();
            sqlConnection.Open();
            SqlCommand Member = new SqlCommand($"SELECT * FROM Members where IdentityNumber='{textBox1.Text}' AND Password='{textBox2.Text}'", sqlConnection);
            SqlDataReader dr2 = Member.ExecuteReader();
            if (dr2.Read())
            {
                MessageBox.Show("Tebrikler! Başarılı bir şekilde giriş yaptınız.");
                sqlConnection.Close();
                this.Hide();
                UserMenu user = new UserMenu();
                user.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Kullanıcı adınızı ve şifrenizi kontrol ediniz.", "Giriş Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            sqlConnection.Close();
        }
    }
}
