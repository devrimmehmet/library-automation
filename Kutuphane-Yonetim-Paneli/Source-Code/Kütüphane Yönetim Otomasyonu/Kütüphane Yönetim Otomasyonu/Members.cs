using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Kütüphane_Yönetim_Otomasyonu
{
    public partial class Members : Form
    {
        public Members()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection("Data Source=.; Initial Catalog=Library; Integrated Security=true");
        public int ActiveEmployeeID=0;
        public int ActiveEmployeePermission = 0;
        private void Default()
        {
            txt_ID.Text = "";
            txt_Name.Text = "";
            txt_Surname.Text = "";
            cB_Gender.SelectedIndex = 2;
            txt_Phone.Text = "";
            txt_IdentityNumber.Text = "";
            cB_State.SelectedIndex = 0;
            rTxt_Address.Text = "";
            txt_Mail.Text = "";
            dTP_BirthDay.Value = DateTime.Now.AddYears(-15).AddDays(-1);
            dTP_MemberDate.Value = DateTime.Now;
            txt_Password.Text = "";
        }
        public void TableReflesh()
        {
            SqlDataAdapter adp = new SqlDataAdapter("select * from Members m inner join MemberStates mS on mS.ID=m.Member_State_ID where DeletedState=0", sqlConnection);
            DataTable dt = new DataTable();
            sqlConnection.Open();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlConnection.Close();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].HeaderText = "Ad";
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].HeaderText = "Soyad";
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Visible =false;// "Cinsiyet"
            dataGridView1.Columns[4].Visible =false;// "Doğum Tarihi"
            dataGridView1.Columns[5].Visible = false;//"Telefon"
            dataGridView1.Columns[5].Width = 120;
            dataGridView1.Columns[6].HeaderText = "TC";
            dataGridView1.Columns[6].Width = 130;
            dataGridView1.Columns[7].HeaderText = "Mail";
            dataGridView1.Columns[7].Width = 240;
            dataGridView1.Columns[8].HeaderText = "Adres";
            dataGridView1.Columns[8].Width = 220;
            dataGridView1.Columns[10].HeaderText = "Üyelik Tarihi";
            dataGridView1.Columns[10].Width =150;
            dataGridView1.Columns[11].Visible = false;//"Şifre"
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns["Member_State_ID"].Visible = false;
            dataGridView1.Columns["ID1"].Visible = false;
            dataGridView1.Columns["DeletedInfo"].Visible = false;
            dataGridView1.Columns["DeletedDate"].Visible = false;
            dataGridView1.Columns["DeletedEmployeeID"].Visible = false;
            dataGridView1.Columns["MemberState"].Visible = false;//"Durum"
        }
        private void TableReflesh(decimal SearchTextTC)
        {
            string MemberUpdateStr = $"select * from Members m inner join MemberStates mS on mS.ID=m.Member_State_ID where IdentityNumber like '%'+@Text+'%' and DeletedState=0";
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand(MemberUpdateStr, sqlConnection);
            adp.SelectCommand.Parameters.AddWithValue("@Text", SearchTextTC.ToString());
            DataTable dt = new DataTable();
            sqlConnection.Open();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlConnection.Close();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Ad";
            dataGridView1.Columns[2].HeaderText = "Soyad";
            dataGridView1.Columns[3].HeaderText = "Cinsiyet";
            dataGridView1.Columns[4].HeaderText = "Doğum Tarihi";
            dataGridView1.Columns[5].HeaderText = "Telefon";
            dataGridView1.Columns[6].HeaderText = "TC";
            dataGridView1.Columns[7].HeaderText = "Mail";
            dataGridView1.Columns[8].HeaderText = "Adres";
            dataGridView1.Columns[10].HeaderText = "Üyelik Tarihi";
            dataGridView1.Columns[11].HeaderText = "Şifre";
            dataGridView1.Columns[11].HeaderText = "Şifre";
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns["Member_State_ID"].Visible = false;
            dataGridView1.Columns["ID1"].Visible = false;
            dataGridView1.Columns["DeletedInfo"].Visible = false;
            dataGridView1.Columns["DeletedDate"].Visible = false;
            dataGridView1.Columns["DeletedEmployeeID"].Visible = false;
            dataGridView1.Columns["MemberState"].HeaderText = "Durum";
        }
        private void TableReflesh(string SearchTextName)
        {
            string MemberUpdateStr = $"select * from Members m inner join MemberStates mS on mS.ID=m.Member_State_ID where Name like '%'+@Text+'%' and DeletedState=0";
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand(MemberUpdateStr, sqlConnection);
            adp.SelectCommand.Parameters.AddWithValue("@Text", SearchTextName);
            DataTable dt = new DataTable();
            sqlConnection.Open();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlConnection.Close();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Ad";
            dataGridView1.Columns[2].HeaderText = "Soyad";
            dataGridView1.Columns[3].HeaderText = "Cinsiyet";
            dataGridView1.Columns[4].HeaderText = "Doğum Tarihi";
            dataGridView1.Columns[5].HeaderText = "Telefon";
            dataGridView1.Columns[6].HeaderText = "TC";
            dataGridView1.Columns[7].HeaderText = "Mail";
            dataGridView1.Columns[8].HeaderText = "Adres";
            dataGridView1.Columns[10].HeaderText = "Üyelik Tarihi";
            dataGridView1.Columns[11].HeaderText = "Şifre";
            dataGridView1.Columns[11].HeaderText = "Şifre";
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns["Member_State_ID"].Visible = false;
            dataGridView1.Columns["ID1"].Visible = false;
            dataGridView1.Columns["DeletedInfo"].Visible = false;
            dataGridView1.Columns["DeletedDate"].Visible = false;
            dataGridView1.Columns["DeletedEmployeeID"].Visible = false;
            dataGridView1.Columns["MemberState"].HeaderText = "Durum";
        }
        private void Members_Load(object sender, EventArgs e)
        {
           
            dTP_BirthDay.MaxDate = DateTime.Now.AddYears(-15);
            SqlCommand komut = new SqlCommand("SELECT MemberState FROM MemberStates", sqlConnection);
            SqlDataReader dr;
            sqlConnection.Open();
            dr = komut.ExecuteReader();
            cB_State.Items.Clear();
            while (dr.Read())
            {
                cB_State.Items.Add(dr["MemberState"]);
            }
            sqlConnection.Close();
            Default();
            dataGridView1.ReadOnly = true; // sadece okunabilir olması yani veri düzenleme kapalı
            dataGridView1.AllowUserToDeleteRows = false; // satırların silinmesi engelleniyor
            dataGridView1.AllowUserToAddRows = false; // satır ekleme iptal
            txt_Name.MaxLength = 50;
            txt_Surname.MaxLength = 50;
            txt_Phone.MaxLength = 11;
            txt_IdentityNumber.MaxLength = 11;
            txt_Mail.MaxLength = 50;
            rTxt_Address.MaxLength = 200;
            txt_Password.MaxLength = 50;
            txt_Search_TC.MaxLength = 11;
            txt_Search_Name.MaxLength = 50;
            TableReflesh();
            if (ActiveEmployeePermission == 3)
            {
             
                cB_State.Enabled = false;
                btn_Delete.Enabled = false;
                txt_Password.UseSystemPasswordChar = true;
            }
        }
        private void Just_Numeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewCellStyle renk = new DataGridViewCellStyle();
                if (dataGridView1.Rows[i].Cells["MemberState"].Value.ToString() == "Aktif")
                {
                    renk.BackColor = Color.YellowGreen;
                }
                else if (dataGridView1.Rows[i].Cells["MemberState"].Value.ToString() == "Pasif")
                {
                    renk.BackColor = Color.Orange;
                }
                else if (dataGridView1.Rows[i].Cells["MemberState"].Value.ToString() == "Cezalı")
                {
                    renk.BackColor = Color.Red;
                    renk.ForeColor = Color.White;
                }
                dataGridView1.Rows[i].DefaultCellStyle = renk;
            }
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
            if (txt_Search_Name.Text != "")
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
            string MemberStr = "SELECT * FROM Members where IdentityNumber=@ID";
            SqlCommand Member = new SqlCommand(MemberStr, sqlConnection);
            Member.Parameters.AddWithValue("@ID", txt_IdentityNumber.Text);
            SqlDataReader dr2 = Member.ExecuteReader();
            if (dr2.Read())
            {
                MessageBox.Show("Bu TC numarasına ait başka bir üye var !!!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sqlConnection.Close();
            }
            else
            {
                sqlConnection.Close();
                if (txt_Name.Text != "")
                {
                    if (txt_Surname.Text != "")
                    {
                        if (!this.txt_Mail.Text.Contains('@') || !this.txt_Mail.Text.Contains('.'))
                        {
                            MessageBox.Show("Lütfen Geçerli Bir Mail Adresi giriniz.", "Geçersiz Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (txt_Phone.TextLength > 10)
                            {
                                if (txt_IdentityNumber.TextLength > 10)
                                {
                                    if (txt_Password.Text=="")
                                    {
                                        txt_Password.Text = dTP_BirthDay.Value.ToString("yyyy");
                                    }
                                   
                                    
                                    int MemberState = 1;
                                        sqlConnection.Open();
                                        SqlCommand MemberStateFind = new SqlCommand($"SELECT ID FROM MemberStates where MemberState='{cB_State.Text}'", sqlConnection);
                                        SqlDataReader dr3 = MemberStateFind.ExecuteReader();
                                        if (dr3.Read())
                                        {
                                            MemberState = Convert.ToInt32(dr3["ID"].ToString());
                                            sqlConnection.Close();
                                        }
                                        sqlConnection.Open();
                                        string MemberAddStr = "insert into members (Name,Surname,Gender,BirthDate,Phone,IdentityNumber,Mail,Address,Member_State_ID,Password) values (@Name,@Surname,@Gender,@BirthDate,@Phone,@IdentityNumber,@Mail,@Address,@Member_State_ID,@Password)";
                                        SqlCommand komut = new SqlCommand(MemberAddStr, sqlConnection);
                                        komut.Parameters.AddWithValue("@Name", txt_Name.Text);
                                        komut.Parameters.AddWithValue("@Surname", txt_Surname.Text);
                                        komut.Parameters.AddWithValue("@Gender", cB_Gender.Text);
                                        string BirthDate = dTP_BirthDay.Value.ToString("yyyy-MM-dd");
                                        komut.Parameters.AddWithValue("@BirthDate", BirthDate);
                                        komut.Parameters.AddWithValue("@Phone", txt_Phone.Text);
                                        komut.Parameters.AddWithValue("@IdentityNumber", txt_IdentityNumber.Text);
                                        komut.Parameters.AddWithValue("@Mail", txt_Mail.Text);
                                        komut.Parameters.AddWithValue("@Address", rTxt_Address.Text);
                                        komut.Parameters.AddWithValue("@Member_State_ID", MemberState);
                                        komut.Parameters.AddWithValue("@Password", txt_Password.Text);
                                        int eklenti = komut.ExecuteNonQuery();
                                        sqlConnection.Close();
                                        if (eklenti > 0)
                                        {
                                            MessageBox.Show("Üye Sisteme Eklendi.");
                                            TableReflesh();
                                            Default();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Üye eklenemedi.");
                                        }
                                        sqlConnection.Close();
                                   
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
                    }
                    else
                    {
                        MessageBox.Show("Lütfen Soyadınızı Giriniz!", "Soyadınız boş olamaz!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen adınızı giriniz", "Adınız boş olamaz.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (txt_ID.Text != "")
            {
               
                if (MessageBox.Show("Üyeyi Silmeyi Onaylıyormusunuz?", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    DeleteWithDescriptionMembers deleteWithDescriptionMembers = new DeleteWithDescriptionMembers();
                    deleteWithDescriptionMembers.DeletedID = Convert.ToInt32(txt_ID.Text);
                    deleteWithDescriptionMembers.ShowDialog();
                    Default();
                    TableReflesh();

                }
                else
                {
                    MessageBox.Show("Silme işlemi tarafınızca iptal edilmiştir.", "Kayıt İptal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Lütfen silinecek kaydı seçiniz", "Seçim Yapmadınız", MessageBoxButtons.OK, MessageBoxIcon.Error);
             
                
               
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


                        int MemberState = 1;
                        sqlConnection.Open();
                        SqlCommand MemberStateFind = new SqlCommand($"SELECT ID FROM MemberStates where MemberState='{cB_State.Text}'", sqlConnection);
                        SqlDataReader dr3 = MemberStateFind.ExecuteReader();
                        if (dr3.Read())
                        {

                            MemberState = Convert.ToInt32(dr3["ID"].ToString());
                            sqlConnection.Close();

                        }

                        int IDD = Convert.ToInt32(txt_ID.Text);
                        sqlConnection.Open();
                        string MemberUpdateStr = $"UpdateFromMembers @ID,@Name,@Surname,@Gender,@BirthDate,@Phone,@Mail,@Address,@Member_State_ID,@Password";
                        SqlCommand Update = new SqlCommand(MemberUpdateStr, sqlConnection);
                        Update.Parameters.AddWithValue("@ID", IDD);
                        Update.Parameters.AddWithValue("@Name", txt_Name.Text);
                        Update.Parameters.AddWithValue("@Surname", txt_Surname.Text);
                        Update.Parameters.AddWithValue("@Gender", cB_Gender.Text);
                        string BirthDate = dTP_BirthDay.Value.ToString("yyyy-MM-dd");
                        Update.Parameters.AddWithValue("@BirthDate", BirthDate);
                        Update.Parameters.AddWithValue("@Phone", txt_Phone.Text);

                        Update.Parameters.AddWithValue("@Mail", txt_Mail.Text);
                        Update.Parameters.AddWithValue("@Address", rTxt_Address.Text);
                        Update.Parameters.AddWithValue("@Member_State_ID", MemberState);
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

      

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txt_ID.Text = (dataGridView1.CurrentRow.Cells["ID"].Value).ToString();
            txt_Name.Text = dataGridView1.CurrentRow.Cells["Name"].Value.ToString();
            txt_Surname.Text = dataGridView1.CurrentRow.Cells["Surname"].Value.ToString();
            cB_Gender.Text = (dataGridView1.CurrentRow.Cells["Gender"].Value).ToString();
            dTP_BirthDay.Text = dataGridView1.CurrentRow.Cells["BirthDate"].Value.ToString();
            txt_Phone.Text = dataGridView1.CurrentRow.Cells["Phone"].Value.ToString();
            txt_IdentityNumber.Text = (dataGridView1.CurrentRow.Cells["IdentityNumber"].Value).ToString();
            txt_Mail.Text = dataGridView1.CurrentRow.Cells["Mail"].Value.ToString();
            rTxt_Address.Text = dataGridView1.CurrentRow.Cells["Address"].Value.ToString();
            int MemberState = Convert.ToInt32((dataGridView1.CurrentRow.Cells["Member_State_ID"].Value).ToString());
            sqlConnection.Open();
            SqlCommand MemberStateFind = new SqlCommand($"SELECT MemberState FROM MemberStates where ID='{MemberState}'", sqlConnection);
            SqlDataReader dr3 = MemberStateFind.ExecuteReader();
            if (dr3.Read())
            {
                cB_State.Text = (dr3["MemberState"].ToString());
                sqlConnection.Close();
            }
            dTP_MemberDate.Text = dataGridView1.CurrentRow.Cells["MemberDate"].Value.ToString();
            txt_Password.Text = dataGridView1.CurrentRow.Cells["Password"].Value.ToString();
        }

        private void txt_Password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar==32)
            {
                e.Handled = true;
                MessageBox.Show("Şifrede boşluk karakteri kullanılamaz.", "Paralo'da Boşluk Kullanılamaz!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }


}

