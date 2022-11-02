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
    public partial class Authors : Form
    {
        public Authors()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection("Data Source=.; Initial Catalog=Library; Integrated Security=true");
        private void Default()
        {
            txt_Id.Text = "";
            txt_NameSurname.Text = "";
            rTB_Info.Text = "";
        }
        private void TableReflesh()
        {
            SqlDataAdapter adp = new SqlDataAdapter("select * from Authors where DeletedState=0", sqlConnection);
            DataTable dt = new DataTable();
            sqlConnection.Open();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlConnection.Close();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Ad-Soyad";
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].HeaderText = "Hakkında";
            dataGridView1.Columns[2].Width = 850;
            dataGridView1.Columns[3].Visible = false;
        }
        private void TableSearch(string SearchTextInformation)
        {
            string AuthorUpdateStr = "select * from Authors where Information like '%'+@Text+'%' and DeletedState=0";
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand(AuthorUpdateStr, sqlConnection);
            adp.SelectCommand.Parameters.AddWithValue("@Text", SearchTextInformation.ToString());
            DataTable dt = new DataTable();
            sqlConnection.Open();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlConnection.Close();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Ad-Soyad";
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].HeaderText = "Hakkında";
            dataGridView1.Columns[2].Width = 850;
        }
        private void TableReflesh(string SearchTextName)
        {
            string AuthorUpdateStr = "select * from Authors where NameSurname like '%'+@Text+'%' and DeletedState=0";
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand(AuthorUpdateStr, sqlConnection);
            adp.SelectCommand.Parameters.AddWithValue("@Text", SearchTextName.ToString());
            DataTable dt = new DataTable();
            sqlConnection.Open();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlConnection.Close();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Ad-Soyad";
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].HeaderText = "Hakkında";
            dataGridView1.Columns[2].Width = 850;
        }
        private void Members_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true; // sadece okunabilir olması yani veri düzenleme kapalı
            dataGridView1.AllowUserToDeleteRows = false; // satırların silinmesi engelleniyor
            dataGridView1.AllowUserToAddRows = false; // satır ekleme iptal
            TableReflesh();
            txt_NameSurname.MaxLength = 100;
            rTB_Info.MaxLength = 1500;
            Default();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_Id.Text = (dataGridView1.CurrentRow.Cells["ID"].Value).ToString();
            txt_NameSurname.Text = dataGridView1.CurrentRow.Cells["NameSurname"].Value.ToString();
            rTB_Info.Text = dataGridView1.CurrentRow.Cells["Information"].Value.ToString();
        }
        private void txt_Search_TC_TextChanged(object sender, EventArgs e)
        {
            txt_Search_Name.Text = "";
            if (txt_Search_Information.Text != "")
            {
                TableSearch((txt_Search_Information.Text));
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
            txt_Search_Information.Text = "";
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
            if (txt_NameSurname.Text != "")
            {
                sqlConnection.Open();
                SqlCommand FindAuthor = new SqlCommand();
                FindAuthor.Connection = sqlConnection;
                FindAuthor.CommandText = "FindAuthor"; //stoured procedure'un saklandığı yer.
                FindAuthor.CommandType = CommandType.StoredProcedure; //bağlantı tipi stoured procedure olarak ayarlandı.
                FindAuthor.Parameters.AddWithValue("@NameSurname", txt_NameSurname.Text);
                SqlDataReader dr2 = FindAuthor.ExecuteReader();
                if (dr2.Read())
                {
                    MessageBox.Show("Bu isme sahip başka bir yazar var !!!");
                    sqlConnection.Close();
                }
                else
                {
                    sqlConnection.Close();
                    sqlConnection.Open();
                    SqlCommand komut = new SqlCommand();
                    komut.Connection = sqlConnection;
                    komut.CommandText = "AddAuthors"; //stoured procedure'un saklandığı yer.
                    komut.CommandType = CommandType.StoredProcedure; //bağlantı tipi stoured procedure olarak ayarlandı.
                    komut.Parameters.AddWithValue("@NameSurname", txt_NameSurname.Text);
                    komut.Parameters.AddWithValue("@Information", rTB_Info.Text);
                    int eklenti = komut.ExecuteNonQuery();
                    sqlConnection.Close();
                    if (eklenti > 0)
                    {
                        MessageBox.Show("Yazar Sisteme Eklendi.");
                        TableReflesh();
                    }
                    else
                    {
                        MessageBox.Show("Yazar eklenemedi.");
                    }
                    sqlConnection.Close();
                }
            }
            else
            {
                MessageBox.Show("Lütfen Yazarın adı ve soyadını giriniz !", "Yazar Adı Soyadı Boş Geçilemez.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (txt_Id.Text != "")
            {
                if (MessageBox.Show("Yazar Silmeyi Onaylıyormusunuz?", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    int IDD = Convert.ToInt32(txt_Id.Text);
                    sqlConnection.Open();
                    SqlCommand Sil = new SqlCommand($"DeleteFromAuthors {IDD}", sqlConnection);
                    Sil.ExecuteNonQuery();
                    sqlConnection.Close();
                    TableReflesh();
                    Default();
                }
                else
                {
                    MessageBox.Show("Silme işlemi tarafınızca iptal edilmiştir.", "Kayıt İptal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Lütfen silinecek yazarı seçiniz");
            }
        }
        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (txt_NameSurname.Text != "")
            {
                sqlConnection.Open();
                SqlCommand FindAuthor = new SqlCommand();
                FindAuthor.Connection = sqlConnection;
                FindAuthor.CommandText = "FindAuthor"; //stoured procedure'un saklandığı yer.
                FindAuthor.CommandType = CommandType.StoredProcedure; //bağlantı tipi stoured procedure olarak ayarlandı.
                FindAuthor.Parameters.AddWithValue("@NameSurname", txt_NameSurname.Text);
                SqlDataReader dr2 = FindAuthor.ExecuteReader();
                if (dr2.Read())
                {
                    MessageBox.Show("Bu isme sahip başka bir yazar var !!!");
                    sqlConnection.Close();
                }
                else
                {
                    sqlConnection.Close();
                    if (txt_Id.Text != "")
                    {
                        int IDD = Convert.ToInt32(txt_Id.Text);
                        sqlConnection.Open();
                        SqlCommand UpdateCMD = new SqlCommand();
                        UpdateCMD.Connection = sqlConnection;
                        UpdateCMD.CommandText = "UpdateFromAuthors"; //stoured procedure'un saklandığı yer.
                        UpdateCMD.CommandType = CommandType.StoredProcedure; //bağlantı tipi stoured procedure olarak ayarlandı.
                        UpdateCMD.Parameters.AddWithValue("@ID", IDD); //@Adi parametresi gösterldi.
                        UpdateCMD.Parameters.AddWithValue("@NameSurname", txt_NameSurname.Text); //@SoyAdi paremetresi gönderildi.
                        UpdateCMD.Parameters.AddWithValue("@Information", rTB_Info.Text); //@SoyAdi paremetresi gönderildi.
                        UpdateCMD.ExecuteNonQuery(); // veriler veritabanında kaydedildi.
                        sqlConnection.Close();
                        TableReflesh();
                        Default();
                    }
                    else
                    {
                        MessageBox.Show("Lütfen güncellenecek yazarı seçiniz");
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen Yazarın adı ve soyadını giriniz !", "Yazar Adı Soyadı Boş Geçilemez.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

