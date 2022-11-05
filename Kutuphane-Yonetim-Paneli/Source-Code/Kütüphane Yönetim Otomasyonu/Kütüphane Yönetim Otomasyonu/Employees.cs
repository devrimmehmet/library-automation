using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Kütüphane_Yönetim_Otomasyonu
{
    public partial class Employees : Form
    {
        public Employees()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection("Data Source=.; Initial Catalog=Library; Integrated Security=true");
        public int ActiveEmployeeID;
        private void Default()
        {
            txt_ID.Text = "";
            txt_Name.Text = "";
            txt_Surname.Text = "";
            cB_Gender.SelectedIndex = 2;
            txt_Phone.Text = "";
            txt_IdentityNumber.Text = "";
            txt_Mail.Text = "";
            txt_Password.Text = "";
            cB_Permission.SelectedIndex = 1;
            dTP_BirthDay.Value = DateTime.Now.AddYears(-18).AddDays(-1);
            
        }
        private void TableReflesh()
        {
            SqlDataAdapter adp = new SqlDataAdapter("select * from Employees m inner join Permissions p on p.ID=m.Permission_ID where DeletedState=0", sqlConnection);
            DataTable dt = new DataTable();
            sqlConnection.Open();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlConnection.Close();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Ad";
            dataGridView1.Columns["Name"].Width = 170;
            dataGridView1.Columns[2].HeaderText = "Soyad";
            dataGridView1.Columns["Surname"].Width = 150;
            dataGridView1.Columns[3].HeaderText = "Telefon";
            dataGridView1.Columns[3].Width = 120;
            dataGridView1.Columns[4].HeaderText = "TC";
            dataGridView1.Columns[4].Width = 120;
            dataGridView1.Columns[5].Visible = false;//"Cinsiyet"
            dataGridView1.Columns[6].Visible = false;//"Doğum Tarihi"
            dataGridView1.Columns[8].HeaderText = "Mail";
            dataGridView1.Columns["Mail"].Width = 250;
            dataGridView1.Columns[9].HeaderText = "Şifre";
            dataGridView1.Columns[15].HeaderText = "Yetki";
            dataGridView1.Columns["Permission_ID"].Visible = false;
            dataGridView1.Columns["ID1"].Visible = false;
            dataGridView1.Columns["DeletedState"].Visible = false;
           
         
            dataGridView1.Columns["DeletedInfo"].Visible = false;
            dataGridView1.Columns["DeletedDate"].Visible = false;
            dataGridView1.Columns["DeletedEmployeeID"].Visible = false;
            
        }
        private void TableReflesh(decimal SearchTextTC)
        {
            string EmployeeUpdateStr = "select * from Employees m inner join Permissions p on p.ID=m.Permission_ID where IdentityNumber like '%'+@Text+'%'  and DeletedState=0";
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand(EmployeeUpdateStr, sqlConnection);
            adp.SelectCommand.Parameters.AddWithValue("@Text", SearchTextTC.ToString());
            DataTable dt = new DataTable();
            sqlConnection.Open();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlConnection.Close();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Ad";
            dataGridView1.Columns[2].HeaderText = "Soyad";
            dataGridView1.Columns[3].HeaderText = "Telefon";
            dataGridView1.Columns[4].HeaderText = "TC";
            dataGridView1.Columns[5].HeaderText = "Cinsiyet";
            dataGridView1.Columns[6].HeaderText = "Doğum Tarihi";
            dataGridView1.Columns[8].HeaderText = "Mail";
            dataGridView1.Columns[9].HeaderText = "Şifre";
            dataGridView1.Columns[15].HeaderText = "Yetki";
            dataGridView1.Columns["Permission_ID"].Visible = false;
            dataGridView1.Columns["ID1"].Visible = false;
            dataGridView1.Columns["DeletedState"].Visible = false;
            dataGridView1.Columns["Mail"].Width = 150;
            dataGridView1.Columns["Name"].Width = 120;
            dataGridView1.Columns["Surname"].Width = 120;
            dataGridView1.Columns["DeletedInfo"].Visible = false;
            dataGridView1.Columns["DeletedDate"].Visible = false;
            dataGridView1.Columns["DeletedEmployeeID"].Visible = false;
        }
        private void TableReflesh(string SearchTextName)
        {
            string EmployeeUpdateStr = "select * from Employees m inner join Permissions p on p.ID=m.Permission_ID where Name like '%'+@Text+'%'  and DeletedState=0";
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand(EmployeeUpdateStr, sqlConnection);
            adp.SelectCommand.Parameters.AddWithValue("@Text", SearchTextName);
            DataTable dt = new DataTable();
            sqlConnection.Open();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlConnection.Close();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Ad";
            dataGridView1.Columns[2].HeaderText = "Soyad";
            dataGridView1.Columns[3].HeaderText = "Telefon";
            dataGridView1.Columns[4].HeaderText = "TC";
            dataGridView1.Columns[5].HeaderText = "Cinsiyet";
            dataGridView1.Columns[6].HeaderText = "Doğum Tarihi";
            dataGridView1.Columns[8].HeaderText = "Mail";
            dataGridView1.Columns[9].HeaderText = "Şifre";
            dataGridView1.Columns[15].HeaderText = "Yetki";
            dataGridView1.Columns["Permission_ID"].Visible = false;
            dataGridView1.Columns["ID1"].Visible = false;
            dataGridView1.Columns["DeletedState"].Visible = false; 
            dataGridView1.Columns["Mail"].Width = 150;
            dataGridView1.Columns["Name"].Width = 120;
            dataGridView1.Columns["Surname"].Width = 120;
            dataGridView1.Columns["DeletedInfo"].Visible = false;
            dataGridView1.Columns["DeletedDate"].Visible = false;
            dataGridView1.Columns["DeletedEmployeeID"].Visible = false;
        }
        private void Members_Load(object sender, EventArgs e)
        {
            dTP_BirthDay.MaxDate = DateTime.Now.AddYears(-18);
            SqlCommand komut = new SqlCommand("SELECT Permission FROM Permissions", sqlConnection);
            SqlDataReader dr;
            sqlConnection.Open();
            dr = komut.ExecuteReader();
            cB_Permission.Items.Clear();
            while (dr.Read())
            {
                cB_Permission.Items.Add(dr["Permission"]);
            }
            sqlConnection.Close();
            Default();
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToAddRows = false;
            txt_Name.MaxLength = 50;
            txt_Surname.MaxLength = 50;
            txt_Phone.MaxLength = 11;
            txt_IdentityNumber.MaxLength = 11;
            txt_Mail.MaxLength = 50;
            txt_Password.MaxLength = 50;
            txt_Search_TC.MaxLength = 11;
            txt_Search_Name.MaxLength = 50;
            TableReflesh();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_ID.Text = (dataGridView1.CurrentRow.Cells["ID"].Value).ToString();
            txt_Name.Text = dataGridView1.CurrentRow.Cells["Name"].Value.ToString();
            txt_Surname.Text = dataGridView1.CurrentRow.Cells["Surname"].Value.ToString();
            cB_Gender.Text = (dataGridView1.CurrentRow.Cells["Gender"].Value).ToString();
            dTP_BirthDay.Text = dataGridView1.CurrentRow.Cells["BirthDate"].Value.ToString();
            txt_Phone.Text = dataGridView1.CurrentRow.Cells["Phone"].Value.ToString();
            txt_IdentityNumber.Text = (dataGridView1.CurrentRow.Cells["IdentityNumber"].Value).ToString();
            txt_Mail.Text = dataGridView1.CurrentRow.Cells["Mail"].Value.ToString();
            int PermissionID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Permission_ID"].Value.ToString());
            SqlCommand komut = new SqlCommand($"SELECT Permission FROM Permissions where ID={PermissionID}", sqlConnection);
            SqlDataReader dr;
            sqlConnection.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cB_Permission.Text = (dr["Permission"].ToString());
            }
            sqlConnection.Close();
            txt_Password.Text = dataGridView1.CurrentRow.Cells["Password"].Value.ToString(); 
        }
        private void Just_Numeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void txt_Search_TC_TextChanged(object sender, EventArgs e)
        {
            txt_Search_Name.Text = "";
            if (txt_Search_TC.Text != "")
            {
                TableReflesh(Convert.ToDecimal(txt_Search_TC.Text));
                Default();
            }
            else
            {
                TableReflesh();
                Default();
            }
        }
        private void txt_Search_Name_TextChanged(object sender, EventArgs e)
        {
            txt_Search_TC.Text = "";
            if (txt_Search_Name.Text!="")
            {
                TableReflesh(txt_Search_Name.Text);
                Default();
            }
            else
            {
                TableReflesh();
                Default();
            }
        }
        private void btn_Add_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand Member = new SqlCommand($"SELECT * FROM Employees where IdentityNumber='{txt_IdentityNumber.Text}'", sqlConnection);
            SqlDataReader dr2 = Member.ExecuteReader();
            if (dr2.Read())
            {
                MessageBox.Show("Bu TC numarasına ait başka bir Personel var !!!", "Geçersiz TC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sqlConnection.Close();
            }
            else
            {
                sqlConnection.Close();
                if (!this.txt_Mail.Text.Contains('@') || !this.txt_Mail.Text.Contains('.'))
                {
                    MessageBox.Show("Lütfen Geçerli Bir Mail Adresi giriniz.", "Geçersiz Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (txt_Name.Text != "")
                    {
                        if (txt_Surname.Text != "")
                        {
                            if (txt_Phone.TextLength > 10)
                            {
                                if (txt_IdentityNumber.TextLength > 10)
                                {
                                    if (txt_Password.Text!="")
                                    {
                                        int PermissionID = 0;
                                        SqlCommand komut1 = new SqlCommand($"SELECT ID FROM Permissions where Permission='{cB_Permission.Text}'", sqlConnection);
                                        SqlDataReader dr;
                                        sqlConnection.Open();
                                        dr = komut1.ExecuteReader();
                                        while (dr.Read())
                                        {
                                            PermissionID = Convert.ToInt32(dr["ID"].ToString());
                                        }
                                        sqlConnection.Close();
                                        sqlConnection.Open();
                                        string EmployeeAddStr = "insert into employees (Name,Surname,Gender,BirthDate,Phone,IdentityNumber,Mail,Permission_ID,Password) values (@Name,@Surname,@Gender,@BirthDate,@Phone,@IdentityNumber,@Mail,@Permission_ID,@Password)";
                                        SqlCommand komut = new SqlCommand(EmployeeAddStr, sqlConnection);
                                        komut.Parameters.AddWithValue("@Name", txt_Name.Text);
                                        komut.Parameters.AddWithValue("@Surname", txt_Surname.Text);
                                        komut.Parameters.AddWithValue("@Gender", cB_Gender.Text);
                                        string BirthDate = dTP_BirthDay.Value.ToString("yyyy-MM-dd");
                                        komut.Parameters.AddWithValue("@BirthDate", BirthDate);
                                        komut.Parameters.AddWithValue("@Phone", txt_Phone.Text);
                                        komut.Parameters.AddWithValue("@IdentityNumber", txt_IdentityNumber.Text);
                                        komut.Parameters.AddWithValue("@Mail", txt_Mail.Text);
                                        komut.Parameters.AddWithValue("@Permission_ID", PermissionID);
                                        komut.Parameters.AddWithValue("@Password", txt_Password.Text);
                                        int eklenti = komut.ExecuteNonQuery();
                                        sqlConnection.Close();
                                        if (eklenti > 0)
                                        {
                                            MessageBox.Show("Personel Sisteme Eklendi.");
                                            TableReflesh();
                                            Default();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Personel eklenemedi.");
                                        }
                                        sqlConnection.Close();
                                        
                                    }
                                    else
                                    {
                                        MessageBox.Show("Lütfen Şifrenizi Yazınız!", "Şifre Boş Geçilemez", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Lütfen Geçerli Bir TC Numarası giriniz.", "Geçersiz TC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Lütfen Geçerli Bir Telefon Numarası giriniz.", "Geçersiz Telefon", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Lütfen Soyadınızı Yazınız.", "Soyisim Boş Geçilemez", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lütfen adınızı yazınız.", "İsim Boş Geçilemez", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (txt_ID.Text != "")
            {
                if (MessageBox.Show("Personel Silmeyi Onaylıyormusunuz?", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    if (txt_ID.Text==this.ActiveEmployeeID.ToString())
                    {
                        MessageBox.Show("Kendi Kendinizi Silemezsiniz!", "Kendi Kaydını Silme İşlemi Yapılamaz!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        DeleteWithDescriptionEmployee deleteWithDescriptionEmployee = new DeleteWithDescriptionEmployee();
                        deleteWithDescriptionEmployee.DeletedID = Convert.ToInt32(txt_ID.Text);
                        deleteWithDescriptionEmployee.ActiveEmployeeID = this.ActiveEmployeeID;
                        deleteWithDescriptionEmployee.ShowDialog();
                        Default();
                        TableReflesh();
                    }
                    
                }
                else
                {
                    MessageBox.Show("Silme işlemi tarafınızca iptal edilmiştir.", "Kayıt İptal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Lütfen Silinecek Personeli Seçiniz!", "Seçim Yapılmadı!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (txt_ID.Text != "")
            {
                if (txt_Phone.TextLength > 10)
                {
                    if (!this.txt_Mail.Text.Contains('@') || !this.txt_Mail.Text.Contains('.'))
                    {
                        MessageBox.Show("Lütfen Geçerli Bir Mail Adresi giriniz.", "Geçersiz Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        int PermissionID = 0;
                        SqlCommand komut1 = new SqlCommand($"SELECT ID FROM Permissions where Permission='{cB_Permission.Text}'", sqlConnection);
                        SqlDataReader dr;
                        sqlConnection.Open();
                        dr = komut1.ExecuteReader();
                        while (dr.Read())
                        {
                            PermissionID = Convert.ToInt32(dr["ID"].ToString());
                        }
                        sqlConnection.Close();
                        int IDD = Convert.ToInt32(txt_ID.Text);
                        sqlConnection.Open();
                        string MemberUpdateStr = $"UpdateFromEmployees @ID,@Name,@Surname,@Gender,@BirthDate,@Phone,@Mail,@Permission_ID,@Password";
                        SqlCommand Update = new SqlCommand(MemberUpdateStr, sqlConnection);
                        Update.Parameters.AddWithValue("@ID", IDD);
                        Update.Parameters.AddWithValue("@Name", txt_Name.Text);
                        Update.Parameters.AddWithValue("@Surname", txt_Surname.Text);
                        Update.Parameters.AddWithValue("@Gender", cB_Gender.Text);
                        string BirthDate = dTP_BirthDay.Value.ToString("yyyy-MM-dd");
                        Update.Parameters.AddWithValue("@BirthDate", BirthDate);
                        Update.Parameters.AddWithValue("@Phone", txt_Phone.Text);
                        Update.Parameters.AddWithValue("@Mail", txt_Mail.Text);
                        Update.Parameters.AddWithValue("@Permission_ID", PermissionID);
                        Update.Parameters.AddWithValue("@Password", txt_Password.Text);
                        Update.ExecuteNonQuery();
                        sqlConnection.Close();
                        TableReflesh();
                        Default();

                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Geçerli Bir Telefon Numarası giriniz.", "Geçersiz Telefon", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen güncellenecek üyeyi seçiniz", "Seçim Yapmadınız", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_Password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 32)
            {
                e.Handled = true;
                MessageBox.Show("Şifrede boşluk karakteri kullanılamaz.", "Paralo'da Boşluk Kullanılamaz!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

