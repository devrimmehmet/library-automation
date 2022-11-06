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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Kütüphane_Yönetim_Otomasyonu
{
    public partial class MemberUpdatePassword : Form
    {
        public MemberUpdatePassword()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection($"Data Source=.;Initial Catalog=Library;Integrated Security=True");
        public int ActiveMemberID = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (tB_NewPass1.Text==tB_NewPass2.Text)
            {
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }

                string Member = "SELECT * FROM Members where ID=@ID AND Password=@Password";
                SqlCommand MemberCmd = new SqlCommand(Member, sqlConnection);
                MemberCmd.Parameters.AddWithValue("@Password", tB_OldPass.Text);
                MemberCmd.Parameters.AddWithValue("@ID", ActiveMemberID);
                SqlDataReader dr2 = MemberCmd.ExecuteReader();
                if (dr2.Read())
                {
                    sqlConnection.Close();
                    if (sqlConnection.State==ConnectionState.Closed)
                    {
                        sqlConnection.Open();
                    }
                    
                    SqlCommand Update = new SqlCommand();
                    Update.Connection = sqlConnection;
                    Update.CommandText = "UpdatePasswordFromMembers"; //stoured procedure'un saklandığı yer.
                    Update.CommandType = CommandType.StoredProcedure; //bağlantı tipi stoured procedure olarak ayarlandı.
                    Update.Parameters.AddWithValue("@ID", ActiveMemberID);
                    Update.Parameters.AddWithValue("@Password", tB_NewPass1.Text);
                    Update.ExecuteNonQuery();
                    sqlConnection.Close();
                    MessageBox.Show("Şifreniz başarıyla değiştirildi.");
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Eski şifrenizi yanlış girdiniz.", "Eski Şifre Hatalı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                sqlConnection.Close();
            }
            else
            {
                MessageBox.Show("Yeni şifreler aynı değil!", "Uyumsuz Yeni Şifre", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

       
        private void Login_Load(object sender, EventArgs e)
        {
        
            tB_NewPass1.MaxLength = 50;
            tB_OldPass.MaxLength = 50;
            tB_NewPass2.MaxLength = 50;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (tB_NewPass1.UseSystemPasswordChar == true)
            {
                tB_NewPass1.UseSystemPasswordChar = false;
                tB_NewPass2.UseSystemPasswordChar = false;
                tB_OldPass.UseSystemPasswordChar = false;
            }
            else
            {
                tB_NewPass1.UseSystemPasswordChar = true;
                tB_NewPass2.UseSystemPasswordChar = true;
                tB_OldPass.UseSystemPasswordChar = true;
            }
        }
    }
}
