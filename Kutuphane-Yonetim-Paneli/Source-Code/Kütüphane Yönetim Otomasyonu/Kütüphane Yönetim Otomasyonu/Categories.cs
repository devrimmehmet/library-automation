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
    public partial class Categories : Form
    {
        public Categories()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection("Data Source=.; Initial Catalog=Library; Integrated Security=true");
        private void Default()
        {
            txt_Id.Text = "";
            txt_Name.Text = "";
        }
        private void TableReflesh()
        {
            SqlDataAdapter adp = new SqlDataAdapter("select * from Categories where DeletedState=0", sqlConnection);
            DataTable dt = new DataTable();
            sqlConnection.Open();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlConnection.Close();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Name";
            dataGridView1.Columns[1].Width = 1000;
            dataGridView1.Columns[2].Visible = false;
        }
        private void TableReflesh(string SearchTextName)
        {
            string CategorySearchStr = "select * from Categories where Name like '%'+@Text+'%' and DeletedState=0";
            SqlDataAdapter CategoryCmd = new SqlDataAdapter();
            CategoryCmd.SelectCommand = new SqlCommand(CategorySearchStr, sqlConnection);
            CategoryCmd.SelectCommand.Parameters.AddWithValue("@Text", SearchTextName.ToString());
            DataTable dt = new DataTable();
            sqlConnection.Open();
            CategoryCmd.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlConnection.Close();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Name";
            dataGridView1.Columns[1].Width = 1000;
            dataGridView1.Columns[2].Visible = false;
        }
        private void Members_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true; // sadece okunabilir olması yani veri düzenleme kapalı
            dataGridView1.AllowUserToDeleteRows = false; // satırların silinmesi engelleniyor
            dataGridView1.AllowUserToAddRows = false; // satır ekleme iptal
            TableReflesh();
            txt_Name.MaxLength = 50;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_Id.Text = (dataGridView1.CurrentRow.Cells["ID"].Value).ToString();
            txt_Name.Text = dataGridView1.CurrentRow.Cells["Name"].Value.ToString();
        }
        private void txt_Search_Name_TextChanged(object sender, EventArgs e)
        {

            TableReflesh(txt_Search_Name.Text);
        }
        private void btn_Add_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand FindCategory = new SqlCommand();
            FindCategory.Connection = sqlConnection;
            FindCategory.CommandText = "FindCategory"; //stoured procedure'un saklandığı yer.
            FindCategory.CommandType = CommandType.StoredProcedure; //bağlantı tipi stoured procedure olarak ayarlandı.
            FindCategory.Parameters.AddWithValue("@Name", txt_Name.Text);
            SqlDataReader dr2 = FindCategory.ExecuteReader();
            if (dr2.Read())
            {
                MessageBox.Show("Bu isme sahip başka bir kategori var !!!","Kategori Zaten Mevcut", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                sqlConnection.Close();
            }
            else
            {
                sqlConnection.Close();
                sqlConnection.Open();
                string CategoryAdd = "insert into Categories (Name) values (@Name)";
                SqlCommand komut = new SqlCommand(CategoryAdd, sqlConnection);
                komut.Parameters.AddWithValue("@Name", txt_Name.Text);
                int eklenti = komut.ExecuteNonQuery();
                sqlConnection.Close();
                if (eklenti > 0)
                {
                    MessageBox.Show("Kategori Sisteme Eklendi.");
                    TableReflesh();
                }
                else
                {
                    MessageBox.Show("Kategori eklenemedi.");
                }
                sqlConnection.Close();
                Default();
            }
        }
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (txt_Id.Text != "")
            {
                if (MessageBox.Show("Üyeyi Silmeyi Onaylıyormusunuz?", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    int IDD = Convert.ToInt32(txt_Id.Text);
                    sqlConnection.Open();
                    SqlCommand Sil = new SqlCommand($"DeleteFromCategories {IDD}", sqlConnection);
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
                MessageBox.Show("Lütfen silinecek kategoriyi seçiniz");
            }
        }
        private void btn_Update_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand FindCategory = new SqlCommand();
            FindCategory.Connection = sqlConnection;
            FindCategory.CommandText = "FindCategory"; //stoured procedure'un saklandığı yer.
            FindCategory.CommandType = CommandType.StoredProcedure; //bağlantı tipi stoured procedure olarak ayarlandı.
            FindCategory.Parameters.AddWithValue("@Name", txt_Name.Text);
            SqlDataReader dr2 = FindCategory.ExecuteReader();
            if (dr2.Read())
            {
                MessageBox.Show("Bu isme sahip başka bir kategori var bu güncelleme işlemini yapamazsınız !!!","Kategori Zaten Mevcut", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                sqlConnection.Close();

            }
            else
            {
                sqlConnection.Close();
                sqlConnection.Open();

                if (txt_Id.Text != "")
                {
                    int IDD = Convert.ToInt32(txt_Id.Text);
                    SqlCommand Update = new SqlCommand($"UpdateFromCategories {IDD},@Name", sqlConnection);
                    Update.Parameters.AddWithValue("@Name", txt_Name.Text);
                    Update.ExecuteNonQuery();
                    sqlConnection.Close();
                    TableReflesh();
                    Default();
                }
                else
                {
                    MessageBox.Show("Lütfen güncellenecek kategoriyi seçiniz");
                }
                sqlConnection.Close();
            }
        }
    }


}

