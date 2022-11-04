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
    public partial class Publishers : Form
    {
        public Publishers()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection("Data Source=.; Initial Catalog=Library; Integrated Security=true");

        private void Default()
        {
            txt_Name.Text = "";
            txt_Id.Text = "";
            txt_Mail.Text = "";
            txt_Phone.Text = "";
            richTextBox1.Text = "";
        }
        private void TableReflesh()
        {
            SqlDataAdapter adp = new SqlDataAdapter("select * from Publishers where DeletedState=0", sqlConnection);
            DataTable dt = new DataTable();
            sqlConnection.Open();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlConnection.Close();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 40;
            dataGridView1.Columns[1].HeaderText = "Ad";
            dataGridView1.Columns[1].Width = 300;
            dataGridView1.Columns[2].HeaderText = "Telefon";
            dataGridView1.Columns[2].Width = 120;
            dataGridView1.Columns[3].HeaderText = "Mail";
            dataGridView1.Columns[3].Width = 220;
            dataGridView1.Columns[4].HeaderText = "Adres";
            dataGridView1.Columns[4].Width = 400;
            dataGridView1.Columns[5].Visible = false;
        }

        private void TableReflesh(string SearchTextName)
        {
            string PublisherSearchStr = "select * from Publishers where Name like '%'+@Text+'%' and DeletedState=0";
            SqlDataAdapter PublisherCmd = new SqlDataAdapter();
            PublisherCmd.SelectCommand = new SqlCommand(PublisherSearchStr, sqlConnection);
            PublisherCmd.SelectCommand.Parameters.AddWithValue("@Text", SearchTextName.ToString());
            DataTable dt = new DataTable();
            sqlConnection.Open();
            PublisherCmd.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlConnection.Close();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Ad";
            dataGridView1.Columns[1].Width = 300;
            dataGridView1.Columns[2].HeaderText = "Telefon";
            dataGridView1.Columns[3].HeaderText = "Mail";
            dataGridView1.Columns[3].Width = 120;
            dataGridView1.Columns[4].HeaderText = "Adres";
            dataGridView1.Columns[4].Width = 480;
            dataGridView1.Columns[5].Visible = false;
        }
        private void Members_Load(object sender, EventArgs e)
        {


            dataGridView1.ReadOnly = true; // sadece okunabilir olması yani veri düzenleme kapalı
            dataGridView1.AllowUserToDeleteRows = false; // satırların silinmesi engelleniyor
            dataGridView1.AllowUserToAddRows = false; // satır ekleme iptal

            TableReflesh();

            txt_Name.MaxLength = 50;
            txt_Phone.MaxLength = 11;
            txt_Mail.MaxLength = 50;
            richTextBox1.MaxLength = 200;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_Id.Text = (dataGridView1.CurrentRow.Cells["ID"].Value).ToString();
            txt_Name.Text = dataGridView1.CurrentRow.Cells["Name"].Value.ToString();
            txt_Phone.Text = dataGridView1.CurrentRow.Cells["Phone"].Value.ToString();
            txt_Mail.Text = dataGridView1.CurrentRow.Cells["Mail"].Value.ToString();
            richTextBox1.Text = dataGridView1.CurrentRow.Cells["Address"].Value.ToString();
        }

     

      
        private void txt_Search_Name_TextChanged(object sender, EventArgs e)
        {
            TableReflesh(txt_Search_Name.Text);
            Default();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand FindPublisher = new SqlCommand();
            FindPublisher.Connection = sqlConnection;
            FindPublisher.CommandText = "FindPublisher"; //stoured procedure'un saklandığı yer.
            FindPublisher.CommandType = CommandType.StoredProcedure; //bağlantı tipi stoured procedure olarak ayarlandı.
            FindPublisher.Parameters.AddWithValue("@Name", txt_Name.Text);
            SqlDataReader dr2 = FindPublisher.ExecuteReader();
            if (dr2.Read())
            {
                MessageBox.Show("Bu isme sahip başka bir yayınevi var !!!");
                sqlConnection.Close();

            }
            else
            {

                if (!this.txt_Mail.Text.Contains('@') || !this.txt_Mail.Text.Contains('.'))
                {
                    MessageBox.Show("Lütfen Geçerli Bir Mail Adresi giriniz.", "Geçersiz Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    sqlConnection.Close();
                }
                else
                {
                    if (txt_Phone.TextLength > 10)
                    {
                        sqlConnection.Close();
                        sqlConnection.Open();
                        string PublisherAdd = "insert into Publishers (Name,Phone,Mail,Address) values (@Name,@Phone,@Mail,@Address)";
                        SqlCommand komut = new SqlCommand(PublisherAdd, sqlConnection);
                        komut.Parameters.AddWithValue("@Name", txt_Name.Text);
                        komut.Parameters.AddWithValue("@Phone", txt_Phone.Text);
                        komut.Parameters.AddWithValue("@Mail", txt_Mail.Text);
                        komut.Parameters.AddWithValue("@Address", richTextBox1.Text);
                        int eklenti = komut.ExecuteNonQuery();
                        sqlConnection.Close();
                        if (eklenti > 0)
                        {
                            MessageBox.Show("Yayınevi Sisteme Eklendi.");
                            TableReflesh();
                            Default();
                        }
                        else
                        {
                            MessageBox.Show("Yayınevi eklenemedi.");
                        }
                        sqlConnection.Close();
                        Default();
                    }
                    else
                    {
                        MessageBox.Show("Lütfen Geçerli Bir Telefon Numarası giriniz.", "Geçersiz Telefon", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        sqlConnection.Close();
                    }

                }
            }

        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (txt_Id.Text != "")
            {
                if (MessageBox.Show("Üyeyi Silmeyi Onaylıyormusunuz?", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    sqlConnection.Open();
                    int IDD = Convert.ToInt32(txt_Id.Text);
                    SqlCommand Sil = new SqlCommand($"DeleteFromPublishers {IDD}", sqlConnection);
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
                MessageBox.Show("Lütfen silinecek yayınevini seçiniz");
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand FindPublisher = new SqlCommand();
            FindPublisher.Connection = sqlConnection;
            FindPublisher.CommandText = "FindPublisherForUpdate"; //stoured procedure'un saklandığı yer.
            FindPublisher.CommandType = CommandType.StoredProcedure; //bağlantı tipi stoured procedure olarak ayarlandı.
            FindPublisher.Parameters.AddWithValue("@Name", txt_Name.Text);
            FindPublisher.Parameters.AddWithValue("@ID", txt_Id.Text);
            SqlDataReader dr2 = FindPublisher.ExecuteReader();
            if (dr2.Read())
            {
                MessageBox.Show("Bu isme sahip başka bir yayınevi var !!!", "Yayınevi Zaten Mevcut", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sqlConnection.Close();

            }
            else
            {
                if (!this.txt_Mail.Text.Contains('@') || !this.txt_Mail.Text.Contains('.'))
                {
                    MessageBox.Show("Lütfen Geçerli Bir Mail Adresi giriniz.", "Geçersiz Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    sqlConnection.Close();
                }
                else
                {
                    if (txt_Phone.TextLength > 10)
                    {
                        if (txt_Id.Text != "")
                        {
                            sqlConnection.Close();
                            int IDD = Convert.ToInt32(txt_Id.Text);
                            sqlConnection.Open();
                            SqlCommand Update = new SqlCommand($"UpdateFromPublishers {IDD},@Name,@Phone,@Mail,@Address", sqlConnection);
                            Update.Parameters.AddWithValue("@Name", txt_Name.Text);
                            Update.Parameters.AddWithValue("@Phone", txt_Phone.Text);
                            Update.Parameters.AddWithValue("@Mail", txt_Mail.Text);
                            Update.Parameters.AddWithValue("@Address", richTextBox1.Text);
                            Update.ExecuteNonQuery();
                            sqlConnection.Close();
                            TableReflesh();
                            Default();
                        }
                        else
                        {
                            MessageBox.Show("Lütfen güncellenecek yayınevini seçiniz");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lütfen Geçerli Bir Telefon Numarası giriniz.", "Geçersiz Telefon", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        sqlConnection.Close();
                    }
                }
            }
        }
    }
}

