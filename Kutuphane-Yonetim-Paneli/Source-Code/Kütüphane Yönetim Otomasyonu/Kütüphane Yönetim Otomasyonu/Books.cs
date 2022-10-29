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
    public partial class Books : Form
    {
        public Books()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection("Data Source=.; Initial Catalog=Library; Integrated Security=true");

        private void TableReflesh()
        {
            SqlDataAdapter adp = new SqlDataAdapter("select * from Books b inner join Authors a on a.ID=b.Author_ID inner join Languages l on l.ID=b.Language_ID inner join Publishers p on p.ID=b.Publisher_ID inner join Categories c on c.ID=b.Category_ID where state=1 ", sqlConnection);
            DataTable dt = new DataTable();
            sqlConnection.Open();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;

            sqlConnection.Close();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Ad";
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].HeaderText = "Yayın Tarihi";
            dataGridView1.Columns[4].HeaderText = "Sayfa Sayısı";
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible =false;
            dataGridView1.Columns[7].HeaderText = "Açıklama";
            dataGridView1.Columns[8].HeaderText = "Durum";
            dataGridView1.Columns[9].HeaderText = "Raf Numarası";
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].HeaderText = "Yazar";
            dataGridView1.Columns[14].Visible = false;
            dataGridView1.Columns[15].Visible = false;
            dataGridView1.Columns[16].HeaderText = "Dili";
            dataGridView1.Columns[17].Visible = false;
            dataGridView1.Columns[18].HeaderText = "Yayınevi";
            dataGridView1.Columns[19].Visible = false;
            dataGridView1.Columns[20].Visible = false;
            dataGridView1.Columns[21].Visible = false;
            dataGridView1.Columns[22].Visible = false;
            dataGridView1.Columns[23].HeaderText = "Kategori";


        }
        private void TableReflesh(decimal SearchTextTC)
        {
            SqlDataAdapter adp = new SqlDataAdapter($"select * from Books b inner join Authors a on a.ID=b.Author_ID inner join Languages l on l.ID=b.Language_ID inner join Publishers p on p.ID=b.Publisher_ID inner join Categories c on c.ID=b.Category_ID where a.NameSurname like '%{SearchTextTC}%'", sqlConnection);
            DataTable dt = new DataTable();
            sqlConnection.Open();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;

            sqlConnection.Close();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Ad";
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].HeaderText = "Yayın Tarihi";
            dataGridView1.Columns[4].HeaderText = "Sayfa Sayısı";
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].HeaderText = "Açıklama";
            dataGridView1.Columns[8].HeaderText = "Durum";
            dataGridView1.Columns[9].HeaderText = "Raf Numarası";
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].HeaderText = "Yazar";
            dataGridView1.Columns[14].Visible = false;
            dataGridView1.Columns[15].Visible = false;
            dataGridView1.Columns[16].HeaderText = "Dili";
            dataGridView1.Columns[17].Visible = false;
            dataGridView1.Columns[18].HeaderText = "Yayınevi";
            dataGridView1.Columns[19].Visible = false;
            dataGridView1.Columns[20].Visible = false;
            dataGridView1.Columns[21].Visible = false;
            dataGridView1.Columns[22].Visible = false;
            dataGridView1.Columns[23].HeaderText = "Kategori";


        }
        private void TableReflesh(string SearchTextName)
        {
            SqlDataAdapter adp = new SqlDataAdapter($"select * from Books b inner join Authors a on a.ID=b.Author_ID inner join Languages l on l.ID=b.Language_ID inner join Publishers p on p.ID=b.Publisher_ID inner join Categories c on c.ID=b.Category_ID where Name like '{SearchTextName}%'", sqlConnection);
            DataTable dt = new DataTable();
            sqlConnection.Open();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;

            sqlConnection.Close();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Ad";
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].HeaderText = "Yayın Tarihi";
            dataGridView1.Columns[4].HeaderText = "Sayfa Sayısı";
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].HeaderText = "Açıklama";
            dataGridView1.Columns[8].HeaderText = "Durum";
            dataGridView1.Columns[9].HeaderText = "Raf Numarası";
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].HeaderText = "Yazar";
            dataGridView1.Columns[14].Visible = false;
            dataGridView1.Columns[15].Visible = false;
            dataGridView1.Columns[16].HeaderText = "Dili";
            dataGridView1.Columns[17].Visible = false;
            dataGridView1.Columns[18].HeaderText = "Yayınevi";
            dataGridView1.Columns[19].Visible = false;
            dataGridView1.Columns[20].Visible = false;
            dataGridView1.Columns[21].Visible = false;
            dataGridView1.Columns[22].Visible = false;
            dataGridView1.Columns[23].HeaderText = "Kategori";


        }
        private void Members_Load(object sender, EventArgs e)
        {

            checkBox1.Checked = true;

            SqlCommand komut = new SqlCommand("SELECT Language FROM Languages", sqlConnection);
            SqlDataReader dr;
            sqlConnection.Open();
            dr = komut.ExecuteReader();
            comboBox1.Items.Clear();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["Language"]);
            }
            sqlConnection.Close();

            SqlCommand komut1 = new SqlCommand("SELECT NameSurname FROM Authors", sqlConnection);
            SqlDataReader dr1;
            sqlConnection.Open();
            dr1 = komut1.ExecuteReader();
            comboBox2.Items.Clear();
            while (dr1.Read())
            {
                comboBox2.Items.Add(dr1["NameSurname"]);
            }
            
            sqlConnection.Close();
            SqlCommand komut2 = new SqlCommand("SELECT Name FROM Publishers", sqlConnection);
            SqlDataReader dr2;
            sqlConnection.Open();
            dr2 = komut2.ExecuteReader();
            comboBox3.Items.Clear();
            while (dr2.Read())
            {
                comboBox3.Items.Add(dr2["Name"]);
            }

            sqlConnection.Close();


            SqlCommand komut3 = new SqlCommand("SELECT Name FROM Categories", sqlConnection);
            SqlDataReader dr3;
            sqlConnection.Open();
            dr3 = komut3.ExecuteReader();
            comboBox4.Items.Clear();
            while (dr3.Read())
            {
                comboBox4.Items.Add(dr3["Name"]);
            }

            sqlConnection.Close();
            //  comboBox2.SelectedIndex = 0;
            dataGridView1.ReadOnly = true; // sadece okunabilir olması yani veri düzenleme kapalı
            dataGridView1.AllowUserToDeleteRows = false; // satırların silinmesi engelleniyor
            dataGridView1.AllowUserToAddRows = false; // satır ekleme iptal

            TableReflesh();
            comboBox1.SelectedIndex = 0;
            txt_Name.MaxLength = 50;
            txt_Surname.MaxLength = 50;
            txt_Phone.MaxLength = 11;
            txt_TC.MaxLength = 11;
            txt_Mail.MaxLength = 50;
            rTxt_Address.MaxLength = 200;
            txt_Password.MaxLength = 50;
            txt_Search_TC.MaxLength = 11;
            txt_Search_Name.MaxLength = 50;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToInt32(dataGridView1.CurrentRow.Cells["State"].Value)==1)
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked= false;
            }
            txt_Id.Text = (dataGridView1.CurrentRow.Cells["ID"].Value).ToString();
            txt_Name.Text = dataGridView1.CurrentRow.Cells["Name"].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells["PublicationYear"].Value.ToString();
            txt_Phone.Text = dataGridView1.CurrentRow.Cells["NumberOfPages"].Value.ToString();
            rTxt_Address.Text = dataGridView1.CurrentRow.Cells["Description"].Value.ToString();
            txt_Surname.Text = dataGridView1.CurrentRow.Cells["ShelfNumber"].Value.ToString();
            SqlCommand komut = new SqlCommand("SELECT Language FROM Languages", sqlConnection);
            SqlDataReader dr;
            sqlConnection.Open();
            dr = komut.ExecuteReader();
            comboBox1.Items.Clear();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["Language"]);
            }
            try
            {
                comboBox1.SelectedIndex = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Language_ID"].Value) - 1;
            }
            catch (Exception)
            {
            }
            sqlConnection.Close();
           
            SqlCommand komut1 = new SqlCommand("SELECT NameSurname FROM Authors", sqlConnection);
            SqlDataReader dr1;
            sqlConnection.Open();
            dr1 = komut1.ExecuteReader();
            comboBox2.Items.Clear();
            while (dr1.Read())
            {
                comboBox2.Items.Add(dr1["NameSurname"]);
            }
            try
            {
                comboBox2.SelectedIndex = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Author_ID"].Value) - 1;
            }
            catch (Exception)
            {
            }

            sqlConnection.Close();
            SqlCommand komut2 = new SqlCommand("SELECT Name FROM Publishers", sqlConnection);
            SqlDataReader dr2;
            sqlConnection.Open();
            dr2 = komut2.ExecuteReader();
            comboBox3.Items.Clear();
            while (dr2.Read())
            {
                comboBox3.Items.Add(dr2["Name"]);
            }
            try
            {
                comboBox3.SelectedIndex = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Publisher_ID"].Value) - 1;
            }
            catch (Exception)
            {
            }
            sqlConnection.Close();


            SqlCommand komut3 = new SqlCommand("SELECT Name FROM Categories", sqlConnection);
            SqlDataReader dr3;
            sqlConnection.Open();
            dr3 = komut3.ExecuteReader();
            comboBox4.Items.Clear();
            while (dr3.Read())
            {
                comboBox4.Items.Add(dr3["Name"]);
            }
            try
            {
                comboBox4.SelectedIndex = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Category_ID"].Value) - 1;
            }
            catch (Exception)
            {
            }
            sqlConnection.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand Member = new SqlCommand($"SELECT * FROM Members where IdentityNumber='{txt_TC.Text}'", sqlConnection);
            SqlDataReader dr2 = Member.ExecuteReader();
            if (dr2.Read())
            {
                MessageBox.Show("Bu TC numarasına ait başka bir üye var !!!");
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
                    if (txt_Phone.TextLength > 10)
                    {

                        if (txt_TC.TextLength > 10)
                        {
                            int MemberState = comboBox2.SelectedIndex + 1;
                            sqlConnection.Open();
                            SqlCommand komut = new SqlCommand($"insert into members (Name,Surname,Gender,BirthDate,Phone,IdentityNumber,Mail,Address,Member_State_ID,Password) values ('{txt_Name.Text}','{txt_Surname.Text}','{comboBox1.Text}','{dateTimePicker1.Text}','{txt_Phone.Text}','{txt_TC.Text}','{txt_Mail.Text}','{rTxt_Address.Text}','{MemberState}','{txt_Password.Text}')");
                            komut.Connection = sqlConnection;
                            int eklenti = komut.ExecuteNonQuery();
                            sqlConnection.Close();

                            if (eklenti > 0)
                            {
                                MessageBox.Show("Kullanıcı Sisteme Eklendi.");
                                TableReflesh();
                            }
                            else
                            {
                                MessageBox.Show("Kullanıcı eklenemedi.");
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


        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (txt_Id.Text != "")
            {
                int IDD = Convert.ToInt32(txt_Id.Text);
                sqlConnection.Open();
                SqlCommand Sil = new SqlCommand($"DeleteFromMembers {IDD}", sqlConnection);
                Sil.ExecuteNonQuery();
                sqlConnection.Close();
                TableReflesh();
            }
            else
            {
                MessageBox.Show("Lütfen silinecek kaydı seçiniz");
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (txt_Phone.TextLength > 10)
            {
                if (!this.txt_Mail.Text.Contains('@') || !this.txt_Mail.Text.Contains('.'))
                {
                    MessageBox.Show("Lütfen Geçerli Bir Mail Adresi giriniz.", "Geçersiz Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {


                    int MemberState = comboBox2.SelectedIndex + 1;
                    if (txt_Id.Text != "")
                    {
                        int IDD = Convert.ToInt32(txt_Id.Text);
                        sqlConnection.Open();
                        SqlCommand Update = new SqlCommand($"UpdateFromMembers {IDD},'{txt_Name.Text}','{txt_Surname.Text}','{comboBox1.Text}','{dateTimePicker1.Text}','{txt_Phone.Text}','{txt_Mail.Text}','{rTxt_Address.Text}','{MemberState}','{txt_Password.Text}'", sqlConnection);
                        Update.ExecuteNonQuery();
                        sqlConnection.Close();
                        TableReflesh();
                    }
                    else
                    {
                        MessageBox.Show("Lütfen güncellenecek kaydı seçiniz");
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen Geçerli Bir Telefon Numarası giriniz.", "Geçersiz Telefon", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


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
            }

        }

        private void txt_Search_Name_TextChanged(object sender, EventArgs e)
        {
            txt_Search_TC.Text = "";
            TableReflesh(txt_Search_Name.Text);


        }
    }


}

