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
            string Employee = "SELECT * FROM Employees where IdentityNumber=@ID AND Password=@Password";
            SqlCommand  EmployeeCmd = new SqlCommand(Employee, sqlConnection);
            EmployeeCmd.Parameters.AddWithValue("@Password", txt_Password.Text);
            EmployeeCmd.Parameters.AddWithValue("@ID",txt_ID.Text);
            SqlDataReader  dr = EmployeeCmd.ExecuteReader();
            if (dr.Read())
            {
                this.Hide();
                int Permission_ID = Convert.ToInt32(dr["Permission_ID"]);
                if (Permission_ID==1)
                {
                    MainMenu admin = new MainMenu();
                    admin.ActiveEmployeeID = Convert.ToInt32(dr["ID"]);
                    sqlConnection.Close();
                    admin.ShowDialog();
                    this.Close();
                }else if (Permission_ID == 3)
                {
                    VolunteerMenu volunteer = new VolunteerMenu();
                    volunteer.ActiveEmployeeID = Convert.ToInt32(dr["ID"]);
                    volunteer.ActiveEmployeePermission = Permission_ID;
                    sqlConnection.Close();
                    volunteer.ShowDialog();
                    this.Close();
                }
               
            }
            sqlConnection.Close();
            sqlConnection.Open();

            string Member = "SELECT * FROM Members where IdentityNumber=@ID AND Password=@Password";
            SqlCommand MemberCmd = new SqlCommand(Member, sqlConnection);
            MemberCmd.Parameters.AddWithValue("@Password", txt_Password.Text);
            MemberCmd.Parameters.AddWithValue("@ID", txt_ID.Text);
            SqlDataReader dr2 = MemberCmd.ExecuteReader();
            if (dr2.Read())
            {
                this.Hide();
                MemberMenu user = new MemberMenu();
                user.ActiveMemberID = Convert.ToInt32(dr2["ID"]);
                sqlConnection.Close();
                user.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Kullanıcı adınızı ve şifrenizi kontrol ediniz.", "Giriş Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            sqlConnection.Close();
        }

       
        private void Just_Numeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void Login_Load(object sender, EventArgs e)
        {
            txt_ID.MaxLength = 11;
            txt_Password.MaxLength = 50;
        }
    }
}
