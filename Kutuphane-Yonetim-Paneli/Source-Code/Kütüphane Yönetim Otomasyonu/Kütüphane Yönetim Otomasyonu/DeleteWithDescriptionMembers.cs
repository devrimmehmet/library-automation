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
    public partial class DeleteWithDescriptionMembers : Form
    {
        public DeleteWithDescriptionMembers()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection($"Data Source=.;Initial Catalog=Library;Integrated Security=True");
        public int DeletedID = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (rTB_DeletedInfo.Text=="")
            {
                MessageBox.Show("Üye Silme Gerekçenizi bir kaç kelime ile açıklayınız.", "Boş Geçilemez", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
            sqlConnection.Open();
            string Employee = "SELECT * FROM Employees where IdentityNumber=@ID AND Password=@Password and DeletedState=0 and Permission_ID=1";
            SqlCommand  EmployeeCmd = new SqlCommand(Employee, sqlConnection);
            EmployeeCmd.Parameters.AddWithValue("@Password", txt_Password.Text);
            EmployeeCmd.Parameters.AddWithValue("@ID",txt_ID.Text);
            SqlDataReader  dr = EmployeeCmd.ExecuteReader();
            if (dr.Read())
            {
                int DeletedEmployeeID = Convert.ToInt32(dr["ID"]);
                sqlConnection.Close();
                sqlConnection.Open();
                string DeletedMemberStr = "DeleteFromMembers @ID,@DeletedInfo,@DeletedDate,@DeletedEmployeeID";
                SqlCommand DeleteMember = new SqlCommand(DeletedMemberStr, sqlConnection);
                DeleteMember.Parameters.AddWithValue("@ID", DeletedID);
                DeleteMember.Parameters.AddWithValue("@DeletedInfo", rTB_DeletedInfo.Text);
                DeleteMember.Parameters.AddWithValue("@DeletedDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                DeleteMember.Parameters.AddWithValue("@DeletedEmployeeID", DeletedEmployeeID);
                DeleteMember.ExecuteNonQuery();
                sqlConnection.Close();
                    MessageBox.Show("Üye Silindi.");
                    this.Close();
            }
            else
            {
                MessageBox.Show("Kullanıcı adınızı ve şifrenizi kontrol ediniz. Yada Silme işlemi için yetkiniz yok.", "Yetki/Bilgi Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            sqlConnection.Close();
            }
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
